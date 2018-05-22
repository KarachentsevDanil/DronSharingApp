using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using RCS.IoT.Extenction;

namespace RCS.IoT.Service
{
    public class ResidentService
    {
        private const string _baseResidentDto = "";
        private const string _getResidents = "";

        public static CollectionResult<ResidentDto> GetResidents(ResidentsFilterParams residentsFilterParams)
        {
            var residentResult = HttpClientExtenction.PostDataAndGetResult<ResidentsFilterParams, CollectionResult<ResidentDto>>(residentsFilterParams, string.Concat(_baseResidentDto, _getResidents));
            return residentResult;
        }
    }
}
