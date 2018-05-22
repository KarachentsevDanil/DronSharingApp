using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Residents;

namespace RCS.BLL.Services
{
    public class ResidentContactService : IResidentContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddResidentContact(AddResidentContactDto data)
        {
            var newItem = AutoMapper.Mapper.Map<AddResidentContactDto, ResidentContact>(data);
            _unitOfWork.ResidentContactRepository.Add(newItem);
            _unitOfWork.Commit();
        }
    }
}
