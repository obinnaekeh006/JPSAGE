using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblDeliveryInfo
    {
        public int DelInfoId { get; set; }
        public int QuoMasterId { get; set; }
        public string DeliveryAddress { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime RequiredDate { get; set; }

        public virtual TblQuotationMasters QuoMaster { get; set; }
    }
}
