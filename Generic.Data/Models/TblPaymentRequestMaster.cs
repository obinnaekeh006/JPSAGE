using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblPaymentRequestMaster
    {
        public TblPaymentRequestMaster()
        {
            TblPaymentRequestDetails = new HashSet<TblPaymentRequestDetails>();
        }

        public int PayReqMasterId { get; set; }
        public int PymntBankId { get; set; }
        public int SupplierId { get; set; }
        public string Payee { get; set; }
        public string AccountNumber { get; set; }
        public int DepartmentProject { get; set; }
        public DateTime PayReqDate { get; set; }
        public string Ponumber { get; set; }
        public string PayReqNumber { get; set; }

        public virtual TblDepartments DepartmentProjectNavigation { get; set; }
        public virtual TblPaymentBank PymntBank { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblPaymentRequestDetails> TblPaymentRequestDetails { get; set; }
    }
}
