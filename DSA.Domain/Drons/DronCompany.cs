using System.Collections.Generic;

namespace DSA.Domain.Drons
{
    public class DronCompany
    {
        public int DronCompanyId { get; set; }

        public string Name { get; set; }

        public ICollection<DronModel> Drons { get; set; }

        public DronCompany()
        {
            Drons = new List<DronModel>();
        }
    }
}
