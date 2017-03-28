using System.Collections.Generic;

namespace Cars.Domain.Entities
{
    public class Mark
    {
        public int MarkID { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
