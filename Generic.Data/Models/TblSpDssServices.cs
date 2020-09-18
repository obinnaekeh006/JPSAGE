using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSpDssServices
    {
        public int DssServiceId { get; set; }
        public int ServiceId { get; set; }
        public int SpDssid { get; set; }

        public virtual TblServices Service { get; set; }
        public virtual TblSpDirectServiceScope SpDss { get; set; }
    }
}
