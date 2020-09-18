using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblDirectServiceScope
    {
        public int ServiceScopeId { get; set; }
        public string MaterialsName { get; set; }
        public int SubCategoryId { get; set; }

        public virtual TblSubCategory SubCategory { get; set; }
    }
}
