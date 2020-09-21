using DGSWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.Validations
{
    public class DateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
           ValidationContext validationContext)
        {
            var model = (VendorFormViewModel)validationContext.ObjectInstance;
            //var releaseYear = ((DateTime)value).Year;
            if(model.ValidityDate != null && ( model.ValidityDate.Value.Year < 1753 || model.ValidityDate.Value.Year > 9999))
            {
                model.ValidityDate = null;
            }
            if ( model.HseValidityDate != null && (model.HseValidityDate.Value.Year < 1753 || model.HseValidityDate.Value.Year > 9999))
            {
                model.HseValidityDate = null;
            }


            return ValidationResult.Success;
        }
    }
}
