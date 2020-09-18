using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblTypicalSubcontractedScope
    {
        public TblTypicalSubcontractedScope()
        {
            TblTypicalSubconScopeProducts = new HashSet<TblTypicalSubconScopeProducts>();
        }

        public int SubConScopeId { get; set; }
        public int SupplierId { get; set; }
        public string SubConName { get; set; }
        public string SubConAddress { get; set; }
        public int? CountryId { get; set; }
        public bool? IsLocal { get; set; }

        public virtual TblCountry Country { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblTypicalSubconScopeProducts> TblTypicalSubconScopeProducts { get; set; }
    }
}
