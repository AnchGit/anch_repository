using Cars.Domain.Entities;
using Cars.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.WebUI.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }
    }
}