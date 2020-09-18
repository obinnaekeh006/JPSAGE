using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblStaffStrengthComp
    {
        public TblStaffStrengthComp()
        {
            TblNumberofEmployees = new HashSet<TblNumberofEmployees>();
        }

        public int StaffStrCompId { get; set; }
        public int SupplierId { get; set; }
        public string StaffPolicy { get; set; }
        public string Audit3rdParty { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblNumberofEmployees> TblNumberofEmployees { get; set; }
    }
}
