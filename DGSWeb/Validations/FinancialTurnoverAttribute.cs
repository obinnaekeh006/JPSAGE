using DGSWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.Validations
{
    public class FinancialTurnoverAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
       "Required for Companies with Turnover of over Ten million.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (VendorFormViewModel)validationContext.ObjectInstance;
            //var releaseYear = ((DateTime)value).Year;

            if (model.FinancialTurnOver != 1 && model.FinancialStatement1 == null && model.FinancialStatement2 == null && model.FinancialStatement3 == null)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
