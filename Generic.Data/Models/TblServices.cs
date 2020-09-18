using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblServices
    {
        public TblServices()
        {
            TblSpDssServices = new HashSet<TblSpDssServices>();
            TblSubContractedServices = new HashSet<TblSubContractedServices>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<TblSpDssServices> TblSpDssServices { get; set; }
        public virtual ICollection<TblSubContractedServices> TblSubContractedServices { get; set; }
    }
}
