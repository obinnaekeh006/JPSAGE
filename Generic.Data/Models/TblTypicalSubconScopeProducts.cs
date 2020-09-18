using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblTypicalSubconScopeProducts
    {
        public int ScsProdId { get; set; }
        public int ProductId { get; set; }
        public int? SubConScopeId { get; set; }

        public virtual TblProducts Product { get; set; }
        public virtual TblTypicalSubcontractedScope SubConScope { get; set; }
    }
}
