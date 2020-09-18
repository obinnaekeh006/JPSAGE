using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblApproval
    {
        public int ApprovalId { get; set; }
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public string Signature { get; set; }
        public DateTime ApprovalDate { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
