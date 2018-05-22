﻿namespace RCS.BLL.Dto.Facilities
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FacilityId { get; set; }

        public int DoctorSpecializationId { get; set; }

        public string FacilityName { get; set; }

        public string Specialization { get; set; }
    }
}
