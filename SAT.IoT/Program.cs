
using SAT.BLL.Dto.Rents;
using SAT.Domain.Params;
using SAT.IoT.Service;
using System;
using System.Collections.Generic;

namespace SAT.IoT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start proccessing ...");
            Console.ReadLine();

            var rentFilterParams = new RentsFilterParams();

            AuthenticationService.Authorize(new Model.CurrentUserViewModel
            {
                Email = "danil@gmail.com",
                Password = "Eh1aS1_"
            });

            var rentsResult = RentService.GetRents(rentFilterParams);

            UpdateRents(rentsResult.Collection);

            var totalPages = Math.Ceiling((double)rentsResult.TotalCount / rentFilterParams.Take);

            for (var i = 2; i <= totalPages; i++)
            {
                rentFilterParams.Skip = rentFilterParams.Take * (i - 1);

                var rents = RentService.GetRents(rentFilterParams);
                UpdateRents(rents.Collection);
            }
        }

        public static void UpdateRents(IEnumerable<RentDto> rents)
        {
            foreach (var rent in rents)
            {
                var startDate = DateTime.Parse(rent.StartDate);
                var endDate = DateTime.Parse(rent.EndDate);

                if (endDate < DateTime.Now)
                {
                    rent.Status = Domain.Rents.RentStatus.Completed;
                }

                if (endDate >= DateTime.Now && startDate <= DateTime.Now)
                {
                    rent.Status = Domain.Rents.RentStatus.Active;
                }

                Console.WriteLine($"Status of #{rent.RentId} was updated to {rent.Status.ToString()}.");

                RentService.UpdateRent(rent);
            }
        }
    }
}
