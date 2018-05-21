using SAT.IoT.Extenction;
using SAT.IoT.Model;

namespace SAT.IoT.Service
{
    public class AuthenticationService
    {
        private const string _baseAuthorizationUrl = "/api/account/";
        private const string _getTokenUrl = "login";

        public static void GetToken(CurrentUserViewModel login)
        {
            var token = HttpClientExtenction.PostDataAndGetResult<CurrentUserViewModel, CurrentUserViewModel>(login, string.Concat(_baseAuthorizationUrl, _getTokenUrl));
            HttpClientExtenction.User = token;
        }
    }
}
