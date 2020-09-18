using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblQuotationApproval
    {
        public int QuoAppId { get; set; }
        public int QuoMasterId { get; set; }
        public string BuyerName { get; set; }
        public string ApprovalSignature { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public virtual TblQuotationMasters QuoMaster { get; set; }
    }
}
