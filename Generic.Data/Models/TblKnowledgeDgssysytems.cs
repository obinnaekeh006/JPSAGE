using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblKnowledgeDgssysytems
    {
        public int KnowDgssysId { get; set; }
        public int SupplierId { get; set; }
        public string ContractNumber { get; set; }
        public int ProdEquSerId { get; set; }
        public DateTime StartDate { get; set; }
        public string Dgsref { get; set; }

        public virtual TblProductEquipmentService ProdEquSer { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
