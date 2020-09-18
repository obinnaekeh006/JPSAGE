using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblQuotationOtherInfo
    {
        public int OtherInfoId { get; set; }
        public int QuoMasterId { get; set; }
        public bool SparesRequired { get; set; }
        public string AsservicesRq { get; set; }
        public string DataSheet { get; set; }
        public string Mto { get; set; }
        public string Details { get; set; }

        public virtual TblQuotationMasters QuoMaster { get; set; }
    }
}
