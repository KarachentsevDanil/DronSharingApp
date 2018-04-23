using System.Collections.Generic;

namespace DSA.Domain.Drons
{
    public class DronModel
    {
        public int DronModelId { get; set; }

        public int DronCompanyId { get; set; }

        public int DronTypeId { get; set; }

        public string Name { get; set; }
        
        public byte[] Photo { get; set; }

        public string Description { get; set; }

        public DronCompany DronCompany { get; set; }

        public DronType DronType { get; set; }
        
        public ICollection<Dron> Drons { get; set; }

        public DronModel()
        {
            Drons = new List<Dron>();
        }
    }
}
