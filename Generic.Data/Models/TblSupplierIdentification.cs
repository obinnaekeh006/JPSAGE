using System;
using System.Collections.Generic;

namespace Generic.Data.Models
{
    public partial class TblSupplierIdentification
    {
        public TblSupplierIdentification()
        {
            TblApproval = new HashSet<TblApproval>();
            TblBusinessExperience = new HashSet<TblBusinessExperience>();
            TblCorpSocialResponsibility = new HashSet<TblCorpSocialResponsibility>();
            TblCorporateDistinctives = new HashSet<TblCorporateDistinctives>();
            TblCyMfgFf = new HashSet<TblCyMfgFf>();
            TblFinancialStatements = new HashSet<TblFinancialStatements>();
            TblForeignCompany = new HashSet<TblForeignCompany>();
            TblHealthSafetyEnvironment = new HashSet<TblHealthSafetyEnvironment>();
            TblHseCertification = new HashSet<TblHseCertification>();
            TblKnowledgeDgssysytems = new HashSet<TblKnowledgeDgssysytems>();
            TblMainCustomers = new HashSet<TblMainCustomers>();
            TblOfficeServiceCl = new HashSet<TblOfficeServiceCl>();
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
            TblQualityCertification = new HashSet<TblQualityCertification>();
            TblQualityManagement = new HashSet<TblQualityManagement>();
            TblQuotationMasters = new HashSet<TblQuotationMasters>();
            TblSpDirectServiceScope = new HashSet<TblSpDirectServiceScope>();
            TblStaffStrengthComp = new HashSet<TblStaffStrengthComp>();
            TblSubCategory = new HashSet<TblSubCategory>();
            TblSubContractedServices = new HashSet<TblSubContractedServices>();
            TblSubsidiaryCompany = new HashSet<TblSubsidiaryCompany>();
            TblSupplierOwnership = new HashSet<TblSupplierOwnership>();
            TblSupplierProfile = new HashSet<TblSupplierProfile>();
            TblSupplierTaxCertificate = new HashSet<TblSupplierTaxCertificate>();
            TblTypicalSubcontractedScope = new HashSet<TblTypicalSubcontractedScope>();
        }

        public int SupplierId { get; set; }
        public int? FormId { get; set; }
        public string CompanyName { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string CompanyRegNumber { get; set; }
        public int? ContactPersonId { get; set; }
        public string BankReference { get; set; }
        public string ThirdPartyReference { get; set; }
        public int? TprId { get; set; }
        public string CompanyProfile { get; set; }
        public string CompanyWebsiteUrl { get; set; }
        public string CorporateAffairsCommisionNo { get; set; }

        public virtual TblContactPersons ContactPerson { get; set; }
        public virtual TblFormIdentification Form { get; set; }
        public virtual TblThirdPartyReference Tpr { get; set; }
        public virtual ICollection<TblApproval> TblApproval { get; set; }
        public virtual ICollection<TblBusinessExperience> TblBusinessExperience { get; set; }
        public virtual ICollection<TblCorpSocialResponsibility> TblCorpSocialResponsibility { get; set; }
        public virtual ICollection<TblCorporateDistinctives> TblCorporateDistinctives { get; set; }
        public virtual ICollection<TblCyMfgFf> TblCyMfgFf { get; set; }
        public virtual ICollection<TblFinancialStatements> TblFinancialStatements { get; set; }
        public virtual ICollection<TblForeignCompany> TblForeignCompany { get; set; }
        public virtual ICollection<TblHealthSafetyEnvironment> TblHealthSafetyEnvironment { get; set; }
        public virtual ICollection<TblHseCertification> TblHseCertification { get; set; }
        public virtual ICollection<TblKnowledgeDgssysytems> TblKnowledgeDgssysytems { get; set; }
        public virtual ICollection<TblMainCustomers> TblMainCustomers { get; set; }
        public virtual ICollection<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual ICollection<TblQualityCertification> TblQualityCertification { get; set; }
        public virtual ICollection<TblQualityManagement> TblQualityManagement { get; set; }
        public virtual ICollection<TblQuotationMasters> TblQuotationMasters { get; set; }
        public virtual ICollection<TblSpDirectServiceScope> TblSpDirectServiceScope { get; set; }
        public virtual ICollection<TblStaffStrengthComp> TblStaffStrengthComp { get; set; }
        public virtual ICollection<TblSubCategory> TblSubCategory { get; set; }
        public virtual ICollection<TblSubContractedServices> TblSubContractedServices { get; set; }
        public virtual ICollection<TblSubsidiaryCompany> TblSubsidiaryCompany { get; set; }
        public virtual ICollection<TblSupplierOwnership> TblSupplierOwnership { get; set; }
        public virtual ICollection<TblSupplierProfile> TblSupplierProfile { get; set; }
        public virtual ICollection<TblSupplierTaxCertificate> TblSupplierTaxCertificate { get; set; }
        public virtual ICollection<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
    }
}
