﻿using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblCorpSocialResponsibility
    {
        public int CsrId { get; set; }
        public int SupplierId { get; set; }
        public string SrethHumanLaborLaws { get; set; }
        public string ThirdPartySocAudit { get; set; }
        public string FraudMalpracticePolicy { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
