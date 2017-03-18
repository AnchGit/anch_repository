using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }

        public int MarkID { get; set; }

        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Engine { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Price { get; set; }
    }
}
