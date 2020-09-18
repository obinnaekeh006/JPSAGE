using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblNumberofEmployees
    {
        public int NoofEmpId { get; set; }
        public int? StaffStrCompId { get; set; }
        public int? DepartmentId { get; set; }
        public int? NoOfEmployees { get; set; }
        public int? NoOfContractEmp { get; set; }
        public int? NoOfExpatriates { get; set; }

        public virtual TblDepartments Department { get; set; }
        public virtual TblStaffStrengthComp StaffStrComp { get; set; }
    }
}
