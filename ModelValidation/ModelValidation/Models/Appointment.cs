using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    //[NoJoeOnMondays]
    public class Appointment //: IValidatableObject
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        //[FutureDate(ErrorMessage = "Please enter a date in the future")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        //[MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }

        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name!"));
            }

            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter a date in the future"));
            }

            if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("Joe can't book appointments on Mondays!"));
            }

            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms!"));
            }

            return errors;
        }
        */
    }
}