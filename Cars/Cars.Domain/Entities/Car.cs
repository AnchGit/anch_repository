using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cars.Domain.Entities
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int CarID { get; set; }

        [Required(ErrorMessage = "Please select a mark name")]
        public int MarkID { get; set; }

        public virtual Mark Mark { get; set; }

        [Required(ErrorMessage = "Please enter a model name")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please enter a engine power")]
        [Range(0.01, double.MaxValue)]
        public decimal Engine { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a issue date")]
        public DateTime IssueDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required]
        [UIHint("Boolean")]
        public bool? IsAvailable { get; set; }

        public virtual Order Order { get; set; }
    }
}
