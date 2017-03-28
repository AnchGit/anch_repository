using Cars.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Cars.Domain.Entities
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int OrderID { get; set; }

        [Required]
        public int CarID { get; set; }
        public virtual Car Car { get; set; }

        [Required]
        public string UserID { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
