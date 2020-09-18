using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblQuotationMasters
    {
        public TblQuotationMasters()
        {
            TblDeliveryInfo = new HashSet<TblDeliveryInfo>();
            TblQuotationApproval = new HashSet<TblQuotationApproval>();
            TblQuotationDetail = new HashSet<TblQuotationDetail>();
            TblQuotationOtherInfo = new HashSet<TblQuotationOtherInfo>();
        }

        public int QuoMasterId { get; set; }
        public int SupplierId { get; set; }
        public string Rfqnumber { get; set; }
        public DateTime QuotationDate { get; set; }
        public string Project { get; set; }
        public string Client { get; set; }
        public string RequestTitle { get; set; }
        public string FormNumber { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblDeliveryInfo> TblDeliveryInfo { get; set; }
        public virtual ICollection<TblQuotationApproval> TblQuotationApproval { get; set; }
        public virtual ICollection<TblQuotationDetail> TblQuotationDetail { get; set; }
        public virtual ICollection<TblQuotationOtherInfo> TblQuotationOtherInfo { get; set; }
    }
}
