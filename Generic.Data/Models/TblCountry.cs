using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblMainCustomers = new HashSet<TblMainCustomers>();
            TblOfficeServiceCl = new HashSet<TblOfficeServiceCl>();
            TblSubContractedDetails = new HashSet<TblSubContractedDetails>();
            TblSupplierOwnership = new HashSet<TblSupplierOwnership>();
            TblTypicalSubcontractedScope = new HashSet<TblTypicalSubcontractedScope>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<TblMainCustomers> TblMainCustomers { get; set; }
        public virtual ICollection<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual ICollection<TblSubContractedDetails> TblSubContractedDetails { get; set; }
        public virtual ICollection<TblSupplierOwnership> TblSupplierOwnership { get; set; }
        public virtual ICollection<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
    }
}
