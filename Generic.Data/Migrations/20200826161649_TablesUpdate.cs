using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Generic.Data.Migrations
{
    public partial class TablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "1");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "2");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "tbl_VendorRegFormApproval",
            //    columns: table => new
            //    {
            //        VendorApprovalID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        VendorCompanyName = table.Column<string>(maxLength: 100, nullable: true),
            //        SubsidiaryCompanyName = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorHeadOfficeAddress = table.Column<string>(maxLength: 200, nullable: true),
            //        VendorCompanyRegistrationNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        MainContactPersonName = table.Column<string>(maxLength: 100, nullable: true),
            //        MainContactPersonPosition = table.Column<string>(maxLength: 50, nullable: true),
            //        MainContactPersonPhone = table.Column<string>(maxLength: 20, nullable: true),
            //        MainContactPersonEmail = table.Column<string>(maxLength: 50, nullable: true),
            //        BankReference = table.Column<string>(maxLength: 100, nullable: true),
            //        ThirdPartyRefName = table.Column<string>(maxLength: 100, nullable: true),
            //        ThirdPartyRefOrgAddress = table.Column<string>(maxLength: 200, nullable: true),
            //        ThirdPartyRefContactNo = table.Column<string>(maxLength: 20, nullable: true),
            //        ThirdPartyRefEmail = table.Column<string>(maxLength: 50, nullable: true),
            //        VendorCompanyProfile = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorCompanyWebsiteAddress = table.Column<string>(maxLength: 50, nullable: true),
            //        VendorNatureofBusiness = table.Column<string>(maxLength: 500, nullable: true),
            //        VendorCompanyDateofCreation = table.Column<DateTime>(type: "datetime", nullable: true),
            //        OwnershipMainShareholders = table.Column<string>(maxLength: 100, nullable: true),
            //        PercentageShareholding = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        OwnershipNationality = table.Column<string>(maxLength: 50, nullable: true),
            //        DirectServiceScopeMaterials = table.Column<string>(maxLength: 100, nullable: true),
            //        DirectServiceScopeSubCategories = table.Column<string>(maxLength: 100, nullable: true),
            //        TypicalSubContractedScopeProducts = table.Column<string>(maxLength: 50, nullable: true),
            //        TypicalSubContractedScopeName = table.Column<string>(maxLength: 100, nullable: true),
            //        TypicalSubContractedScopeAddress = table.Column<string>(maxLength: 100, nullable: true),
            //        TypicalSubContractedScopeNationality = table.Column<string>(maxLength: 50, nullable: true),
            //        TypicalSubContractedScopeIsLocal = table.Column<bool>(nullable: true),
            //        CYMFGFFCity = table.Column<string>(maxLength: 50, nullable: true),
            //        CYMFGFFPlantEquipmentType = table.Column<string>(maxLength: 50, nullable: true),
            //        CYMFGFFPlantEquipmentNumber = table.Column<int>(nullable: true),
            //        CYMFGFFUtilization = table.Column<string>(maxLength: 100, nullable: true),
            //        CYMFGFFFactoryArea = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        SPDirectServiceScopeService = table.Column<string>(maxLength: 100, nullable: true),
            //        SPDirectServiceScopeServiceDetails = table.Column<string>(nullable: true),
            //        SPOfficeServiceCenterCity = table.Column<string>(maxLength: 50, nullable: true),
            //        SPOfficeServiceCenterCountry = table.Column<string>(maxLength: 50, nullable: true),
            //        SPSubContractedServices = table.Column<string>(maxLength: 100, nullable: true),
            //        SPSubContractedServicesPercOutsourced = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        SPSubContractorName = table.Column<string>(maxLength: 100, nullable: true),
            //        SPSubContractorAddress = table.Column<string>(maxLength: 200, nullable: true),
            //        SPSubContractorNationality = table.Column<string>(maxLength: 50, nullable: true),
            //        SPSubContractorIsLocal = table.Column<bool>(nullable: true),
            //        ADForeignCompanyName = table.Column<string>(maxLength: 100, nullable: true),
            //        ADForeignCompanyProductSupplied = table.Column<string>(maxLength: 100, nullable: true),
            //        ADForeignCompanyStatus = table.Column<string>(maxLength: 20, nullable: true),
            //        ADForeignCompanyOther = table.Column<string>(nullable: true),
            //        VendorOrganizationChart = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorMissionVisionStatement = table.Column<string>(maxLength: 100, nullable: true),
            //        BusinessContinuityPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        KnowledgeofDGSSystemsContractNo = table.Column<string>(maxLength: 50, nullable: true),
            //        KnowledgeofDGSSystemsProdEquServ = table.Column<string>(maxLength: 100, nullable: true),
            //        KnowledgeofDGSSystemsStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        KnowledgeofDGSSystemsDGSRef = table.Column<string>(maxLength: 50, nullable: true),
            //        VendorMainCustomerName = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorMainCustomerCountry = table.Column<string>(maxLength: 50, nullable: true),
            //        VendorMainCustomerProductService = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorMainCustomerValueYear = table.Column<int>(nullable: true),
            //        VendorMainCustomerValue = table.Column<string>(maxLength: 50, nullable: true),
            //        VendorCompanyDepartment = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorCompanyNoofStaff = table.Column<int>(nullable: true),
            //        VendorCompanyNoofContractStaff = table.Column<int>(nullable: true),
            //        VendorCompanyNoofExpatriates = table.Column<int>(nullable: true),
            //        CodeofConduct = table.Column<string>(maxLength: 100, nullable: true),
            //        StaffTrainingPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        StaffTrainingPolicyThirdPartyAudit = table.Column<string>(maxLength: 100, nullable: true),
            //        FinancialStatements = table.Column<string>(maxLength: 100, nullable: true),
            //        FinancialStatementAnnualReport = table.Column<string>(maxLength: 100, nullable: true),
            //        FinancialAudits = table.Column<string>(maxLength: 100, nullable: true),
            //        FinancialAuditorName = table.Column<string>(maxLength: 100, nullable: true),
            //        FinancialAuditorAddress = table.Column<string>(maxLength: 200, nullable: true),
            //        FinancialAuditorContactNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        IsListedStockMarket = table.Column<bool>(nullable: true),
            //        QualityPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        ProductQualityManagement = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityManagement = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityManagerName = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityManagerEmail = table.Column<string>(maxLength: 200, nullable: true),
            //        QualityManagerPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        QualityManagerWorkPhoneNo = table.Column<string>(maxLength: 20, nullable: true),
            //        QualityManagerFaxNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        QualityCertificationName = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityCertificationCertOrganization = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityCertficationValidityDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        HealthSafetyEnvironmentPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        HSEThirdPartyAudit = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
            //        HSEManagerName = table.Column<string>(maxLength: 100, nullable: true),
            //        HSEManagerEmail = table.Column<string>(maxLength: 200, nullable: true),
            //        HSEPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        HSEWorkPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        HSEFaxNumber = table.Column<string>(maxLength: 20, nullable: true),
            //        HSECompanyKPI = table.Column<string>(maxLength: 100, nullable: true),
            //        HSECompanyYearN1Results = table.Column<string>(maxLength: 100, nullable: true),
            //        HSEStaffTrainingPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        HSECertificationName = table.Column<string>(maxLength: 100, nullable: true),
            //        HSECertificationCertAuthority = table.Column<string>(maxLength: 100, nullable: true),
            //        HSECertficationValidityDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        CorporateDistinctives = table.Column<string>(maxLength: 200, nullable: true),
            //        CSRSocRespEthHumanLaborLaws = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorThirdPartySocialAudit = table.Column<string>(maxLength: 100, nullable: true),
            //        VendorFraudMalpracticePolicy = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_VendorRegFormApproval", x => x.VendorApprovalID);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "([NormalizedUserName] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "([NormalizedName] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "tbl_VendorRegFormApproval");

            //migrationBuilder.DropIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "1", null, "Admin", "ADMIN" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "2", null, "Default", "DEFAULT" });

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");
        }
    }
}
