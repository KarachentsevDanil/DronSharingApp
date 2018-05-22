using SAT.BLL.Dto.Rents;
using SAT.Domain.Params;
using SAT.IoT.Extenction;

namespace SAT.IoT.Service
{
    public class RentService
    {
        private const string _baseRentUrl = "/api/rent/";
        private const string _updateRent = "updateRent";
        private const string _getRents = "getRents";

        public static void UpdateRent(RentDto updateRent)
        {
            HttpClientExtenction.PostData(updateRent, string.Concat(_baseRentUrl, _updateRent));
        }

        public static CollectionResult<RentDto> GetRents(RentsFilterParams filterParams)
        {
            var result = HttpClientExtenction.PostDataAndGetResult<RentsFilterParams, CollectionResult<RentDto>>(filterParams, string.Concat(_baseRentUrl, _getRents));
            return result;
        }
    }
}
