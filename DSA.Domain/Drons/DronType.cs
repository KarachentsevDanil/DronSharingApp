using System.Collections.Generic;

namespace DSA.Domain.Drons
{
    public class DronType
    {
        public int DronTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<DronModel> Drons { get; set; }

        public DronType()
        {
            Drons = new List<DronModel>();
        }
    }
}
