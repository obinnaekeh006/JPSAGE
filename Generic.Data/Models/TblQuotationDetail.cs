using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblQuotationDetail
    {
        public int QuoDetId { get; set; }
        public int QuoMasterId { get; set; }
        public string Decsription { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public decimal EstimatedCost { get; set; }
        public string DetailedSpec { get; set; }
        public string RefCodeStd { get; set; }
        public string TermsCondition { get; set; }

        public virtual TblQuotationMasters QuoMaster { get; set; }
    }
}
