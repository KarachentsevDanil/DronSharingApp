using RCS.BLL.Dto.Residents;
using RCS.IoT.Extenction;

namespace RCS.IoT.Service
{
    public class ObservationService
    {
        private const string _baseObservationDto = "";
        private const string _addObservation = "";

        public static void AddObservation(AddObservationDto observationDto)
        {
            HttpClientExtenction.PostData(observationDto, string.Concat(_baseObservationDto, _addObservation));
        }
    }
}
