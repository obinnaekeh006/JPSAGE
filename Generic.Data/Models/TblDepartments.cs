using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblDepartments
    {
        public TblDepartments()
        {
            TblNumberofEmployees = new HashSet<TblNumberofEmployees>();
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<TblNumberofEmployees> TblNumberofEmployees { get; set; }
        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
    }
}
