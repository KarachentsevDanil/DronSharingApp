
using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using RCS.IoT.Service;
using System;
using System.Collections.Generic;

namespace RCS.IoT
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            var residentFilterParams = new ResidentsFilterParams();

            AuthenticationService.Authorize(new Model.CurrentUserViewModel
            {
                Email = "admin@gmail.com",
                Password = "Eh1aS1_"
            });

            var resientsResult = ResidentService.GetResidents(residentFilterParams);

            GenereteObservations(resientsResult.Collection);

            var totalPages = Math.Ceiling((double)resientsResult.TotalCount / residentFilterParams.Take);

            for (var i = 1; i <= totalPages; i++)
            {
                residentFilterParams.Skip = residentFilterParams.Take * (i - 1);

                var residents = ResidentService.GetResidents(residentFilterParams);
                GenereteObservations(residents.Collection);
            }
        }

        static void GenereteObservations(IEnumerable<ResidentDto> residents)
        {
            foreach (var resident in residents)
            {
                var bloodPressure = CreateObservation(ObservationType.BloodPressure, resident);
                var heartRate = CreateObservation(ObservationType.HeartRate, resident);
                var temperature = CreateObservation(ObservationType.Temperature, resident);

                Console.WriteLine($"Resident #{resident.ResidentId} blood pressure is {bloodPressure.SystolicValue} / {bloodPressure.DiastolicValue} {bloodPressure.Unit}");
                Console.WriteLine($"Resident #{resident.ResidentId} heart rate is {bloodPressure.Value} {bloodPressure.Unit}");
                Console.WriteLine($"Resident #{resident.ResidentId} temperature is {bloodPressure.Value} {bloodPressure.Unit}");

                ObservationService.AddObservation(bloodPressure);
                ObservationService.AddObservation(heartRate);
                ObservationService.AddObservation(temperature);
            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int GetRandomNumber(int minimum, int maximum)
        {
            return random.Next(minimum, maximum);
        }

        static AddObservationDto CreateObservation(ObservationType type, ResidentDto resident)
        {
            switch (type)
            {
                case ObservationType.BloodPressure:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.BloodPressure,
                        RecordedDate = DateTime.Now,
                        DiastolicValue = GetRandomNumber(80, 140),
                        SystolicValue = GetRandomNumber(80, 140),
                        Unit = "mmHg"
                    };
                case ObservationType.HeartRate:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.HeartRate,
                        RecordedDate = DateTime.Now,
                        Value = GetRandomNumber(60.0, 120.0),
                        Unit = "bpm"
                    };
                case ObservationType.Temperature:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.Temperature,
                        RecordedDate = DateTime.Now,
                        Value = GetRandomNumber(36.0, 38.0),
                        Unit = "°C"
                    };
            }

            return null;
        }
    }
}
