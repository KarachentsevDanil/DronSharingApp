using AutoMapper;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Residents;
using System;

namespace RCS.BLL.Mapper
{
    public class ResidentAutoMapperProfile : Profile
    {
        public ResidentAutoMapperProfile()
        {
            CreateMap<AddAppointmentDto, Appointment>()
                .ForMember(x => x.AppointmentId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.User, t => t.Ignore());

            CreateMap<AddObservationDto, Observation>()
                .ForMember(x => x.ObservationId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore());

            CreateMap<AddResidentContactDto, ResidentContact>()
                .ForMember(x => x.ResidentContactId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.User, t => t.Ignore());

            CreateMap<AddResidentDoctorDto, ResidentDoctor>()
                .ForMember(x => x.ResidentDoctorId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.Doctor, t => t.Ignore());

            CreateMap<AddResidentDto, Resident>()
                .ForMember(x => x.Photo, t => t.MapFrom(p => Convert.FromBase64String(p.Photo)))
                .ForMember(x => x.ResidentId, t => t.Ignore())
                .ForMember(x => x.Facility, t => t.Ignore())
                .ForMember(x => x.Observations, t => t.Ignore())
                .ForMember(x => x.Contacts, t => t.Ignore())
                .ForMember(x => x.Appointments, t => t.Ignore())
                .ForMember(x => x.Doctors, t => t.Ignore());

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
                .ForMember(x => x.UserName, t => t.MapFrom(p => $"{p.User.FirstName} {p.User.LastName}"));

            CreateMap<Observation, ObservationDto>()
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"));

            CreateMap<ResidentContact, ResidentContactDto>()
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
               .ForMember(x => x.UserName, t => t.MapFrom(p => $"{p.User.FirstName} {p.User.LastName}"));

            CreateMap<ResidentDoctor, ResidentDoctorDto>()
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
               .ForMember(x => x.DoctorName, t => t.MapFrom(p => $"{p.Doctor.FirstName} {p.Doctor.LastName}"));

            CreateMap<Resident, ResidentDto>()
               .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Facility.Name))
               .ForMember(x => x.FullName, t => t.MapFrom(p => $"{p.FirstName} {p.LastName}"))
               .ForMember(x => x.FormattedDate, t => t.MapFrom(p => p.BirthDay.ToShortDateString()))
               .ForMember(x => x.Photo, t => t.MapFrom(p => $"data:image/png;base64,{Convert.ToBase64String(p.Photo)}"));
        }
    }
}
