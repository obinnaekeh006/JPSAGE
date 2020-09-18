using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSubsidiaryCompany
    {
        public int SubsidiaryId { get; set; }
        public int SupplierId { get; set; }
        public string SubsidiaryCompanyName { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
