using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Mark
    {
        public int MarkID { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
