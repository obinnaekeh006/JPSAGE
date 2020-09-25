using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using DGSWeb.Email;
using DGSWeb.ViewModels;
using Generic.Dapper.Interfaces;
using Generic.Dapper.UnitOfWork;
using Generic.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGSWeb.Controllers
{
    public class VendorController : Controller
    {
        private readonly IRepository<TblCountry> _countryRepository;
        private readonly IRepository<TblSubCategory> _subCategoryRepository;
        private readonly IRepository<TblProducts> _productsRepository;
        private readonly IRepository<TblCity> _cityRepository;
        private readonly IRepository<TblServices> _servicesRepository;
        private readonly IRepository<TblDepartments> _departmentsRepository;
        private readonly IRepository<TblFormIdentification> _formIdentificationRepository;
        private readonly IRepository<TblSupplierIdentification> _supplierIdentificationRepository;
        private readonly IRepository<TblSubsidiaryCompany> _subsidiaryCompanyRepository;
        private readonly IRepository<TblSupplierTaxCertificate> _supplierTaxCertificateRepository;
        private readonly IRepository<TblContactPersons> _contactPersonsRepository;
        private readonly IRepository<TblThirdPartyReference> _thirdPartyReferenceRepository;
        private readonly IRepository<TblSupplierProfile> _supplierProfileRepository;
        private readonly IRepository<TblSupplierOwnership> _supplierOwnershipRepository;
        private readonly IRepository<TblDirectServiceScope> _directServiceScopeRepository;
        private readonly IRepository<TblTypicalSubcontractedScope> _typicalSubcontractedScopeRepository;
        private readonly IRepository<TblTypicalSubconScopeProducts> _typicalSubcontractedScopeProductsRepository;
        private readonly IRepository<TblCyMfgFf> _cYMFGFFRepository;
        private readonly IRepository<TblSpDirectServiceScope> _spDirectServiceScopeRepository;
        private readonly IRepository<TblSpDssServices> _spDssServicesRepository;
        private readonly IRepository<TblOfficeServiceCl> _officeServiceClRepository;
        private readonly IRepository<TblSubContractedServices> _subContractedServicesRepository;
        private readonly IRepository<TblSubContractedDetails> _subContractedDetailsRepository;
        private readonly IRepository<TblForeignCompany> _foreignCompanyRepository;
        private readonly IRepository<TblBusinessExperience> _businessExperienceRepository;

        //private readonly IRepository<TblBusinessContinuityPolicy> _businessContinuityPolicyRepository;
        //private readonly IRepository<TblKnowledgeDgssysytems> _knowledgeDgssystemsRepository;
        private readonly IRepository<TblProductEquipmentService> _productEquipmentServiceRepository;
        private readonly IRepository<TblMainCustomers> _mainCustomersRepository;
        private readonly IRepository<TblNumberofEmployees> _numberOfEmployeesRepository;
        private readonly IRepository<TblStaffStrengthComp> _staffStrCompRepository;
        private readonly IRepository<TblFinancialStatements> _financialStatementsRepository;
        //private readonly IRepository<TblFinancialAudits> _financialAuditsRepository;
        //private readonly IRepository<TblFinStockMarketInfo> _finStockMarketInfoRepository;
        private readonly IRepository<TblQualityManagement> _qualityManagementRepository;
        private readonly IRepository<TblQualityCertification> _qualityCertificationRepository;
        private readonly IRepository<TblCertifyingOrg> _certifyingOrgRepository;
        private readonly IRepository<TblHealthSafetyEnvironment> _hseRepository;
        private readonly IRepository<TblHseCertification> _hseCertificationRepository;
        private readonly IRepository<TblCorporateDistinctives> _corporateDistinctivesRepository;
        private readonly IRepository<TblCorpSocialResponsibility> _corpSocialResponsiblityRepository;
        private readonly IRepository<TblVendorRegFormApproval> _vendorRegFormApprovalRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IGeneralUnitOfWork _generalUnitOfWork;
        private readonly IEmailSender _emailSender;

        public VendorController(
            IRepository<TblCountry> countryRepository,
            IRepository<TblSubCategory> subCategoryRepository,
            IRepository<TblProducts> productsRepository,
            IRepository<TblCity> cityRepository,
            IRepository<TblServices> servicesRepository,
            IRepository<TblDepartments> departmentsRepository,
            IRepository<TblFormIdentification> formIdentificationRepository,
            IRepository<TblSupplierIdentification> supplierIdentificationRepository,
            IRepository<TblSubsidiaryCompany> subsidiaryCompanyRepository,
            IRepository<TblSupplierTaxCertificate> supplierTaxCertificateRepository,
            IRepository<TblContactPersons> contactPersonsRepository,
            IRepository<TblThirdPartyReference> thirdPartyReferenceRepository,
            IRepository<TblSupplierProfile> supplierProfileRepository,
            IRepository<TblSupplierOwnership> supplierOwnershipRepository,
            IRepository<TblDirectServiceScope> directServiceScopeRepository,
            IRepository<TblTypicalSubcontractedScope> typicalSubcontractedScopeRepository,
            IRepository<TblTypicalSubconScopeProducts> typicalSubcontractedScopeProductsRepository,
            IRepository<TblCyMfgFf> CYMFGFFRepository,
            IRepository<TblSpDirectServiceScope> spDirectServiceScopeRepository,
            IRepository<TblSpDssServices> spDssServicesRepository,
            IRepository<TblOfficeServiceCl> officeServiceClRepository,
            IRepository<TblSubContractedServices> subContractedServicesRepository,
            IRepository<TblSubContractedDetails> subContractedDetailsRepository,
            IRepository<TblForeignCompany> foreignCompanyRepository,
            IRepository<TblBusinessExperience> businessExperienceRepository,
            //IRepository<TblKnowledgeDgssysytems> knowledgeDgssystemsRepository,
            IRepository<TblProductEquipmentService> productEquipmentServiceRepository,
            IRepository<TblMainCustomers> mainCustomersRepository,
            IRepository<TblNumberofEmployees> numberOfEmployeesRepository,
            IRepository<TblStaffStrengthComp> staffStrCompRepository,
            IRepository<TblFinancialStatements> financialStatementsRepository,
            //IRepository<TblFinancialAudits> financialAuditsRepository,
            //IRepository<TblFinStockMarketInfo> finStockMarketInfoRepository,
            IRepository<TblQualityManagement> qualityManagementRepository,
            IRepository<TblQualityCertification> qualityCertificationRepository,
            IRepository<TblCertifyingOrg> certifyingOrgRepository,
            IRepository<TblHealthSafetyEnvironment> hseRepository,
            IRepository<TblHseCertification> hseCertificationRepository,
            IRepository<TblCorporateDistinctives> corporateDistinctivesRepository,
            IRepository<TblCorpSocialResponsibility> corpSocialResponsiblityRepository,
            IRepository<TblVendorRegFormApproval> vendorRegFormApprovalRepository,
            IWebHostEnvironment hostingEnvironment,
            IGeneralUnitOfWork generalUnitOfWork,
            IEmailSender emailSender
            )
        {
            _countryRepository = countryRepository;
            _subCategoryRepository = subCategoryRepository;
            _productsRepository = productsRepository;
            _cityRepository = cityRepository;
            _servicesRepository = servicesRepository;
            _departmentsRepository = departmentsRepository;
            _formIdentificationRepository = formIdentificationRepository;
            _supplierIdentificationRepository = supplierIdentificationRepository;
            _subsidiaryCompanyRepository = subsidiaryCompanyRepository;
            _supplierTaxCertificateRepository = supplierTaxCertificateRepository;
            _contactPersonsRepository = contactPersonsRepository;
            _thirdPartyReferenceRepository = thirdPartyReferenceRepository;
            _supplierProfileRepository = supplierProfileRepository;
            _supplierOwnershipRepository = supplierOwnershipRepository;
            _directServiceScopeRepository = directServiceScopeRepository;
            _typicalSubcontractedScopeRepository = typicalSubcontractedScopeRepository;
            _typicalSubcontractedScopeProductsRepository = typicalSubcontractedScopeProductsRepository;
            _cYMFGFFRepository = CYMFGFFRepository;
            _spDirectServiceScopeRepository = spDirectServiceScopeRepository;
            _spDssServicesRepository = spDssServicesRepository;
            _officeServiceClRepository = officeServiceClRepository;
            _subContractedServicesRepository = subContractedServicesRepository;
            _subContractedDetailsRepository = subContractedDetailsRepository;
            _foreignCompanyRepository = foreignCompanyRepository;
            _businessExperienceRepository = businessExperienceRepository;
            //_businessContinuityPolicyRepository = businessContinuityPolicyRepository;
            //_knowledgeDgssystemsRepository = knowledgeDgssystemsRepository;
            _productEquipmentServiceRepository = productEquipmentServiceRepository;
            _mainCustomersRepository = mainCustomersRepository;
            _numberOfEmployeesRepository = numberOfEmployeesRepository;
            _staffStrCompRepository = staffStrCompRepository;
            _financialStatementsRepository = financialStatementsRepository;
            //_financialAuditsRepository = financialAuditsRepository;
            //_finStockMarketInfoRepository = finStockMarketInfoRepository;
            _qualityManagementRepository = qualityManagementRepository;
            _qualityCertificationRepository = qualityCertificationRepository;
            _certifyingOrgRepository = certifyingOrgRepository;
            _hseRepository = hseRepository;
            _hseCertificationRepository = hseCertificationRepository;
            _corporateDistinctivesRepository = corporateDistinctivesRepository;
            _corpSocialResponsiblityRepository = corpSocialResponsiblityRepository;
            _vendorRegFormApprovalRepository = vendorRegFormApprovalRepository;
            _hostingEnvironment = hostingEnvironment;
            _generalUnitOfWork = generalUnitOfWork;
            _emailSender = emailSender;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendorFormList()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            //var returnUrl = "/Vendor/VendorFormList";

            if (claim == null)
            {
                return RedirectToAction("Login","Account");
            }

            var userEmail = claim.Value;

            

            var vendorListModel = _vendorRegFormApprovalRepository.Find(f => f.VendorUsername == userEmail );

            return View(vendorListModel);
        }



        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(AccountController.Login), "Account");
        //    }
        //}


        public IActionResult VendorFormQuery(int id)
        {
            var vendor = _vendorRegFormApprovalRepository.GetById(id);
            //var formIdentification = _formIdentificationRepository.GetById(vendor.id)
            var model = new VendorFormViewModel
            {
                Countries = _countryRepository.GetAll().ToList(),
                //SubCategories = _subCategoryRepository.GetAll().ToList(),
                //Products = _productsRepository.GetAll().ToList(),
                Cities = _cityRepository.GetAll().ToList(),
                Services = _servicesRepository.GetAll().ToList(),
                Departments = _departmentsRepository.GetAll().ToList(),
                VendorApprovalId = vendor.VendorApprovalId,
                SupplierId = vendor.SupplierId,
                ApprovedBy = vendor.ApprovedBy,
                // fill in form identification details
                FormId = vendor.FormId,
                VendorUsername = vendor.VendorUsername,
                FormIdentificationName = vendor.FormIdentificationName,
                FormIdentificationPosition = vendor.FormIdentificationPosition,
                FormIdentificationPhoneNumber = vendor.FormIdentificationPhoneNumber,
                FormIdentificationWorkPhoneNumber = vendor.FormIdentificationWorkPhoneNumber,
                FormIdentificationEmailAddress = vendor.FormIdentificationEmailAddress,
                FormIdentificationDate = vendor.FormIdentificationDate,                
                CompanyIsForeign = vendor.VendorIsForeign.GetValueOrDefault(),
                SupplierIdentificationCAC = vendor.VendorCorporateAffairsCommisionNo,
                SupplierIdentificationCompanyName = vendor.VendorCompanyName,
                SupplierIdentificationSubsidiaryCompanyName1 = vendor.SubsidiaryCompanyName,
                SupplierIdentificationHeadOfficeAddress = vendor.VendorHeadOfficeAddress,
                SupplierIdentificationCompanyRegNumber = vendor.VendorCompanyRegistrationNumber,
                MainContactPersonName = vendor.MainContactPersonName,
                MainContactPosition = vendor.MainContactPersonPosition,
                MainContactPhoneNumber = vendor.MainContactPersonPhone,
                MainContactWorkPhoneNumber = vendor.MainContactPersonWorkPhone,
                MainContactEmailAddress = vendor.MainContactPersonEmail,
                //SupplierIdentificationBankReference = ApprovalUploadFile(vendor.BankReference),
                TprName = vendor.ThirdPartyRefName,
                TprAddress = vendor.ThirdPartyRefOrgAddress,
                TprPhoneNumber = vendor.ThirdPartyRefContactNo,
                TprEmailAddress = vendor.ThirdPartyRefEmail,
                //VendorCompanyProfile = ApprovalUploadFile(vendor.SupplierIdentificationCompanyProfile),
                SupplierIdentificationCompanyWebsiteUrl = vendor.VendorCompanyWebsiteAddress,
                NatureOfBusiness = vendor.VendorNatureofBusiness,
                DateofCreation = vendor.VendorCompanyDateofCreation,
                MainShareholder1 = vendor.OwnershipMainShareholders,
                Shareholding1 = vendor.PercentageShareholding.GetValueOrDefault(),
                //OwnershipNationality = _countryRepository.GetById(model.SupplierOwnershipCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                //SupplierOwnershipCountryId1= vendor.OwnershipNationality.GetValueOrDefault(0).ToString(),
                MaterialsName1 = vendor.DirectServiceScopeMaterials,
                SubCategoryId1 = vendor.DirectServiceScopeSubCategories,
                ProductName1 = vendor.TypicalSubContractedScopeProducts,
                TypicalSubConName1 = vendor.TypicalSubContractedScopeName,
                TypicalSubConAddress1 = vendor.TypicalSubContractedScopeAddress,
                //TypicalSubConCountryId1 = vendor.TypicalSubContractedScopeNationality.GetValueOrDefault(0).ToString(),
                //TypicalSubContractedScopeNationality = _countryRepository.GetById(model.TypicalSubConCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                TypicalSubConIsLocal1 = vendor.TypicalSubContractedScopeIsLocal.GetValueOrDefault(),
                //CyMfgFfCityId1 = vendor.CyMfgFfCityId1.ToString(),
                //Cymfgffcity = _cityRepository.GetById(model.CyMfgFfCityId1.GetValueOrDefault(0)).CityName ?? null,
                CyMfgFfPlantsEquipmentType1 = vendor.CymfgffplantEquipmentType,
                CyMfgFfPlantsEquipmentNumber1 = vendor.CymfgffplantEquipmentNumber.GetValueOrDefault(),
                CyMfgFfUtilization1 = vendor.Cymfgffutilization,
                CyMfgFfFactoryArea1 = vendor.CymfgfffactoryArea.GetValueOrDefault(),
                SpServices1 = vendor.SpdirectServiceScopeService,
                SpDssDescription1 = vendor.SpdirectServiceScopeServiceDetails,
                //OfficeServClCityId1 = vendor.SpofficeServiceCenterCity.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCity = _cityRepository.GetById(model.OfficeServClCityId1.GetValueOrDefault(0)).CityName ?? null,
                //OfficeServClCountryId1 = vendor.SpofficeServiceCenterCountry.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCountry = _countryRepository.GetById(model.OfficeServClCountryId1.GetValueOrDefault(0)).CountryName ?? null,
                SubConServiceName = vendor.SpsubContractedServices,
                SubConPercentageOutsourced = vendor.SpsubContractedServicesPercOutsourced.GetValueOrDefault(),
                SubConName = vendor.SpsubContractorName,
                SubConAddress = vendor.SpsubContractorAddress,
                //SubConCountryId = vendor.SpsubContractorNationality.GetValueOrDefault(0).ToString(),
                //SpsubContractorNationality = _countryRepository.GetById(model.SubConCountryId.GetValueOrDefault(0)).CountryName ?? null,
                IsLocal = vendor.SpsubContractorIsLocal.GetValueOrDefault(),
                ForeignCompanyName = vendor.AdforeignCompanyName,
                ProductSupplied = vendor.AdforeignCompanyProductSupplied,
                //AdforeignCompanyStatus = model.StatusList.Where(x => x.Value == model.Status.ToString()).FirstOrDefault().Text,
                Others = vendor.AdforeignCompanyOther,
                //VendorOrganizationChart = ApprovalUploadFile(vendor.SupplierProfileOrganizationCharts),
                //VendorMissionVisionStatement = ApprovalUploadFile(vendor.SupplierProfileMissionVisionStatement),
                //BusinessContinuityPolicy = ApprovalUploadFile(model.BizConPolicy),
                //BusinessExFinancialTurnover = int.Parse(vendor.FinancialTurnOver),
                //BusinessExContinuityPolicy = ApprovalUploadFile(vendor.BizConPolicy),
                HasBusinessConPolicy = vendor.BusinessExHasContinuityPolicy,
                CompanyWorkedWith1 = vendor.BusinessExCompanyWorkedWith,
                TimeFrame1 = vendor.BusinessExTimeFrame,
                ScopeCovered1 = vendor.BusinessExScopeCovered,
                KDGSStartDate = vendor.BusinessExRegistrationDate,
                //BusinessExTransactionReference = ApprovalUploadFile(vendor.TransactionReference1),
                KDGSContractNumber = vendor.KnowledgeofDgssystemsContractNo,
                ProdEquSerDescription = vendor.KnowledgeofDgssystemsProdEquServ,
               // = vendor.KnowledgeofDgssystemsStartDate,
                //KnowledgeofDgssystemsDgsref = vendor.Dgsref,
                //VendorMainCustomerName = vendor.CustomerName,
                //VendorMainCustomerCountry = vendor.CustomerCountryId.ToString(),
                //VendorMainCustomerCountry = _countryRepository.GetById(model.CustomerCountryId).CountryName,
                //VendorMainCustomerProductService = model.KDGSSType.Where(x => x.Value == model.KDGSProdEquSerId.ToString()).FirstOrDefault().Text,
                //VendorMainCustomerProductService = _productEquipmentServiceRepository.GetById(model.ProdEquSerType).Description,
                //VendorMainCustomerValueYear = int.Parse((model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text).Split("-")[1]),
                //VendorMainCustomerValue = model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text,
                //VendorCompanyDepartment = _departmentsRepository.GetAll().ToList()[0].DepartmentName,
                //VendorCompanyNoofStaff = vendor.NoOfEmployees1,
                //VendorCompanyNoofContractStaff = vendor.NoOfContractEmp1,
                //VendorCompanyNoofExpatriates = vendor.NoOfExpatriates1,
                //CodeofConduct = ApprovalUploadFile(vendor.CodeOfConduct),
                //StaffTrainingPolicy = ApprovalUploadFile(vendor.StaffPolicy),
                //StaffTrainingPolicyThirdPartyAudit = ApprovalUploadFile(vendor.ThirdPartySocAudit),
                //FinancialStatementYear1 = ApprovalUploadFile(vendor.FinancialStatement1),
                //FinancialStatementYear2 = ApprovalUploadFile(vendor.FinancialStatement2),
                //FinancialStatementYear3 = ApprovalUploadFile(vendor.FinancialStatement3),
                AuditorName = vendor.FinancialAuditorName,
                AuditorAddress = vendor.FinancialAuditorAddress,
                AuditorContactNumber = vendor.FinancialAuditorContactNumber,
                IsListed = vendor.IsListedStockMarket,
                //QualityPolicy = ApprovalUploadFile(vendor.QualityPolicy),
                //ProductQualityManagement = ApprovalUploadFile(vendor.ProductQualMgt),
                //QualityManagement = ApprovalUploadFile(vendor.QualityMgt),
                QualManagerName = vendor.QualityManagerName,
                QualManagerEmail = vendor.QualityManagerEmail,
                QualManagerPhoneNumber = vendor.QualityManagerPhoneNumber,
                QualManagerWorkPhoneNumber = vendor.QualityManagerWorkPhoneNo,
                QualManagerFax = vendor.QualityManagerFaxNumber,
                NameofCertificate = vendor.QualityCertificationName,
                CertOrgName = vendor.QualityCertificationCertOrganization,
                ValidityDate = vendor.QualityCertficationValidityDate?? null,
                //HealthSafetyEnvironmentPolicy = ApprovalUploadFile(vendor.Hsepolicy),
                //HsethirdPartyAudit = ApprovalUploadFile(vendor.HseThirdPartyAudit),
                HseManagerName = vendor.HsemanagerName,
                HseManagerEmail = vendor.HsemanagerEmail,
                HsePhoneNumber = vendor.HsephoneNumber,
                HseWorkPhoneNumber = vendor.HseworkPhoneNumber,
                HseFax = vendor.HsefaxNumber,
                //HsecompanyKpi = ApprovalUploadFile(vendor.HseCompanyKpi),
                //HsecompanyYearN1results = ApprovalUploadFile(vendor.HseYearN1results),
                //HsestaffTrainingPolicy = ApprovalUploadFile(vendor.HseStaffTraining),
                HseNameofCertificate = vendor.HsecertificationName,
                HseCertOrgName = vendor.HsecertificationCertAuthority,
                HseValidityDate = vendor.HsecertficationValidityDate ?? null,
                Details1 = vendor.CorporateDistinctives,
                //CsrsocRespEthHumanLaborLaws = ApprovalUploadFile(vendor.SrethHumanLaborLaws ?? null),
                //VendorThirdPartySocialAudit = ApprovalUploadFile(vendor.ThirdPartySocAudit),
                //VendorFraudMalpracticePolicy = ApprovalUploadFile(vendor.FraudMalpracticePolicy),
                //ApprovalStatus = 0



            };

            return View(model);
        }

        [HttpPost]
        public IActionResult VendorQueryUpdate (VendorFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Countries = _countryRepository.GetAll().ToList();
                model.Cities = _cityRepository.GetAll().ToList();
                model.Services = _servicesRepository.GetAll().ToList();
                model.Departments = _departmentsRepository.GetAll().ToList();

                model.ModelError = "Form details need to be supplied Correctly";


                return View(model);
            }

            //var vendor = _vendorRegFormApprovalRepository.GetById(model.VendorApprovalId);
            //vendor.VendorApprovalId = model.VendorApprovalId;

            var vendor = new TblVendorRegFormApproval
            {
                VendorApprovalId = model.VendorApprovalId,
                SupplierId = model.SupplierId,
                // fill in form identification details
                FormId = model.FormId,
                VendorUsername = model.VendorUsername,
                ApprovedBy = model.ApprovedBy,
                FormIdentificationName = model.FormIdentificationName,
                FormIdentificationPosition = model.FormIdentificationPosition,
                FormIdentificationPhoneNumber = model.FormIdentificationPhoneNumber,
                FormIdentificationWorkPhoneNumber = model.FormIdentificationWorkPhoneNumber,
                FormIdentificationEmailAddress = model.FormIdentificationEmailAddress,
                FormIdentificationDate = model.FormIdentificationDate,
                VendorIsForeign = model.CompanyIsForeign,
                VendorCompanyName = model.SupplierIdentificationCompanyName,
                SubsidiaryCompanyName = model.SupplierIdentificationSubsidiaryCompanyName1,
                VendorHeadOfficeAddress = model.SupplierIdentificationHeadOfficeAddress,
                VendorCompanyRegistrationNumber = model.SupplierIdentificationCompanyRegNumber,
                MainContactPersonName = model.MainContactPersonName,
                MainContactPersonPosition = model.MainContactPosition,
                MainContactPersonPhone = model.MainContactPhoneNumber,
                MainContactPersonWorkPhone = model.MainContactWorkPhoneNumber,
                MainContactPersonEmail = model.MainContactEmailAddress,
                BankReference = ApprovalUploadFile(model.SupplierIdentificationBankReference),
                ThirdPartyRefName = model.TprName,
                ThirdPartyRefOrgAddress = model.TprAddress,
                ThirdPartyRefContactNo = model.TprPhoneNumber,
                ThirdPartyRefEmail = model.TprEmailAddress,
                VendorCompanyProfile = ApprovalUploadFile(model.SupplierIdentificationCompanyProfile),
                VendorCompanyWebsiteAddress = model.SupplierIdentificationCompanyWebsiteUrl,
                VendorNatureofBusiness = model.NatureOfBusiness,
                VendorCompanyDateofCreation = model.DateofCreation,
                OwnershipMainShareholders = model.MainShareholder1,
                PercentageShareholding = model.Shareholding1,
                //OwnershipNationality = _countryRepository.GetById(model.SupplierOwnershipCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                OwnershipNationality = model.SupplierOwnershipCountryId1.GetValueOrDefault(0).ToString(),
                DirectServiceScopeMaterials = model.MaterialsName1,
                DirectServiceScopeSubCategories = model.SubCategoryId1,
                TypicalSubContractedScopeProducts = model.ProductName1,
                TypicalSubContractedScopeName = model.TypicalSubConName1,
                TypicalSubContractedScopeAddress = model.TypicalSubConAddress1,
                TypicalSubContractedScopeNationality = model.TypicalSubConCountryId1.GetValueOrDefault(0).ToString(),
                //TypicalSubContractedScopeNationality = _countryRepository.GetById(model.TypicalSubConCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                TypicalSubContractedScopeIsLocal = model.TypicalSubConIsLocal1,
                Cymfgffcity = model.CyMfgFfCityId1.ToString(),
                //Cymfgffcity = _cityRepository.GetById(model.CyMfgFfCityId1.GetValueOrDefault(0)).CityName ?? null,
                CymfgffplantEquipmentType = model.CyMfgFfPlantsEquipmentType1,
                CymfgffplantEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber1,
                Cymfgffutilization = model.CyMfgFfUtilization1,
                CymfgfffactoryArea = model.CyMfgFfFactoryArea1,
                SpdirectServiceScopeService = model.SpServices1,
                SpdirectServiceScopeServiceDetails = model.SpDssDescription1,
                SpofficeServiceCenterCity = model.OfficeServClCityId1.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCity = _cityRepository.GetById(model.OfficeServClCityId1.GetValueOrDefault(0)).CityName ?? null,
                SpofficeServiceCenterCountry = model.OfficeServClCountryId1.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCountry = _countryRepository.GetById(model.OfficeServClCountryId1.GetValueOrDefault(0)).CountryName ?? null,
                SpsubContractedServices = model.SubConServiceName,
                SpsubContractedServicesPercOutsourced = model.SubConPercentageOutsourced,
                SpsubContractorName = model.SubConName,
                SpsubContractorAddress = model.SubConAddress,
                SpsubContractorNationality = model.SubConCountryId.GetValueOrDefault(0).ToString(),
                //SpsubContractorNationality = _countryRepository.GetById(model.SubConCountryId.GetValueOrDefault(0)).CountryName ?? null,
                SpsubContractorIsLocal = model.IsLocal,
                AdforeignCompanyName = model.ForeignCompanyName,
                AdforeignCompanyProductSupplied = model.ProductSupplied,
                //AdforeignCompanyStatus = model.StatusList.Where(x => x.Value == model.Status.ToString()).FirstOrDefault().Text,
                AdforeignCompanyOther = model.Others,
                VendorOrganizationChart = ApprovalUploadFile(model.SupplierProfileOrganizationCharts),
                VendorMissionVisionStatement = ApprovalUploadFile(model.SupplierProfileMissionVisionStatement),
                //BusinessContinuityPolicy = ApprovalUploadFile(model.BizConPolicy),
                BusinessExFinancialTurnover = int.Parse(model.FinancialTurnOver),
                BusinessExContinuityPolicy = ApprovalUploadFile(model.BizConPolicy),
                BusinessExHasContinuityPolicy = model.HasBusinessConPolicy,
                BusinessExCompanyWorkedWith = model.CompanyWorkedWith1,
                BusinessExTimeFrame = model.TimeFrame1,
                BusinessExScopeCovered = model.ScopeCovered1,
                BusinessExRegistrationDate = model.KDGSStartDate,
                BusinessExTransactionReference = ApprovalUploadFile(model.TransactionReference1),
                KnowledgeofDgssystemsContractNo = model.KDGSContractNumber,
                KnowledgeofDgssystemsProdEquServ = model.ProdEquSerDescription,
                KnowledgeofDgssystemsStartDate = model.KDGSStartDate,
                KnowledgeofDgssystemsDgsref = model.Dgsref,
                VendorMainCustomerName = model.CustomerName,
                VendorMainCustomerCountry = model.CustomerCountryId.ToString(),
                //VendorMainCustomerCountry = _countryRepository.GetById(model.CustomerCountryId).CountryName,
                //VendorMainCustomerProductService = model.KDGSSType.Where(x => x.Value == model.KDGSProdEquSerId.ToString()).FirstOrDefault().Text,
                //VendorMainCustomerProductService = _productEquipmentServiceRepository.GetById(model.ProdEquSerType).Description,
                //VendorMainCustomerValueYear = int.Parse((model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text).Split("-")[1]),
                //VendorMainCustomerValue = model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text,
                VendorCompanyDepartment = _departmentsRepository.GetAll().ToList()[0].DepartmentName,
                VendorCompanyNoofStaff = model.NoOfEmployees1,
                VendorCompanyNoofContractStaff = model.NoOfContractEmp1,
                VendorCompanyNoofExpatriates = model.NoOfExpatriates1,
                CodeofConduct = ApprovalUploadFile(model.CodeOfConduct),
                StaffTrainingPolicy = ApprovalUploadFile(model.StaffPolicy),
                StaffTrainingPolicyThirdPartyAudit = ApprovalUploadFile(model.ThirdPartySocAudit),
                FinancialStatementYear1 = ApprovalUploadFile(model.FinancialStatement1),
                FinancialStatementYear2 = ApprovalUploadFile(model.FinancialStatement2),
                FinancialStatementYear3 = ApprovalUploadFile(model.FinancialStatement3),
                FinancialAuditorName = model.AuditorName,
                FinancialAuditorAddress = model.AuditorAddress,
                FinancialAuditorContactNumber = model.AuditorContactNumber,
                IsListedStockMarket = model.IsListed,
                QualityPolicy = ApprovalUploadFile(model.QualityPolicy),
                ProductQualityManagement = ApprovalUploadFile(model.ProductQualMgt),
                QualityManagement = ApprovalUploadFile(model.QualityMgt),
                QualityManagerName = model.QualManagerName,
                QualityManagerEmail = model.QualManagerEmail,
                QualityManagerPhoneNumber = model.QualManagerPhoneNumber,
                QualityManagerWorkPhoneNo = model.QualManagerWorkPhoneNumber,
                QualityManagerFaxNumber = model.QualManagerFax,
                QualityCertificationName = model.NameofCertificate,
                QualityCertificationCertOrganization = model.CertOrgName,
                QualityCertficationValidityDate = model.ValidityDate ?? null,
                HealthSafetyEnvironmentPolicy = ApprovalUploadFile(model.Hsepolicy),
                HsethirdPartyAudit = ApprovalUploadFile(model.HseThirdPartyAudit),
                HsemanagerName = model.HseManagerName,
                HsemanagerEmail = model.HseManagerEmail,
                HsephoneNumber = model.HsePhoneNumber,
                HseworkPhoneNumber = model.HseWorkPhoneNumber,
                HsefaxNumber = model.HseFax,
                HsecompanyKpi = ApprovalUploadFile(model.HseCompanyKpi),
                HsecompanyYearN1results = ApprovalUploadFile(model.HseYearN1results),
                HsestaffTrainingPolicy = ApprovalUploadFile(model.HseStaffTraining),
                HsecertificationName = model.HseNameofCertificate,
                HsecertificationCertAuthority = model.HseCertOrgName,
                HsecertficationValidityDate = model.HseValidityDate ?? null,
                CorporateDistinctives = model.Details1,
                CsrsocRespEthHumanLaborLaws = ApprovalUploadFile(model.SrethHumanLaborLaws ?? null),
                VendorThirdPartySocialAudit = ApprovalUploadFile(model.ThirdPartySocAudit),
                VendorFraudMalpracticePolicy = ApprovalUploadFile(model.FraudMalpracticePolicy),
                ApprovalStatus = 3,
                
            };

            

            _vendorRegFormApprovalRepository.Update(vendor);

            string adminUpdateEmail = "Queried Vendor Form with id " +model.VendorApprovalId + " has been updated";

            _emailSender.SendEmailAsync(model.ApprovedBy, "Vendor Form Query Update", adminUpdateEmail);

            return RedirectToAction("VendorFormList");
        }



        [HttpGet]
        public IActionResult Form()
        {

            var model = new VendorFormViewModel
            {
                Countries = _countryRepository.GetAll().ToList(),
                //SubCategories = _subCategoryRepository.GetAll().ToList(),
                //Products = _productsRepository.GetAll().ToList(),
                Cities = _cityRepository.GetAll().ToList(),
                Services = _servicesRepository.GetAll().ToList(),
                Departments = _departmentsRepository.GetAll().ToList()
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Form(VendorFormViewModel model)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            if (claim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userEmail = claim.Value;


            if (!ModelState.IsValid)
            {
                model.Countries = _countryRepository.GetAll().ToList();
                model.Cities = _cityRepository.GetAll().ToList();
                model.Services = _servicesRepository.GetAll().ToList();
                model.Departments = _departmentsRepository.GetAll().ToList();

                model.ModelError = "Form details need to be supplied Correctly";

                

                return View(model);   
            }

            // writing form logic here

            // creating File Upload list
            //var uploadList = new List<IFormFile>();

            

            /*Form Identification*/
            // Tables involved: TblFormIdentification

            // creating instance of TblFormIdentification object to be created in the database, assigning its properties to it
            var formIdentification = new TblFormIdentification
            {
                Name = model.FormIdentificationName,
                Position = model.FormIdentificationPosition,
                PhoneNumber = model.FormIdentificationPhoneNumber,
                WorkPhoneNumber = model.FormIdentificationWorkPhoneNumber,
                EmailAddress = model.FormIdentificationEmailAddress
            };

            // calling the create method of the FormIdentification repository
             _formIdentificationRepository.Create(formIdentification);

            var FormId = _formIdentificationRepository.GetById(formIdentification.FormId).FormId;


            /*Supplier Identification*/
            // Tables Involved: TblSupplierIdentification

            // creating instances of table classes needed, assigning there properties to them

            

            var contactPersons = new TblContactPersons
            {
                ContactPersonName = model.MainContactPersonName,
                Position = model.MainContactPosition,
                PhoneNumber = model.MainContactPhoneNumber,
                WorkPhoneNumber = model.MainContactWorkPhoneNumber,
                EmailAddress = model.MainContactEmailAddress,
                FormId = FormId
            };

            _contactPersonsRepository.Create(contactPersons);


            var thirdPartyReference = new TblThirdPartyReference
            {
                TprName = model.TprName,
                TprOrganization = model.TprOrganization,
                TprAddress = model.TprAddress,
                TprPhoneNumber = model.TprPhoneNumber,
                TprWorkPhoneNumber = model.TprWorkPhoneNumber,
                TprEmailAddress = model.TprEmailAddress,
                FormId = FormId
            };

            _thirdPartyReferenceRepository.Create(thirdPartyReference);




            var supplierIdentification = new TblSupplierIdentification
            {
                FormId = _formIdentificationRepository.GetById(formIdentification.FormId).FormId,
                CompanyName = model.SupplierIdentificationCompanyName,
                CorporateAffairsCommisionNo = model.SupplierIdentificationCAC,
                HeadOfficeAddress = model.SupplierIdentificationHeadOfficeAddress,
                SupplierIsForeign = model.CompanyIsForeign,
                CompanyRegNumber = model.SupplierIdentificationCompanyRegNumber,
                ContactPersonId = _contactPersonsRepository.GetById(contactPersons.ContactPersonId).ContactPersonId,
                BankReference = UploadFile(model.SupplierIdentificationBankReference),
                ThirdPartyReference = UploadFile(model.SupplierIdentificationThirdPartyReference),
                TprId = _thirdPartyReferenceRepository.GetById(thirdPartyReference.TprId).TprId,
                CompanyProfile = UploadFile(model.SupplierIdentificationCompanyProfile),
                CompanyWebsiteUrl = model.SupplierIdentificationCompanyWebsiteUrl
            };

            _supplierIdentificationRepository.Create(supplierIdentification);

            var SupplierId = _supplierIdentificationRepository.GetById(supplierIdentification.SupplierId).SupplierId;


            var subsidiaryCompany1 = new TblSubsidiaryCompany
            {
                SupplierId = SupplierId,
                SubsidiaryCompanyName = model.SupplierIdentificationSubsidiaryCompanyName1
            };

            _subsidiaryCompanyRepository.Create(subsidiaryCompany1);

            var subsidiaryCompany2 = new TblSubsidiaryCompany
            {
                SupplierId = SupplierId,
                SubsidiaryCompanyName = model.SupplierIdentificationSubsidiaryCompanyName2
            };

            _subsidiaryCompanyRepository.Create(subsidiaryCompany2);

            var subsidiaryCompany3 = new TblSubsidiaryCompany
            {
                SupplierId = SupplierId,
                SubsidiaryCompanyName = model.SupplierIdentificationSubsidiaryCompanyName3
            };

            _subsidiaryCompanyRepository.Create(subsidiaryCompany3);

            var supplierTaxCertificate = new TblSupplierTaxCertificate
            {
                SupplierId = SupplierId,
                TaxCertificate = UploadFile(model.SupplierIdentificationTaxClearanceCertificate)
            };

            _supplierTaxCertificateRepository.Create(supplierTaxCertificate);

            var supplierProfile = new TblSupplierProfile
            {
                SupplierId = SupplierId,
                NatureOfBusiness = model.NatureOfBusiness,
                OrganizationCharts = UploadFile(model.SupplierProfileOrganizationCharts),
                MissionVisionStatement = UploadFile(model.SupplierProfileMissionVisionStatement),
                DateofCreation = model.DateofCreation.GetValueOrDefault(),
                CodeofConduct = UploadFile(model.CodeOfConduct),
            };

            _supplierProfileRepository.Create(supplierProfile);



            var supplierOwnershipList = new List<TblSupplierOwnership>();

            var supplierOwnership1 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder1,
                Shareholding = model.Shareholding1,
                CountryId = model.SupplierOwnershipCountryId1
            };
            supplierOwnershipList.Add(supplierOwnership1);


            var supplierOwnership2 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder2,
                Shareholding = model.Shareholding2,
                CountryId = model.SupplierOwnershipCountryId2
            };
            supplierOwnershipList.Add(supplierOwnership2);



            var supplierOwnership3 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder3,
                Shareholding = model.Shareholding3,
                CountryId = model.SupplierOwnershipCountryId3
            };
            supplierOwnershipList.Add(supplierOwnership3);

            var supplierOwnership4 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder4,
                Shareholding = model.Shareholding4,
                CountryId = model.SupplierOwnershipCountryId4
            };
            supplierOwnershipList.Add(supplierOwnership4);

            var supplierOwnership5 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder5,
                Shareholding = model.Shareholding5,
                CountryId = model.SupplierOwnershipCountryId5
            };
            supplierOwnershipList.Add(supplierOwnership5);

            var supplierOwnership6 = new TblSupplierOwnership
            {
                SupplierId = SupplierId,
                MainShareholder = model.MainShareholder6,
                Shareholding = model.Shareholding6,
                CountryId = model.SupplierOwnershipCountryId6
            };
            supplierOwnershipList.Add(supplierOwnership6);

            // use unit of work
            foreach (var supplierOwnership in supplierOwnershipList)
            {
                _supplierOwnershipRepository.Create(supplierOwnership);
            }


            var directServiceScopeList = new List<TblDirectServiceScope>();

            //var subCategory1 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId1,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory1);

            var directServiceScope1 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName1,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory1.SubCategoryId).SubCategoryId,
            };

            directServiceScopeList.Add(directServiceScope1);

            //var subCategory2 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId2,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory2);


            var directServiceScope2 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName2,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory2.SubCategoryId).SubCategoryId,
            };
            directServiceScopeList.Add(directServiceScope2);


            //var subCategory3 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId3,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory3);



            var directServiceScope3 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName3,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory3.SubCategoryId).SubCategoryId,
            };
            directServiceScopeList.Add(directServiceScope3);



            //var subCategory4 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId4,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory4);



            var directServiceScope4 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName4,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory4.SubCategoryId).SubCategoryId,
            };
            directServiceScopeList.Add(directServiceScope4);



            //var subCategory5 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId5,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory5);



            var directServiceScope5 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName5,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory5.SubCategoryId).SubCategoryId,
            };

            directServiceScopeList.Add(directServiceScope5);



            //var subCategory6 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId6,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory6);



            var directServiceScope6 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName6,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory6.SubCategoryId).SubCategoryId,
            };
            directServiceScopeList.Add(directServiceScope6);


            //var subCategory7 = new TblSubCategory
            //{
            //    Name = model.SubCategoryId7,
            //    SupplierId = SupplierId,
            //};

            //_subCategoryRepository.Create(subCategory7);


            var directServiceScope7 = new TblDirectServiceScope
            {
                MaterialsName = model.MaterialsName7,
                //SubCategoryId = _subCategoryRepository.GetById(subCategory7.SubCategoryId).SubCategoryId,
            };
            directServiceScopeList.Add(directServiceScope7);


            foreach(var directServiceScope in directServiceScopeList)
            {
                _directServiceScopeRepository.Create(directServiceScope);
            }



            // typical subcontracted Scope
            var typicalSubContractedScope1 = new TblTypicalSubcontractedScope
            {
                SubConName = model.TypicalSubConName1,
                SubConAddress = model.TypicalSubConAddress1,
                CountryId = model.TypicalSubConCountryId1,
                IsLocal = model.TypicalSubConIsLocal1,
                SupplierId = SupplierId                
            };

            _typicalSubcontractedScopeRepository.Create(typicalSubContractedScope1);

            var product1 = new TblProducts
            {
                ProductName = model.ProductName1,
                //SupplierId = SupplierId,                
            };

            _productsRepository.Create(product1);

            var typicalSubContractedScopeProduct1 = new TblTypicalSubconScopeProducts
            {
                ProductId = _productsRepository.GetById(product1.ProductId).ProductId,
                SubConScopeId = _typicalSubcontractedScopeRepository.GetById(typicalSubContractedScope1.SubConScopeId).SubConScopeId
            };

            _typicalSubcontractedScopeProductsRepository.Create(typicalSubContractedScopeProduct1);




            var typicalSubContractedScope2 = new TblTypicalSubcontractedScope
            {
                SubConName = model.TypicalSubConName2,
                SubConAddress = model.TypicalSubConAddress2,
                CountryId = model.TypicalSubConCountryId2,
                IsLocal = model.TypicalSubConIsLocal2,
                SupplierId = SupplierId
            };

            _typicalSubcontractedScopeRepository.Create(typicalSubContractedScope2);

            var product2 = new TblProducts
            {
                ProductName = model.ProductName2,
                //SupplierId = SupplierId,
            };

            _productsRepository.Create(product2);

            var typicalSubContractedScopeProduct2 = new TblTypicalSubconScopeProducts
            {
                ProductId = _productsRepository.GetById(product2.ProductId).ProductId,
                SubConScopeId = _typicalSubcontractedScopeRepository.GetById(typicalSubContractedScope2.SubConScopeId).SubConScopeId
            };

            _typicalSubcontractedScopeProductsRepository.Create(typicalSubContractedScopeProduct2);




            var typicalSubContractedScope3 = new TblTypicalSubcontractedScope
            {
                SubConName = model.TypicalSubConName3,
                SubConAddress = model.TypicalSubConAddress3,
                CountryId = model.TypicalSubConCountryId3,
                IsLocal = model.TypicalSubConIsLocal3,
                SupplierId = SupplierId
            };

            _typicalSubcontractedScopeRepository.Create(typicalSubContractedScope3);

            var product3 = new TblProducts
            {
                ProductName = model.ProductName3,
                //SupplierId = SupplierId,
            };

            _productsRepository.Create(product3);


            var typicalSubContractedScopeProduct3 = new TblTypicalSubconScopeProducts
            {
                ProductId = _productsRepository.GetById(product3.ProductId).ProductId,
                SubConScopeId = _typicalSubcontractedScopeRepository.GetById(typicalSubContractedScope3.SubConScopeId).SubConScopeId
            };

            _typicalSubcontractedScopeProductsRepository.Create(typicalSubContractedScopeProduct3);



            // Construction Yard/ MFG/ FAB FACILITIES

            var cyMfgFf1 = new TblCyMfgFf
            {
                Location = model.CyMfgFfLocation1,
                CityId = model.CyMfgFfCityId1,
                PlantsEquipmentType = model.CyMfgFfPlantsEquipmentType1,
                PlantsEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber1,
                Utilization = model.CyMfgFfUtilization1,
                FactoryArea = model.CyMfgFfFactoryArea1,
                SupplierId = SupplierId,
            };

            _cYMFGFFRepository.Create(cyMfgFf1);



            var cyMfgFf2 = new TblCyMfgFf
            {
                Location = model.CyMfgFfLocation2,
                CityId = model.CyMfgFfCityId2,
                PlantsEquipmentType = model.CyMfgFfPlantsEquipmentType2,
                PlantsEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber2,
                Utilization = model.CyMfgFfUtilization2,
                FactoryArea = model.CyMfgFfFactoryArea2,
                SupplierId = SupplierId,
            };

            _cYMFGFFRepository.Create(cyMfgFf2);


            var cyMfgFf3 = new TblCyMfgFf
            {
                Location = model.CyMfgFfLocation3,
                CityId = model.CyMfgFfCityId3,
                PlantsEquipmentType = model.CyMfgFfPlantsEquipmentType3,
                PlantsEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber3,
                Utilization = model.CyMfgFfUtilization3,
                FactoryArea = model.CyMfgFfFactoryArea3,
                SupplierId = SupplierId,
            };

            _cYMFGFFRepository.Create(cyMfgFf3);



            var cyMfgFf4 = new TblCyMfgFf
            {
                Location = model.CyMfgFfLocation4,
                CityId = model.CyMfgFfCityId4,
                PlantsEquipmentType = model.CyMfgFfPlantsEquipmentType4,
                PlantsEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber4,
                Utilization = model.CyMfgFfUtilization4,
                FactoryArea = model.CyMfgFfFactoryArea4,
                SupplierId = SupplierId,
            };

            _cYMFGFFRepository.Create(cyMfgFf4);



            // Direct Service Scope


            var spDirectServiceScope1 = new TblSpDirectServiceScope
            {
                Description = model.SpDssDescription1,
                SupplierId = SupplierId,
            };

            _spDirectServiceScopeRepository.Create(spDirectServiceScope1);

            var service1 = new TblServices
            {
                ServiceName = model.SpServices1,
                //SupplierId = SupplierId,
            };

            _servicesRepository.Create(service1);


            var spDssService1 = new TblSpDssServices
            {
                SpDssid = _spDirectServiceScopeRepository.GetById(spDirectServiceScope1.SpDssId).SpDssId,
                ServiceId = _servicesRepository.GetById(service1.ServiceId).ServiceId
            };

            _spDssServicesRepository.Create(spDssService1);



            var spDirectServiceScope2 = new TblSpDirectServiceScope
            {
                Description = model.SpDssDescription2,
                SupplierId = SupplierId,
            };

            _spDirectServiceScopeRepository.Create(spDirectServiceScope2);

            var service2 = new TblServices
            {
                ServiceName = model.SpServices2,
                //SupplierId = SupplierId,
            };

            _servicesRepository.Create(service2);


            var spDssService2 = new TblSpDssServices
            {
                SpDssid = _spDirectServiceScopeRepository.GetById(spDirectServiceScope2.SpDssId).SpDssId,
                ServiceId = _servicesRepository.GetById(service2.ServiceId).ServiceId
            };

            _spDssServicesRepository.Create(spDssService2);



            var spDirectServiceScope3 = new TblSpDirectServiceScope
            {
                Description = model.SpDssDescription3,
                SupplierId = SupplierId,
            };

            _spDirectServiceScopeRepository.Create(spDirectServiceScope3);

            var service3 = new TblServices
            {
                ServiceName = model.SpServices3,
                //SupplierId = SupplierId,
            };

            _servicesRepository.Create(service3);


            var spDssService3 = new TblSpDssServices
            {
                SpDssid = _spDirectServiceScopeRepository.GetById(spDirectServiceScope3.SpDssId).SpDssId,
                ServiceId = _servicesRepository.GetById(service3.ServiceId).ServiceId
            };

            _spDssServicesRepository.Create(spDssService3);



            // Office/ Service Center Locations

            var officeServiceCl1 = new TblOfficeServiceCl
            {
                Location = model.OfficeServClLocation1,
                CityId = model.OfficeServClCityId1,
                CountryId = model.OfficeServClCountryId1,
                SupplierId = SupplierId
            };

            _officeServiceClRepository.Create(officeServiceCl1);


            var officeServiceCl2 = new TblOfficeServiceCl
            {
                Location = model.OfficeServClLocation2,
                CityId = model.OfficeServClCityId2,
                CountryId = model.OfficeServClCountryId2,
                SupplierId = SupplierId
            };

            _officeServiceClRepository.Create(officeServiceCl2);


            var officeServiceCl3 = new TblOfficeServiceCl
            {
                Location = model.OfficeServClLocation3,
                CityId = model.OfficeServClCityId3,
                CountryId = model.OfficeServClCountryId3,
                SupplierId = SupplierId
            };

            _officeServiceClRepository.Create(officeServiceCl3);


            var officeServiceCl4 = new TblOfficeServiceCl
            {
                Location = model.OfficeServClLocation4,
                CityId = model.OfficeServClCityId4,
                CountryId = model.OfficeServClCountryId4,
                SupplierId = SupplierId
            };

            _officeServiceClRepository.Create(officeServiceCl4);



            // sub contracted services

            var scsService = new TblServices
            {
                ServiceName = model.SubConServiceName,
                //SupplierId = SupplierId,
            };

            _servicesRepository.Create(scsService);


            var subContractedService = new TblSubContractedServices
            {
                ServiceId = _servicesRepository.GetById(scsService.ServiceId).ServiceId,
                PercentageOutsourced = model.SubConPercentageOutsourced,
                SupplierId = SupplierId
            };
            _subContractedServicesRepository.Create(subContractedService);



            // sub-contractor name and details

            var subContractorDetails = new TblSubContractedDetails
            {
                SubServId = _subContractedServicesRepository.GetById(subContractedService.SubServId).SubServId,
                SubConName = model.SubConName,
                SubConAddress = model.SubConAddress,
                CountryId =  model.SubConCountryId,
                IsLocal = model.IsLocal
            };

            _subContractedDetailsRepository.Create(subContractorDetails);


            // foreign companies being represented

            var foreignCompanyProduct = new TblProducts
            {
                ProductName = model.ProductSupplied,
                //SupplierId = SupplierId,
            };

            _productsRepository.Create(foreignCompanyProduct);


            var foreignCompany = new TblForeignCompany
            {
                CompanyName  = model.ForeignCompanyName,
                ProductSupplied = _productsRepository.GetById(foreignCompanyProduct.ProductId).ProductId,
                Status = model.Status,
                SupplierId = SupplierId,
                Others = model.Others
            };

            _foreignCompanyRepository.Create(foreignCompany);



            /*Business Experience*/

            var businessExperience = new TblBusinessExperience
            {
                SupplierId = SupplierId,
                FinancialTurnover = int.Parse(model.FinancialTurnOver),
                RegistrationDate = model.KDGSStartDate,
                CompanyWorkedWith = model.CompanyWorkedWith1,
                TimeFrame = model.TimeFrame1,
                TransactionReference = UploadFile(model.TransactionReference1),
                ScopeCovered = model.ScopeCovered1,
                HasContinuityPolicy = model.HasBusinessConPolicy,
                ContinuityPolicy = UploadFile(model.BizConPolicy)
                //
            };

            _businessExperienceRepository.Create(businessExperience);

            //var businessContinuityPolicy = new TblBusinessContinuityPolicy
            //{
            //    HasBizConPolicy = model.HasBizConPolicy,
            //    UploadedFile = UploadFile(model.BizConPolicy),
            //    SupplierId = SupplierId
            //};

            //_businessContinuityPolicyRepository.Create(businessContinuityPolicy);


            // knowledge of dgs systems

            //var productEquipmentService = new TblProductEquipmentService
            //{

            //};



            //var knowledgeDgssystems = new TblKnowledgeDgssysytems
            //{
            //    ContractNumber = model.KDGSContractNumber,
            //    ProdEquSerId  = model.ProdEquSerType,
            //    StartDate = model.KDGSStartDate,
            //    Dgsref = model.Dgsref,
            //    SupplierId = SupplierId,
            //};


            //_knowledgeDgssystemsRepository.Create(knowledgeDgssystems);

            // main customers

            //var mainCustomers = new TblMainCustomers
            //{
            //    CustomerName = model.CustomerName,
            //    CountryId = model.CustomerCountryId,
            //    //ProdEquSerId = model.CustomerProdEquSerId,
            //    ValueId = model.ValueId,
            //    SupplierId = SupplierId

            //};

            //_mainCustomersRepository.Create(mainCustomers);





            /*Staff Strength and Competences*/

            var staffStrengthComp = new TblStaffStrengthComp
            {
                StaffPolicy = UploadFile(model.StaffPolicy),
                Audit3rdParty = UploadFile(model.Audit3rdParty),
                SupplierId = SupplierId
            };

            _staffStrCompRepository.Create(staffStrengthComp);

            var noOfEmployees1 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 1,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees1,
                NoOfContractEmp = model.NoOfContractEmp1,
                NoOfExpatriates = model.NoOfExpatriates1
            };

            _numberOfEmployeesRepository.Create(noOfEmployees1);

            var noOfEmployees2 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 2,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees2,
                NoOfContractEmp = model.NoOfContractEmp2,
                NoOfExpatriates = model.NoOfExpatriates2
            };

            _numberOfEmployeesRepository.Create(noOfEmployees2);

            var noOfEmployees3 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 3,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees3,
                NoOfContractEmp = model.NoOfContractEmp3,
                NoOfExpatriates = model.NoOfExpatriates3
            };

            _numberOfEmployeesRepository.Create(noOfEmployees3);

            var noOfEmployees4 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 4,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees4,
                NoOfContractEmp = model.NoOfContractEmp4,
                NoOfExpatriates = model.NoOfExpatriates4
            };

            _numberOfEmployeesRepository.Create(noOfEmployees4);

            var noOfEmployees5 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 5,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees5,
                NoOfContractEmp = model.NoOfContractEmp5,
                NoOfExpatriates = model.NoOfExpatriates5
            };

            _numberOfEmployeesRepository.Create(noOfEmployees5);

            var noOfEmployees6 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 6,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees6,
                NoOfContractEmp = model.NoOfContractEmp6,
                NoOfExpatriates = model.NoOfExpatriates6
            };

            _numberOfEmployeesRepository.Create(noOfEmployees6);

            var noOfEmployees7 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 7,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees7,
                NoOfContractEmp = model.NoOfContractEmp7,
                NoOfExpatriates = model.NoOfExpatriates7
            };

            _numberOfEmployeesRepository.Create(noOfEmployees7);

            var noOfEmployees8 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 8,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees8,
                NoOfContractEmp = model.NoOfContractEmp8,
                NoOfExpatriates = model.NoOfExpatriates8
            };

            _numberOfEmployeesRepository.Create(noOfEmployees8);

            var noOfEmployees9 = new TblNumberofEmployees
            {
                //SupplierId = SupplierId,
                DepartmentId = 9,
                StaffStrCompId = _staffStrCompRepository.GetById(staffStrengthComp.StaffStrCompId).StaffStrCompId,
                NoOfEmployees = model.NoOfEmployees9,
                NoOfContractEmp = model.NoOfContractEmp9,
                NoOfExpatriates = model.NoOfExpatriates9
            };

            _numberOfEmployeesRepository.Create(noOfEmployees9);




            /*Financials*/

            var financialStatements = new TblFinancialStatements
            {
                SupplierId = SupplierId,
                TaxIdentificationNo = model.TaxIdentificationNumber,
                FinancialStatementYear1 = UploadFile(model.FinancialStatement1),
                FinancialStatementYear2 = UploadFile(model.FinancialStatement2),
                FinancialStatementYear3 = UploadFile(model.FinancialStatement3),
                AuditorName = model.AuditorName,
                AuditorAddress = model.AuditorAddress,
                ContactNumber = model.AuditorContactNumber,
                IsListed = model.IsListed,
                StockMarketInfo = UploadFile(model.StockMktInfo)
            };

            _financialStatementsRepository.Create(financialStatements);


            //var financialAudits = new TblFinancialAudits
            //{
            //    SupplierId = SupplierId,
            //    FinancialAudit = UploadFile(model.FinancialAudit),
            //    AuditorName = model.AuditorName,
            //    AuditorAddress = model.AuditorAddress,
            //    ContactNumber = model.AuditorContactNumber
            //};

            //_financialAuditsRepository.Create(financialAudits);

            //var finStockMarketInfo = new TblFinStockMarketInfo
            //{
            //    SupplierId = SupplierId,
            //    IsListed = model.IsListed
            //};

            //_finStockMarketInfoRepository.Create(finStockMarketInfo);




            /*Quality Management*/

            var qualityManagement = new TblQualityManagement
            {
                SupplierId = SupplierId,
                QualityPolicy  = UploadFile(model.QualityPolicy),
                ProductQualMgt = UploadFile(model.ProductQualMgt),
                QualityMgt = UploadFile(model.QualityMgt),
                QualManagerName = model.QualManagerName,
                QualManagerEmail = model.QualManagerEmail,
                PhoneNumber = model.QualManagerPhoneNumber,
                WorkPhoneNumber  = model.QualManagerWorkPhoneNumber,
                Fax = model.QualManagerFax
            };

            _qualityManagementRepository.Create(qualityManagement);



            var certifyingOrg = new TblCertifyingOrg
            {
                CertOrgName  = model.CertOrgName
            };

            _certifyingOrgRepository.Create(certifyingOrg);


            var qualityCertification = new TblQualityCertification
            {
                SupplierId = SupplierId,
                Details = model.QualCertDetails,
                NameofCertificate = model.NameofCertificate,
                CertificateCopy = UploadFile(model.CertificateCopy),
                CertOrgId = _certifyingOrgRepository.GetById(certifyingOrg.CertOrgId).CertOrgId,
                ValidityDate = model.ValidityDate??null,

            };

            _qualityCertificationRepository.Create(qualityCertification);




            /*Health Safety and Environment*/

            var hse = new TblHealthSafetyEnvironment
            {
                SupplierId = SupplierId,
                Hsepolicy = UploadFile(model.Hsepolicy),
                ThirdPartyAudit = UploadFile(model.HseThirdPartyAudit),
                HseManagerName  = model.HseManagerName,
                HseManagerEmail = model.HseManagerEmail,
                PhoneNumber = model.HsePhoneNumber,
                WorkPhoneNumber = model.HseWorkPhoneNumber,
                Fax = model.HseFax,
                HseCompanyKpi = UploadFile(model.HseCompanyKpi),
                HseYearN1results = UploadFile(model.HseYearN1results),
                StaffTraining = UploadFile(model.HseStaffTraining)
            };

            _hseRepository.Create(hse);



            var hseCertifyingOrg = new TblCertifyingOrg
            {
                CertOrgName = model.HseCertOrgName
            };

            _certifyingOrgRepository.Create(hseCertifyingOrg);


            var hseCertification = new TblHseCertification
            {
                SupplierId = SupplierId,
                NameofCertificate  = model.HseNameofCertificate,
                CertOrgId = _certifyingOrgRepository.GetById(hseCertifyingOrg.CertOrgId).CertOrgId,
                ValidityDate = model.ValidityDate ?? null,
                CertificateCopy = UploadFile(model.CertificateCopy)
            };

            _hseCertificationRepository.Create(hseCertification);


            /*Coorporate Distinctives*/
            var corporateDistinctive1 = new TblCorporateDistinctives
            {
                SupplierId = SupplierId,
                Details = model.Details1
            };

            _corporateDistinctivesRepository.Create(corporateDistinctive1);

            var corporateDistinctive2 = new TblCorporateDistinctives
            {
                SupplierId = SupplierId,
                Details = model.Details2
            };

            _corporateDistinctivesRepository.Create(corporateDistinctive2);

            var corporateDistinctive3 = new TblCorporateDistinctives
            {
                SupplierId = SupplierId,
                Details = model.Details3
            };

            _corporateDistinctivesRepository.Create(corporateDistinctive3);

            var corporateDistinctive4 = new TblCorporateDistinctives
            {
                SupplierId = SupplierId,
                Details = model.Details4
            };

            _corporateDistinctivesRepository.Create(corporateDistinctive4);

            var corporateDistinctive5 = new TblCorporateDistinctives
            {
                SupplierId = SupplierId,
                Details = model.Details5
            };

            _corporateDistinctivesRepository.Create(corporateDistinctive5);



            /*Corporate social Responsibility*/

           if(model.SrethHumanLaborLaws != null)
            {
                foreach (var srehll in model.SrethHumanLaborLaws)
                {
                    var corpSocialResponsibility = new TblCorpSocialResponsibility
                    {
                        SupplierId = SupplierId,
                        SrethHumanLaborLaws = UploadFile(srehll),
                        ThirdPartySocAudit = UploadFile(model.ThirdPartySocAudit),
                        FraudMalpracticePolicy = UploadFile(model.FraudMalpracticePolicy)
                    };

                    _corpSocialResponsiblityRepository.Create(corpSocialResponsibility);
                }
            }

            // Vendor Reg Form Approval

           


            var vendorRegApprovalForm = new TblVendorRegFormApproval
            {
                SupplierId = SupplierId,
                // fill in form identification details
                FormId = FormId,
                VendorUsername = userEmail,
                FormIdentificationName = model.FormIdentificationName,
                FormIdentificationPosition = model.FormIdentificationPosition,
                FormIdentificationPhoneNumber = model.FormIdentificationPhoneNumber,
                FormIdentificationWorkPhoneNumber = model.FormIdentificationWorkPhoneNumber,
                FormIdentificationEmailAddress = model.FormIdentificationEmailAddress,
                FormIdentificationDate = model.FormIdentificationDate,
                VendorIsForeign = model.CompanyIsForeign,
                VendorCompanyName = model.SupplierIdentificationCompanyName,
                SubsidiaryCompanyName = model.SupplierIdentificationSubsidiaryCompanyName1,
                VendorHeadOfficeAddress = model.SupplierIdentificationHeadOfficeAddress,
                VendorCompanyRegistrationNumber = model.SupplierIdentificationCompanyRegNumber,
                MainContactPersonName = model.MainContactPersonName,
                MainContactPersonPosition = model.MainContactPosition,
                MainContactPersonPhone = model.MainContactPhoneNumber,
                MainContactPersonWorkPhone = model.MainContactWorkPhoneNumber,
                MainContactPersonEmail = model.MainContactEmailAddress,
                BankReference = ApprovalUploadFile(model.SupplierIdentificationBankReference),
                ThirdPartyRefName = model.TprName,
                ThirdPartyRefOrgAddress = model.TprAddress,
                ThirdPartyRefContactNo = model.TprPhoneNumber,
                ThirdPartyRefEmail = model.TprEmailAddress,
                VendorCompanyProfile = ApprovalUploadFile(model.SupplierIdentificationCompanyProfile),
                VendorCompanyWebsiteAddress = model.SupplierIdentificationCompanyWebsiteUrl,
                VendorNatureofBusiness = model.NatureOfBusiness,
                VendorCompanyDateofCreation = model.DateofCreation,
                OwnershipMainShareholders = model.MainShareholder1,
                PercentageShareholding = model.Shareholding1,
                //OwnershipNationality = _countryRepository.GetById(model.SupplierOwnershipCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                OwnershipNationality = model.SupplierOwnershipCountryId1.GetValueOrDefault(0).ToString(),
                DirectServiceScopeMaterials = model.MaterialsName1,
                DirectServiceScopeSubCategories = model.SubCategoryId1,
                TypicalSubContractedScopeProducts = model.ProductName1,
                TypicalSubContractedScopeName = model.TypicalSubConName1,
                TypicalSubContractedScopeAddress = model.TypicalSubConAddress1,
                TypicalSubContractedScopeNationality = model.TypicalSubConCountryId1.GetValueOrDefault(0).ToString(),
                //TypicalSubContractedScopeNationality = _countryRepository.GetById(model.TypicalSubConCountryId1.GetValueOrDefault(0)).CountryName ?? "none",
                TypicalSubContractedScopeIsLocal = model.TypicalSubConIsLocal1,
                Cymfgffcity = model.CyMfgFfCityId1.ToString(),
                //Cymfgffcity = _cityRepository.GetById(model.CyMfgFfCityId1.GetValueOrDefault(0)).CityName ?? null,
                CymfgffplantEquipmentType = model.CyMfgFfPlantsEquipmentType1,
                CymfgffplantEquipmentNumber = model.CyMfgFfPlantsEquipmentNumber1,
                Cymfgffutilization = model.CyMfgFfUtilization1,
                CymfgfffactoryArea = model.CyMfgFfFactoryArea1,
                SpdirectServiceScopeService = model.SpServices1,
                SpdirectServiceScopeServiceDetails = model.SpDssDescription1,
                SpofficeServiceCenterCity = model.OfficeServClCityId1.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCity = _cityRepository.GetById(model.OfficeServClCityId1.GetValueOrDefault(0)).CityName ?? null,
                SpofficeServiceCenterCountry = model.OfficeServClCountryId1.GetValueOrDefault(0).ToString(),
                //SpofficeServiceCenterCountry = _countryRepository.GetById(model.OfficeServClCountryId1.GetValueOrDefault(0)).CountryName ?? null,
                SpsubContractedServices = model.SubConServiceName,
                SpsubContractedServicesPercOutsourced = model.SubConPercentageOutsourced,
                SpsubContractorName = model.SubConName,
                SpsubContractorAddress = model.SubConAddress,
                SpsubContractorNationality = model.SubConCountryId.GetValueOrDefault(0).ToString(),
                //SpsubContractorNationality = _countryRepository.GetById(model.SubConCountryId.GetValueOrDefault(0)).CountryName ?? null,
                SpsubContractorIsLocal = model.IsLocal,
                AdforeignCompanyName = model.ForeignCompanyName,
                AdforeignCompanyProductSupplied = model.ProductSupplied,
                //AdforeignCompanyStatus = model.StatusList.Where(x => x.Value == model.Status.ToString()).FirstOrDefault().Text,
                AdforeignCompanyOther = model.Others,
                VendorOrganizationChart = ApprovalUploadFile(model.SupplierProfileOrganizationCharts),
                VendorMissionVisionStatement = ApprovalUploadFile(model.SupplierProfileMissionVisionStatement),
                //BusinessContinuityPolicy = ApprovalUploadFile(model.BizConPolicy),
                BusinessExFinancialTurnover = int.Parse(model.FinancialTurnOver),
                BusinessExContinuityPolicy = ApprovalUploadFile(model.BizConPolicy),
                BusinessExHasContinuityPolicy = model.HasBusinessConPolicy,
                BusinessExCompanyWorkedWith = model.CompanyWorkedWith1,
                BusinessExTimeFrame = model.TimeFrame1,
                BusinessExScopeCovered = model.ScopeCovered1,
                BusinessExRegistrationDate = model.KDGSStartDate,
                BusinessExTransactionReference = ApprovalUploadFile(model.TransactionReference1),
                KnowledgeofDgssystemsContractNo = model.KDGSContractNumber,
                KnowledgeofDgssystemsProdEquServ = model.ProdEquSerDescription,
                KnowledgeofDgssystemsStartDate = model.KDGSStartDate,
                KnowledgeofDgssystemsDgsref = model.Dgsref,
                VendorMainCustomerName = model.CustomerName,
                VendorMainCustomerCountry = model.CustomerCountryId.ToString(),
                //VendorMainCustomerCountry = _countryRepository.GetById(model.CustomerCountryId).CountryName,
                //VendorMainCustomerProductService = model.KDGSSType.Where(x => x.Value == model.KDGSProdEquSerId.ToString()).FirstOrDefault().Text,
                //VendorMainCustomerProductService = _productEquipmentServiceRepository.GetById(model.ProdEquSerType).Description,
                //VendorMainCustomerValueYear = int.Parse((model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text).Split("-")[1]),
                //VendorMainCustomerValue = model.MainCustomersValue.Where(x => x.Value == model.ValueId.ToString()).FirstOrDefault().Text,
                VendorCompanyDepartment = _departmentsRepository.GetAll().ToList()[0].DepartmentName,
                VendorCompanyNoofStaff = model.NoOfEmployees1,
                VendorCompanyNoofContractStaff = model.NoOfContractEmp1,
                VendorCompanyNoofExpatriates = model.NoOfExpatriates1,
                CodeofConduct = ApprovalUploadFile(model.CodeOfConduct),
                StaffTrainingPolicy = ApprovalUploadFile(model.StaffPolicy),
                StaffTrainingPolicyThirdPartyAudit = ApprovalUploadFile(model.ThirdPartySocAudit),
                FinancialStatementYear1 = ApprovalUploadFile(model.FinancialStatement1),
                FinancialStatementYear2 = ApprovalUploadFile(model.FinancialStatement2),
                FinancialStatementYear3 = ApprovalUploadFile(model.FinancialStatement3),
                FinancialAuditorName = model.AuditorName,
                FinancialAuditorAddress = model.AuditorAddress,
                FinancialAuditorContactNumber = model.AuditorContactNumber,
                IsListedStockMarket = model.IsListed,
                QualityPolicy = ApprovalUploadFile(model.QualityPolicy),
                ProductQualityManagement = ApprovalUploadFile(model.ProductQualMgt),
                QualityManagement = ApprovalUploadFile(model.QualityMgt),
                QualityManagerName = model.QualManagerName,
                QualityManagerEmail = model.QualManagerEmail,
                QualityManagerPhoneNumber = model.QualManagerPhoneNumber,
                QualityManagerWorkPhoneNo = model.QualManagerWorkPhoneNumber,
                QualityManagerFaxNumber = model.QualManagerFax,
                QualityCertificationName = model.NameofCertificate,
                QualityCertificationCertOrganization = model.CertOrgName,
                QualityCertficationValidityDate = model.ValidityDate ?? null,
                HealthSafetyEnvironmentPolicy = ApprovalUploadFile(model.Hsepolicy),
                HsethirdPartyAudit = ApprovalUploadFile(model.HseThirdPartyAudit),
                HsemanagerName = model.HseManagerName,
                HsemanagerEmail = model.HseManagerEmail,
                HsephoneNumber = model.HsePhoneNumber,
                HseworkPhoneNumber = model.HseWorkPhoneNumber,
                HsefaxNumber = model.HseFax,
                HsecompanyKpi = ApprovalUploadFile(model.HseCompanyKpi),
                HsecompanyYearN1results = ApprovalUploadFile(model.HseYearN1results),
                HsestaffTrainingPolicy = ApprovalUploadFile(model.HseStaffTraining),
                HsecertificationName = model.HseNameofCertificate,
                HsecertificationCertAuthority = model.HseCertOrgName,
                HsecertficationValidityDate = model.HseValidityDate ?? null,
                CorporateDistinctives = model.Details1,
                CsrsocRespEthHumanLaborLaws = ApprovalUploadFile(model.SrethHumanLaborLaws?? null),
                VendorThirdPartySocialAudit = ApprovalUploadFile(model.ThirdPartySocAudit),
                VendorFraudMalpracticePolicy = ApprovalUploadFile(model.FraudMalpracticePolicy),
                ApprovalStatus = 0
            };

            _vendorRegFormApprovalRepository.Create(vendorRegApprovalForm);

            return RedirectToAction("FormSuccessful");
        }

        [HttpGet]
        public IActionResult FormSuccessful()
        {            
            return View();
        }


        public string UploadFile(IFormFile formFile)
        {
            if(formFile != null )
            {
                // If the FormFile property on the incoming model object is not null, then the user
                // has selected an image to upload.
                
                
                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                formFile.CopyTo(new FileStream(filePath, FileMode.Create));

                //assign vessel photo URL
                return uniqueFileName;
                

                
            }

            var returnUrl = "invalidfileUpload";
            return returnUrl;
        }


        public string ApprovalUploadFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                // If the FormFile property on the incoming model object is not null, then the user
                // has selected an image to upload.


                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "approvaluploads");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                formFile.CopyTo(new FileStream(filePath, FileMode.Create));

                //assign vessel photo URL
                return uniqueFileName;



            }

            var returnUrl = "invalidfileUpload";
            return returnUrl;
        }

        public string ApprovalUploadFile(IEnumerable<IFormFile> formFiles)
        {
            if (formFiles != null)
            {
                foreach(var formFile in formFiles)
                {
                    // If the FormFile property on the incoming model object is not null, then the user
                    // has selected an image to upload.


                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "approvaluploads");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    formFile.CopyTo(new FileStream(filePath, FileMode.Create));

                    //assign vessel photo URL
                    return uniqueFileName;

                }


            }

            var returnUrl = "invalidfileUpload";
            return returnUrl;
        }

        public IActionResult VendorFormDetails(int id)
        {
            var vendor = _vendorRegFormApprovalRepository.GetById(id);
            //var formIdentification = _formIdentificationRepository.GetById(vendor.id)
            var model = new FormViewVendorModel
            {
                VendorForm = vendor
            };

            return View(model);
        }


        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot\\approvaluploads\\", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, MediaTypeNames.Application.Octet, Path.GetFileName(path));
        }

    }
}
