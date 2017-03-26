using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cars.Domain.Entities;

namespace Cars.WebUI.Models
{
    public class CarCount
    {
        public Car Car { get; set; }
        public int Amount { get; set; }
    }
}