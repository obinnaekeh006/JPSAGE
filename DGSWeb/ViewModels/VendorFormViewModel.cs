using DGSWeb.Validations;
using Generic.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.ViewModels
{
    public class VendorFormViewModel 
    {
        public string ModelError { get; set; }

        public List<TblCountry> Countries { get; set; }
        public List<TblSubCategory> SubCategories { get; set; }
        public List<TblProducts> Products { get; set; }
        public List<TblCity> Cities { get; set; }
        public List<TblServices> Services { get; set; }
        public List<TblDepartments> Departments { get; set; }

        public bool FormSuccess { get; set; }

        public List<SelectListItem> StatusList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Agent","1"),
            new SelectListItem("Dist", "2")
        };

        public List<SelectListItem> KDGSSType { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Product","1"),
            new SelectListItem("Equipment", "2"),
            new SelectListItem("Service", "3")
        };

        public List<SelectListItem> MainCustomersType { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Product","1"),
            new SelectListItem("Service", "2")
        };

        public List<SelectListItem> MainCustomersValue { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Value-2016","1"),
            new SelectListItem("Value-2017", "2"),
            new SelectListItem("Value-2018", "3")
        };

        public List<SelectListItem> FinancialTurnOvers { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("0-10 million","1"),
            new SelectListItem("10-25 million", "2"),
            new SelectListItem("25 million and above", "3")
        };

        public int VendorApprovalId { get; set; }
        public int SupplierId { get; set; }
        public int FormId { get; set; }
        public string VendorUsername { get; set; }
        public string ApprovedBy { get; set; }

        /*Form Identification*/

        //public int FormId { get; set; }
        [Required(ErrorMessage = "Form Identification is required.")]
        public string FormIdentificationName { get; set; }
        [Required]
        public string FormIdentificationPosition { get; set; }
        [Required]
        public string FormIdentificationPhoneNumber { get; set; }
        [Required]
        public string FormIdentificationWorkPhoneNumber { get; set; }
        [Required]
        public string FormIdentificationEmailAddress { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1754", "1/1/9999",
        ErrorMessage = "Date out of Range")]
        public DateTime? FormIdentificationDate { get; set; }



        /*Supplier Identification*/

        //public int SupplierId { get; set; }
        //public int FormId { get; set; }
        [Required]
        public string SupplierIdentificationCompanyName { get; set; }
        [LocalCompany]
        public bool CompanyIsForeign { get; set; }
        //public int SubsidiaryId { get; set; }
        //[Required]
        public string SupplierIdentificationSubsidiaryCompanyName1 { get; set; }
        //[Required]
        public string SupplierIdentificationSubsidiaryCompanyName2 { get; set; }
        //[Required]
        public string SupplierIdentificationSubsidiaryCompanyName3 { get; set; }
        [Required]
        public string SupplierIdentificationHeadOfficeAddress { get; set; }
        [Required]
        public string SupplierIdentificationCompanyRegNumber { get; set; }
        [Required]
        [BindProperty]
        public IFormFile SupplierIdentificationTaxClearanceCertificate { get; set; }
        //[Required]
        //[BindProperty]
        public IFormFile SupplierIdentificationBankReference { get; set; }
        //[Required]
        //[BindProperty]
        public IFormFile SupplierIdentificationThirdPartyReference { get; set; }
        //public int ContactPersonId { get; set; }
        public int MainContactPersonId { get; set; }
        [Required]
        public string MainContactPersonName { get; set; }
        [Required]
        public string MainContactPosition { get; set; }
        [Required]
        public string MainContactPhoneNumber { get; set; }
        [Required]
        public string MainContactWorkPhoneNumber { get; set; }
        [Required]
        public string MainContactEmailAddress { get; set; }
        //public int TprId { get; set; }
        public int TprId { get; set; }
        //[Required]
        public string TprName { get; set; }
        //[Required]
        public string TprOrganization { get; set; }
        //[Required]
        public string TprAddress { get; set; }
        //[Required]
        public string TprPhoneNumber { get; set; }
        //[Required]
        public string TprWorkPhoneNumber { get; set; }
        //[Required]
        public string TprEmailAddress { get; set; }
        [Required]
        [BindProperty]
        public IFormFile SupplierIdentificationCompanyProfile { get; set; }
        //[Required]
        [MaxLength(20)]
        public string SupplierIdentificationCAC { get; set; }
        //[Required]
        public string SupplierIdentificationCompanyWebsiteUrl { get; set; }


        /*Supplier Profile*/
        //public int SupplierProfileId { get; set; }
        //public int SupplierId { get; set; }
        [Required]
        public string NatureOfBusiness { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1754", "1/1/9999",
        ErrorMessage = "Date out of Range")]
        public DateTime? DateofCreation { get; set; }
        [BindProperty]
        //[Required]
        public IFormFile CodeOfConduct { get; set; }

        //public int OwnershipId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        public string MainShareholder1 { get; set; }
        //[Required]
        public decimal Shareholding1 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId1 { get; set; }
        //[Required]
        public string MainShareholder2 { get; set; }
        //[Required]
        public decimal Shareholding2 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId2 { get; set; }
        //[Required]
        public string MainShareholder3 { get; set; }
        //[Required]
        public decimal Shareholding3 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId3 { get; set; }
        //[Required]
        public string MainShareholder4 { get; set; }
        //[Required]
        public decimal Shareholding4 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId4 { get; set; }
        //[Required]
        public string MainShareholder5 { get; set; }
        //[Required]
        public decimal Shareholding5 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId5 { get; set; }
        //[Required]
        public string MainShareholder6 { get; set; }
        //[Required]
        public decimal Shareholding6 { get; set; }
        //[Required]
        public int? SupplierOwnershipCountryId6 { get; set; }
        //public int ServiceScopeId { get; set; }
        //[Required]
        public string MaterialsName1 { get; set; }
        //[Required]
        public string SubCategoryId1 { get; set; }
        //[Required]
        public string MaterialsName2 { get; set; }
        //[Required]
        public string SubCategoryId2 { get; set; }
        //[Required]
        public string MaterialsName3 { get; set; }
        //[Required]
        public string SubCategoryId3 { get; set; }
        //[Required]
        public string MaterialsName4 { get; set; }
        //[Required]
        public string SubCategoryId4 { get; set; }
        //[Required]
        public string MaterialsName5 { get; set; }
        //[Required]
        public string SubCategoryId5 { get; set; }
        //[Required]
        public string MaterialsName6 { get; set; }
        //[Required]
        public string SubCategoryId6 { get; set; }
        //[Required]
        public string MaterialsName7 { get; set; }
        //[Required]
        public string SubCategoryId7 { get; set; }

        //public int? SupplierId { get; set; }
        //public int SubConScopeId { get; set; }
        //[Required]
        public string TypicalSubConName1 { get; set; }
        //[Required]
        public string TypicalSubConAddress1 { get; set; }
        //[Required]
        public int? TypicalSubConCountryId1 { get; set; }

        public bool TypicalSubConIsLocal1 { get; set; }
        //[Required]
        public string TypicalSubConName2 { get; set; }
        //[Required]
        public string TypicalSubConAddress2 { get; set; }
        //[Required]
        public int? TypicalSubConCountryId2 { get; set; }

        public bool TypicalSubConIsLocal2 { get; set; }
        //[Required]
        public string TypicalSubConName3 { get; set; }
        //[Required]
        public string TypicalSubConAddress3 { get; set; }
        //[Required]
        public int? TypicalSubConCountryId3 { get; set; }

        public bool TypicalSubConIsLocal3 { get; set; }

        //public int ScsProdId { get; set; }
        //public int ProductId { get; set; }
        public int ProductId { get; set; }
        //[Required]
        public string ProductName1 { get; set; }
        //[Required]
        public string ProductName2 { get; set; }
        //[Required]
        public string ProductName3 { get; set; }
        public int? SubConScopeId { get; set; }

        //public int CyMfgFfId { get; set; }
        //[Required]
        public string CyMfgFfLocation1 { get; set; }
        //[Required]
        public int? CyMfgFfCityId1 { get; set; }
        //[Required]
        public string CyMfgFfPlantsEquipmentType1 { get; set; }
        //[Required]
        public int CyMfgFfPlantsEquipmentNumber1 { get; set; }
        //[Required]
        public string CyMfgFfUtilization1 { get; set; }
        //[Required]
        public decimal CyMfgFfFactoryArea1 { get; set; }
        //[Required]
        public string CyMfgFfLocation2 { get; set; }
        //[Required]
        public int? CyMfgFfCityId2 { get; set; }
        //[Required]
        public string CyMfgFfPlantsEquipmentType2 { get; set; }
        //[Required]
        public int CyMfgFfPlantsEquipmentNumber2 { get; set; }
        //[Required]
        public string CyMfgFfUtilization2 { get; set; }
        //[Required]
        public decimal CyMfgFfFactoryArea2 { get; set; }
        //[Required]
        public string CyMfgFfLocation3 { get; set; }
        //[Required]
        public int? CyMfgFfCityId3 { get; set; }
        //[Required]
        public string CyMfgFfPlantsEquipmentType3 { get; set; }
        //[Required]
        public int CyMfgFfPlantsEquipmentNumber3 { get; set; }
        //[Required]
        public string CyMfgFfUtilization3 { get; set; }
        //[Required]
        public decimal CyMfgFfFactoryArea3 { get; set; }
        //[Required]
        public string CyMfgFfLocation4 { get; set; }
        //[Required]
        public int? CyMfgFfCityId4 { get; set; }
        //[Required]
        public string CyMfgFfPlantsEquipmentType4 { get; set; }
        //[Required]
        public int CyMfgFfPlantsEquipmentNumber4 { get; set; }
        //[Required]
        public string CyMfgFfUtilization4 { get; set; }
        //[Required]
        public decimal CyMfgFfFactoryArea4 { get; set; }
        //public int? SupplierId { get; set; }
        public int SpDssId { get; set; }
        //[Required]
        public string SpDssDescription1 { get; set; }
        //[Required]
        public string SpDssDescription2 { get; set; }
        //[Required]
        public string SpDssDescription3 { get; set; }
        public int DssServiceId { get; set; }
        public int SpDssServiceId { get; set; }
        //public int SpDssid { get; set; }
        //public int OfficeServClId { get; set; }
        //[Required]
        public string SpServices1 { get; set; }
        //[Required]
        public string SpServices2 { get; set; }
        //[Required]
        public string SpServices3 { get; set; }
        //[Required]
        public string OfficeServClLocation1 { get; set; }
        //[Required]
        public int? OfficeServClCityId1 { get; set; }
        //[Required]
        public int? OfficeServClCountryId1 { get; set; }
        //[Required]
        public string OfficeServClLocation2 { get; set; }
        //[Required]
        public int? OfficeServClCityId2 { get; set; }
        //[Required]
        public int? OfficeServClCountryId2 { get; set; }
        //[Required]
        public string OfficeServClLocation3 { get; set; }
        //[Required]
        public int? OfficeServClCityId3 { get; set; }
        //[Required]
        public int? OfficeServClCountryId3 { get; set; }
        //[Required]
        public string OfficeServClLocation4 { get; set; }
        //[Required]
        public int? OfficeServClCityId4 { get; set; }
        //[Required]
        public int? OfficeServClCountryId4 { get; set; }
        //[Required]
        public int OfficeServClSupplierId { get; set; }
        public int SubServId { get; set; }
        //[Required]
        public string SubConServiceName { get; set; }

        public int SubConServiceId { get; set; }
        //[Required]
        public decimal SubConPercentageOutsourced { get; set; }
        //public int SupplierId { get; set; }
        public int SubConId { get; set; }
        //public int SubServId { get; set; }
        //[Required]
        public string SubConName { get; set; }
        //[Required]
        public string SubConAddress { get; set; }
        //[Required]
        public int? SubConCountryId { get; set; }

        public bool IsLocal { get; set; }
        public int ForComId { get; set; }
        //[Required]
        public string ForeignCompanyName { get; set; }
        //[Required]
        public string ProductSupplied { get; set; }
        //[Required]
        public int? Status { get; set; }
        public string Others { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile SupplierProfileOrganizationCharts { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile SupplierProfileMissionVisionStatement { get; set; }




        /*Business Experience*/
        public int BizConPolId { get; set; }
        [BindProperty]
        public string HasBusinessConPolicy { get; set; }
        public bool HasBizConPolicy { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile BizConPolicy { get; set; }
        public int KnowDgssysId { get; set; }
        //[Required]
        public string KDGSContractNumber { get; set; }
        public int KDGSProdEquSerId { get; set; }
        [Range(typeof(DateTime), "1/1/1754", "1/1/9999",
         ErrorMessage = "Date out of Range")]
        public DateTime? KDGSStartDate { get; set; }
        //[Required]
        public string Dgsref { get; set; }

        public int ProdEquSerId { get; set; }
        //[Required]
        public int ProdEquSerType { get; set; }
        //[Required]
        public string ProdEquSerDescription { get; set; }

        public int CustomerId { get; set; }
        //[Required]
        public string CustomerName { get; set; }
        //[Required]
        public int CustomerCountryId { get; set; }
        //[Required]
        public int CustomerProdEquSerId { get; set; }
        //[Required]
        public int ValueId { get; set; }
        //public int SupplierId { get; set; }
        [Required]
        [FinancialTurnover]
        public string FinancialTurnOver { get; set; }



        public string CompanyWorkedWith1 { get; set; }
        public string TimeFrame1 { get; set; }
        [BindProperty]
        public IFormFile TransactionReference1 { get; set; }
        public string ScopeCovered1 { get; set; }

        public string CompanyWorkedWith2 { get; set; }
        public string TimeFrame2 { get; set; }
        [BindProperty]
        public IFormFile TransactionReference2 { get; set; }
        public string ScopeCovered2 { get; set; }



        /*Staff Strength & Competences*/
        //public int SupplierId { get; set; }
        //public int DepartmentId { get; set; }
        //[Required]
        public int NoOfEmployees1 { get; set; }
        //[Required]
        public int NoOfContractEmp1 { get; set; }
        //[Required]
        public int NoOfExpatriates1 { get; set; }

        //public int DepartmentId { get; set; }
        //public string DepartmentName { get; set; }


        //public int SupplierId { get; set; }
        //public int DepartmentId { get; set; }
        //[Required]
        public int NoOfEmployees2 { get; set; }
        //[Required]
        public int NoOfContractEmp2 { get; set; }
        //[Required]
        public int NoOfExpatriates2 { get; set; }

        //[Required]
        public int NoOfEmployees3 { get; set; }
        //[Required]
        public int NoOfContractEmp3 { get; set; }
        //[Required]
        public int NoOfExpatriates3 { get; set; }
        //[Required]
        public int NoOfEmployees4 { get; set; }
        //[Required]
        public int NoOfContractEmp4 { get; set; }
        //[Required]
        public int NoOfExpatriates4 { get; set; }

        //[Required]
        public int NoOfEmployees5 { get; set; }
        //[Required]
        public int NoOfContractEmp5 { get; set; }
        //[Required]
        public int NoOfExpatriates5 { get; set; }
        //[Required]
        public int NoOfEmployees6 { get; set; }
        //[Required]
        public int NoOfContractEmp6 { get; set; }
        //[Required]
        public int NoOfExpatriates6 { get; set; }
        //[Required]
        public int NoOfEmployees7 { get; set; }
        //[Required]
        public int NoOfContractEmp7 { get; set; }
        //[Required]
        public int NoOfExpatriates7 { get; set; }
        //[Required]
        public int NoOfEmployees8 { get; set; }
        //[Required]
        public int NoOfContractEmp8 { get; set; }
        //[Required]
        public int NoOfExpatriates8 { get; set; }
        //[Required]

        public int NoOfEmployees9 { get; set; }
        //[Required]
        public int NoOfContractEmp9 { get; set; }
        //[Required]
        public int NoOfExpatriates9 { get; set; }

        //[Required]
        [BindProperty]
        public IFormFile StaffPolicy { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile Audit3rdParty { get; set; }



        /*Financials*/
        public int FinStatId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        
        public string FinancialStatement { get; set; }
        
        public string FinancialStatementError { get; set; }

        //[Required]
        [BindProperty]
        public IFormFile FinancialStatement1 { get; set; }

        [BindProperty]
        public IFormFile FinancialStatement2 { get; set; }

        [BindProperty]
        public IFormFile FinancialStatement3 { get; set; }


        //[Required]
        [BindProperty]
        public IFormFile AnnualReport { get; set; }
        public int FinAudId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile FinancialAudit { get; set; }
        //[Required]
        public string TaxIdentificationNumber { get; set; }

        //[Required]
        public string AuditorName { get; set; }
        //[Required]
        public string AuditorAddress { get; set; }
        //[Required]
        public string AuditorContactNumber { get; set; }
        //public int StockMktInfoId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile StockMktInfo { get; set; }

        [BindProperty]
        public string IsListed { get; set; }
        public string[] InStockMarket = new[] { "True", "False" };

        //public string IsListed { get; set; }

        



        /*Quality Certification*/
        public int QualMgtId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile QualityPolicy { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile ProductQualMgt { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile QualityMgt { get; set; }
        //[Required]
        public string QualManagerName { get; set; }
        //[Required]
        public string QualManagerEmail { get; set; }
        //[Required]
        public string QualManagerPhoneNumber { get; set; }
        //[Required]
        public string QualManagerWorkPhoneNumber { get; set; }
        //[Required]
        public string QualManagerFax { get; set; }
        public int QualCertId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        public string QualCertDetails { get; set; }
        //[Required]
        public string NameofCertificate { get; set; }
        public int CertOrgId { get; set; }
        //[Required]
        public string CertOrgName { get; set; }
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Range(typeof(DateTime), "1/1/1754", "1/1/9999",
         ErrorMessage = "Date out of Range")]
        public DateTime? ValidityDate { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile CertificateCopy { get; set; }



        /*Health Safety Environment*/
        public int HseId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile Hsepolicy { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile HseThirdPartyAudit { get; set; }
        //[Required]
        public string HseManagerName { get; set; }
        //[Required]
        public string HseManagerEmail { get; set; }
        //[Required]
        public string HsePhoneNumber { get; set; }
        //[Required]
        public string HseWorkPhoneNumber { get; set; }
        //[Required]
        public string HseFax { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile HseCompanyKpi { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile HseYearN1results { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile HseStaffTraining { get; set; }
        public int HseCertId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        public string HseNameofCertificate { get; set; }
        //public int CertOrgId { get; set; }
        //[Required]
        public string HseCertOrgName { get; set; }
        //[Required]
        [Range(typeof(DateTime), "1/1/1754", "1/1/9999",
         ErrorMessage = "Date out of Range")]
        public DateTime? HseValidityDate { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile HseCertificateCopy { get; set; }


        /*Corporate Distinctives*/
        public int CorpDisId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        public string Details1 { get; set; }
        //[Required]
        public string Details2 { get; set; }
        //[Required]
        public string Details3 { get; set; }
        //[Required]
        public string Details4 { get; set; }
        //[Required]
        public string Details5 { get; set; }        




        /*Corporate Social Responsibility*/
        public int CsrId { get; set; }
        //public int SupplierId { get; set; }
        //[Required]
        [BindProperty]
        public List<IFormFile> SrethHumanLaborLaws { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile ThirdPartySocAudit { get; set; }
        //[Required]
        [BindProperty]
        public IFormFile FraudMalpracticePolicy { get; set; }



    }
}
