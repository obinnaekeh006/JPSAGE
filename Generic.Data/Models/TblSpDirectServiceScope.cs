using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSpDirectServiceScope
    {
        public TblSpDirectServiceScope()
        {
            TblSpDssServices = new HashSet<TblSpDssServices>();
        }

        public int SpDssId { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblSpDssServices> TblSpDssServices { get; set; }
    }
}
