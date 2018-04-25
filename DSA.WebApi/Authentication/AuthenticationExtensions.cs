using DSA.DAL.Context;
using DSA.Domain.Customers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DSA.WebApi.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddIdentityAuthorization(this IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 6;

                })
                .AddEntityFrameworkStores<DronSharingContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });

            return services;
        }
    }
}
