using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Models
{
    //public class Appointment : IValidatableObject // implement this interface for Self-Validation Model
    [NoJoeOnMondays]
    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Remote("ValidateJoe", "Home", AdditionalFields = "Date")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "[Attribute-Validation] Please enter a date")]
        [FutureDate(ErrorMessage = "[Attribute-Validation] Please enter a date in the future")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")] // Type, min, max, errorMessage => have to be true
        [MustBeTrue(ErrorMessage = "[Attribute-Validation] You must accpet the terms")] // custom validation attribute
        public bool TermsAccepted { get; set; }

        // Self-Validation models
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("[Self-Validation Model] Please enter your name"));
            }

            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("[Self-Validation Model] Please enter a date in the future"));
            }

            if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("[Self-Validation Model] Joe cannot book appointments on Mondays"));
            }

            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("[Self-Validation Model] You must accept the terms"));
            }

            return errors;
        }
    }
}