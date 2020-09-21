using DGSWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.Validations
{
    public class LocalCompanyAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
     "Required for Nigerian Companies ";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (VendorFormViewModel)validationContext.ObjectInstance;
            //var releaseYear = ((DateTime)value).Year;

            if (
                model.CompanyIsForeign != true
                //&& model.SupplierIdentificationTaxClearanceCertificate == null
                && model.SupplierIdentificationCAC == null
                //&& model.SupplierIdentificationCompanyProfile == null
                && model.Hsepolicy == null
                && model.QualityPolicy == null
                && model.TaxIdentificationNumber == null
                && model.IsListed == null
                )
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
