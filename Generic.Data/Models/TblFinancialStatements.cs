using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblFinancialStatements
    {
        public int FinStatId { get; set; }
        public int SupplierId { get; set; }
        public string TaxIdentificationNo { get; set; }
        public string FinancialStatementYear1 { get; set; }
        public string FinancialStatementYear2 { get; set; }
        public string FinancialStatementYear3 { get; set; }
        public string AuditorName { get; set; }
        public string AuditorAddress { get; set; }
        public string ContactNumber { get; set; }
        public bool? IsListed { get; set; }
        public string StockMarketInfo { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
