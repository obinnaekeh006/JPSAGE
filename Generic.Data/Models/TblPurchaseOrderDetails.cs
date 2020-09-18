using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPurchaseOrderDetails
    {
        public int PodetId { get; set; }
        public int PoId { get; set; }
        public string Decsription { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public string DeliveryAddress { get; set; }

        public virtual TblPurchaseOrder Po { get; set; }
    }
}
