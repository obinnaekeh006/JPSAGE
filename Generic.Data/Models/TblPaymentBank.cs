using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPaymentBank
    {
        public TblPaymentBank()
        {
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
        }

        public int PymntBankId { get; set; }
        public string PaymentBankName { get; set; }

        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
    }
}
