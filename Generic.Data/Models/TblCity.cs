using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblCyMfgFf = new HashSet<TblCyMfgFf>();
            TblOfficeServiceCl = new HashSet<TblOfficeServiceCl>();
        }

        public int CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<TblCyMfgFf> TblCyMfgFf { get; set; }
        public virtual ICollection<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
    }
}
