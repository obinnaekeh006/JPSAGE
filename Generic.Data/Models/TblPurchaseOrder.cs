using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPurchaseOrder
    {
        public TblPurchaseOrder()
        {
            TblPurchaseCondition = new HashSet<TblPurchaseCondition>();
            TblPurchaseOrderDetails = new HashSet<TblPurchaseOrderDetails>();
        }

        public int PoId { get; set; }
        public int SupplierId { get; set; }
        public string IssuedTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string QuoteRef { get; set; }
        public string Pocode { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblPurchaseCondition> TblPurchaseCondition { get; set; }
        public virtual ICollection<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
    }
}
