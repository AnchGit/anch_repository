using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cars.Domain.Entities;

namespace Cars.WebUI.Models
{
    public class ShowRoom
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}