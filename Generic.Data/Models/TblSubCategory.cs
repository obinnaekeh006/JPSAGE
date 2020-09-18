﻿using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSubCategory
    {
        public TblSubCategory()
        {
            TblDirectServiceScope = new HashSet<TblDirectServiceScope>();
        }

        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int? SupplierId { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblDirectServiceScope> TblDirectServiceScope { get; set; }
    }
}
