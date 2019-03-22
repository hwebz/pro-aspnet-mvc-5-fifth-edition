using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "[Attribute-Validation] Joe cannot book appointment on Mondays";
        }

        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null)
            {
                // I don't have a model of the right type to validate, or I don't have
                // the values for the ClientName and Date properties I require
                return true;
            }
            return !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}