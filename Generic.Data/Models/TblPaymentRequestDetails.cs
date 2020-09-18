using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPaymentRequestDetails
    {
        public int PayReqDetId { get; set; }
        public int PayReqMasterId { get; set; }
        public string Description { get; set; }
        public string GlaccountCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string AmountInWords { get; set; }
        public string PreparedBy { get; set; }
        public DateTime Pbdate { get; set; }
        public string Pbsignature { get; set; }
        public string CheckedBy { get; set; }
        public DateTime Cbdate { get; set; }
        public string Cbsignature { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime Abdate { get; set; }
        public string Absignature { get; set; }

        public virtual TblPaymentRequestMaster PayReqMaster { get; set; }
    }
}
