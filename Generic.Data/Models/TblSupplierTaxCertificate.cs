using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSupplierTaxCertificate
    {
        public int TaxCertId { get; set; }
        public int SupplierId { get; set; }
        public string TaxCertificate { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
