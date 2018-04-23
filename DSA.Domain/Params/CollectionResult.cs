using System.Collections.Generic;

namespace DSA.Domain.Params
{
    public class CollectionResult<T> where T : class
    {
        public IEnumerable<T> Collection { get; set; }

        public int TotalCount { get; set; }
    }
}
