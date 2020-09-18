using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblProductEquipmentService
    {
        public TblProductEquipmentService()
        {
            TblKnowledgeDgssysytems = new HashSet<TblKnowledgeDgssysytems>();
        }

        public int ProdEquSerId { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblKnowledgeDgssysytems> TblKnowledgeDgssysytems { get; set; }
    }
}
