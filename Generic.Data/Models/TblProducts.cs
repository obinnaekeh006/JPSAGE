using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblProducts
    {
        public TblProducts()
        {
            TblForeignCompany = new HashSet<TblForeignCompany>();
            TblTypicalSubconScopeProducts = new HashSet<TblTypicalSubconScopeProducts>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<TblForeignCompany> TblForeignCompany { get; set; }
        public virtual ICollection<TblTypicalSubconScopeProducts> TblTypicalSubconScopeProducts { get; set; }
    }
}
