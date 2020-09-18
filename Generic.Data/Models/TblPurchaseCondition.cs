using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPurchaseCondition
    {
        public int PoconId { get; set; }
        public int PoId { get; set; }
        public string PreparedBy { get; set; }
        public DateTime Pbdate { get; set; }
        public string Pbsignature { get; set; }
        public string CheckedBy { get; set; }
        public DateTime Cbdate { get; set; }
        public string Cbsignature { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime Abdate { get; set; }
        public string Absignature { get; set; }

        public virtual TblPurchaseOrder Po { get; set; }
    }
}
