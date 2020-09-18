using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Generic.Data.Migrations
{
    public partial class AddAspNetIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OtherName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    LinkedIn = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    JobsCompleted = table.Column<int>(nullable: true),
                    OnTime = table.Column<int>(nullable: true),
                    OnBudget = table.Column<int>(nullable: true),
                    RepeatHireRate = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CertifyingOrg",
            //    columns: table => new
            //    {
            //        CertOrgID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CertOrgName = table.Column<string>(maxLength: 500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CertifyingOrg", x => x.CertOrgID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_City",
            //    columns: table => new
            //    {
            //        CityID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CityCode = table.Column<string>(maxLength: 10, nullable: false),
            //        CityName = table.Column<string>(maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_City", x => x.CityID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_ContactPersons",
            //    columns: table => new
            //    {
            //        ContactPersonID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ContactPersonName = table.Column<string>(maxLength: 500, nullable: false),
            //        Position = table.Column<string>(maxLength: 100, nullable: false),
            //        PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        WorkPhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        EmailAddress = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_ContactPersons", x => x.ContactPersonID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Country",
            //    columns: table => new
            //    {
            //        CountryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CountryCode = table.Column<string>(maxLength: 10, nullable: false),
            //        CountryName = table.Column<string>(maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Country", x => x.CountryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Departments",
            //    columns: table => new
            //    {
            //        DepartmentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentName = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Departments", x => x.DepartmentID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_FormIdentification",
            //    columns: table => new
            //    {
            //        FormID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 500, nullable: false),
            //        Position = table.Column<string>(maxLength: 100, nullable: false),
            //        PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        WorkPhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_FormIdentification", x => x.FormID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PaymentBank",
            //    columns: table => new
            //    {
            //        PymntBankID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PaymentBankName = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PaymentBank", x => x.PymntBankID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_ProductEquipmentService",
            //    columns: table => new
            //    {
            //        ProdEquSerID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Type = table.Column<int>(nullable: false),
            //        Description = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_ProductEquipmentService", x => x.ProdEquSerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_State",
            //    columns: table => new
            //    {
            //        StateID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StateCode = table.Column<string>(maxLength: 10, nullable: false),
            //        StateName = table.Column<string>(maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_State", x => x.StateID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_ThirdPartyReference",
            //    columns: table => new
            //    {
            //        TPR_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TPR_Name = table.Column<string>(maxLength: 500, nullable: false),
            //        TPR_Organization = table.Column<string>(maxLength: 100, nullable: false),
            //        TPR_Address = table.Column<string>(maxLength: 500, nullable: false),
            //        TPR_PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        TPR_WorkPhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        TPR_EmailAddress = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_ThirdPartyReference", x => x.TPR_ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_ValueDetails",
            //    columns: table => new
            //    {
            //        ValueID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ValueYear = table.Column<int>(nullable: false),
            //        Value = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_ValueDetails", x => x.ValueID);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "tbl_TypicalSubcontractedScope",
            //    columns: table => new
            //    {
            //        SubConScopeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SubConName = table.Column<string>(maxLength: 500, nullable: false),
            //        SubConAddress = table.Column<string>(maxLength: 500, nullable: false),
            //        CountryID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_TypicalSubcontractedScope", x => x.SubConScopeID);
            //        table.ForeignKey(
            //            name: "FK_tbl_TypicalSubcontractedScope_tbl_Country",
            //            column: x => x.CountryID,
            //            principalTable: "tbl_Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_KnowledgeDGSSysytems",
            //    columns: table => new
            //    {
            //        KnowDGSSysID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ContractNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        ProdEquSerID = table.Column<int>(nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        DGSRef = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_KnowledgeDGSSysytems", x => x.KnowDGSSysID);
            //        table.ForeignKey(
            //            name: "FK_tbl_KnowledgeDGSSysytems_tbl_ProductEquipmentService",
            //            column: x => x.ProdEquSerID,
            //            principalTable: "tbl_ProductEquipmentService",
            //            principalColumn: "ProdEquSerID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SupplierIdentification",
            //    columns: table => new
            //    {
            //        SupplierID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FormID = table.Column<int>(nullable: false),
            //        CompanyName = table.Column<string>(maxLength: 500, nullable: false),
            //        HeadOfficeAddress = table.Column<string>(maxLength: 500, nullable: false),
            //        CompanyRegNumber = table.Column<string>(maxLength: 100, nullable: false),
            //        TaxClearanceCertificate = table.Column<string>(maxLength: 100, nullable: false),
            //        ContactPersonID = table.Column<int>(nullable: false),
            //        BankReference = table.Column<string>(maxLength: 100, nullable: false),
            //        ThirdPartyReference = table.Column<string>(maxLength: 100, nullable: false),
            //        TPR_ID = table.Column<int>(nullable: false),
            //        CompanyProfile = table.Column<string>(maxLength: 100, nullable: false),
            //        CompanyWebsiteURL = table.Column<string>(maxLength: 100, nullable: false),
            //        OrganizationCharts = table.Column<string>(maxLength: 100, nullable: false),
            //        MissionVisionStatement = table.Column<string>(nullable: false),
            //        CodeofConduct = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SupplierIdentification", x => x.SupplierID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierIdentification_tbl_ContactPersons",
            //            column: x => x.ContactPersonID,
            //            principalTable: "tbl_ContactPersons",
            //            principalColumn: "ContactPersonID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierIdentification_tbl_FormIdentification",
            //            column: x => x.FormID,
            //            principalTable: "tbl_FormIdentification",
            //            principalColumn: "FormID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierIdentification_tbl_ThirdPartyReference",
            //            column: x => x.TPR_ID,
            //            principalTable: "tbl_ThirdPartyReference",
            //            principalColumn: "TPR_ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Approval",
            //    columns: table => new
            //    {
            //        ApprovalID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        Title = table.Column<string>(maxLength: 100, nullable: false),
            //        Signature = table.Column<string>(maxLength: 100, nullable: false),
            //        Approval_date = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Approval", x => x.ApprovalID);
            //        table.ForeignKey(
            //            name: "FK_tbl_Approval_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_BusinessContinuityPolicy",
            //    columns: table => new
            //    {
            //        BizConPolID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        HasBizConPolicy = table.Column<bool>(nullable: false),
            //        UploadedFile = table.Column<string>(maxLength: 100, nullable: true),
            //        SupplierID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_BusinessContinuityPolicy", x => x.BizConPolID);
            //        table.ForeignKey(
            //            name: "FK_tbl_BusinessContinuityPolicy_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CorporateDistinctives",
            //    columns: table => new
            //    {
            //        CorpDisID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        Details = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CorporateDistinctives", x => x.CorpDisID);
            //        table.ForeignKey(
            //            name: "FK_tbl_CorporateDistinctives_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CorpSocialResponsibility",
            //    columns: table => new
            //    {
            //        CSR_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        SREthHumanLaborLaws = table.Column<string>(maxLength: 100, nullable: false),
            //        ThirdPartySocAudit = table.Column<string>(maxLength: 100, nullable: true),
            //        FraudMalpracticePolicy = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CorpSocialResponsibility", x => x.CSR_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_CorpSocialResponsibility_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_CY_MFG_FF",
            //    columns: table => new
            //    {
            //        CY_MFG_FF_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Location = table.Column<string>(maxLength: 500, nullable: false),
            //        CityID = table.Column<int>(nullable: false),
            //        PlantsEquipmentType = table.Column<string>(maxLength: 500, nullable: true),
            //        PlantsEqiupmentNumber = table.Column<int>(nullable: true),
            //        Utilization = table.Column<string>(maxLength: 500, nullable: true),
            //        FactoryArea = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        SupplierID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CY_MFG_FF", x => x.CY_MFG_FF_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_CY_MFG_FF_tbl_City",
            //            column: x => x.CityID,
            //            principalTable: "tbl_City",
            //            principalColumn: "CityID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_CY_MFG_FF_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_FinancialAudits",
            //    columns: table => new
            //    {
            //        FinAudID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        FinancialAudit = table.Column<string>(maxLength: 100, nullable: true),
            //        AuditorName = table.Column<string>(maxLength: 500, nullable: false),
            //        AuditorAddress = table.Column<string>(maxLength: 500, nullable: false),
            //        ContactNumber = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_FinancialAudits", x => x.FinAudID);
            //        table.ForeignKey(
            //            name: "FK_tbl_FinancialAudits_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_FinancialStatements",
            //    columns: table => new
            //    {
            //        FinStatID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        FinancialStatement = table.Column<string>(maxLength: 100, nullable: true),
            //        AnnualReport = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_FinancialStatements", x => x.FinStatID);
            //        table.ForeignKey(
            //            name: "FK_tbl_FinancialStatements_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_FinStockMarketInfo",
            //    columns: table => new
            //    {
            //        StockMktInfoID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        IsListed = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_FinStockMarketInfo", x => x.StockMktInfoID);
            //        table.ForeignKey(
            //            name: "FK_tbl_FinStockMarketInfo_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_HealthSafetyEnvironment",
            //    columns: table => new
            //    {
            //        HSE_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        HSEPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        ThirdPartyAudit = table.Column<string>(maxLength: 100, nullable: true),
            //        HSE_ManagerName = table.Column<string>(maxLength: 200, nullable: false),
            //        HSE_ManagerEmail = table.Column<string>(maxLength: 100, nullable: false),
            //        PhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
            //        WorkPhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
            //        Fax = table.Column<string>(maxLength: 100, nullable: true),
            //        HSE_CompanyKPI = table.Column<string>(maxLength: 100, nullable: true),
            //        HSE_YearN1Results = table.Column<string>(maxLength: 100, nullable: true),
            //        StaffTraining = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_HealthSafetyEnvironment", x => x.HSE_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_HealthSafetyEnvironment_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_HSE_Certification",
            //    columns: table => new
            //    {
            //        HSE_CertID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        NameofCertificate = table.Column<string>(maxLength: 200, nullable: false),
            //        CertOrgID = table.Column<int>(nullable: false),
            //        ValidityDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CertificateCopy = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_HSE_Certification", x => x.HSE_CertID);
            //        table.ForeignKey(
            //            name: "FK_tbl_HSE_Certification_tbl_CertifyingOrg",
            //            column: x => x.CertOrgID,
            //            principalTable: "tbl_CertifyingOrg",
            //            principalColumn: "CertOrgID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_HSE_Certification_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_MainCustomers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerName = table.Column<string>(maxLength: 20, nullable: false),
            //        CountryID = table.Column<int>(nullable: false),
            //        ProdEquSerID = table.Column<int>(nullable: false),
            //        ValueID = table.Column<int>(nullable: false),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_MainCustomers", x => x.CustomerID);
            //        table.ForeignKey(
            //            name: "FK_tbl_MainCustomers_tbl_Country",
            //            column: x => x.CountryID,
            //            principalTable: "tbl_Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_MainCustomers_tbl_ProductEquipmentService",
            //            column: x => x.ProdEquSerID,
            //            principalTable: "tbl_ProductEquipmentService",
            //            principalColumn: "ProdEquSerID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_MainCustomers_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_MainCustomers_tbl_ValueDetails",
            //            column: x => x.ValueID,
            //            principalTable: "tbl_ValueDetails",
            //            principalColumn: "ValueID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_NumberOfEmployees",
            //    columns: table => new
            //    {
            //        NoOfEmpID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        DepartmentID = table.Column<int>(nullable: false),
            //        NoOfEmployees = table.Column<int>(nullable: true),
            //        NoOfContractEmp = table.Column<int>(nullable: true),
            //        NoOfExpatriates = table.Column<int>(nullable: true),
            //        StaffPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        Audit3rdParty = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_NumberOfEmployees", x => x.NoOfEmpID);
            //        table.ForeignKey(
            //            name: "FK_tbl_NumberOfEmployees_tbl_Departments",
            //            column: x => x.DepartmentID,
            //            principalTable: "tbl_Departments",
            //            principalColumn: "DepartmentID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_NumberOfEmployees_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_OfficeServiceCL",
            //    columns: table => new
            //    {
            //        OfficeServCL_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SP_Services = table.Column<string>(maxLength: 500, nullable: false),
            //        Location = table.Column<string>(maxLength: 500, nullable: false),
            //        CityID = table.Column<int>(nullable: false),
            //        CountryID = table.Column<int>(nullable: false),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_OfficeServiceCL", x => x.OfficeServCL_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_OfficeServiceCL_tbl_City",
            //            column: x => x.CityID,
            //            principalTable: "tbl_City",
            //            principalColumn: "CityID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_OfficeServiceCL_tbl_Country",
            //            column: x => x.CountryID,
            //            principalTable: "tbl_Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_OfficeServiceCL_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PaymentRequestMaster",
            //    columns: table => new
            //    {
            //        PayReqMasterID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PymntBankID = table.Column<int>(nullable: false),
            //        SupplierID = table.Column<int>(nullable: false),
            //        Payee = table.Column<string>(maxLength: 200, nullable: false),
            //        AccountNumber = table.Column<string>(maxLength: 20, nullable: false),
            //        DepartmentProject = table.Column<int>(nullable: false),
            //        PayReqDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        PONumber = table.Column<string>(maxLength: 50, nullable: false),
            //        PayReqNumber = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "(newid())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PaymentRequestMaster", x => x.PayReqMasterID);
            //        table.ForeignKey(
            //            name: "FK_tbl_PaymentRequestMaster_tbl_Departments",
            //            column: x => x.DepartmentProject,
            //            principalTable: "tbl_Departments",
            //            principalColumn: "DepartmentID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_PaymentRequestMaster_tbl_PaymentBank",
            //            column: x => x.PymntBankID,
            //            principalTable: "tbl_PaymentBank",
            //            principalColumn: "PymntBankID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_PaymentRequestMaster_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Products",
            //    columns: table => new
            //    {
            //        ProductID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductName = table.Column<string>(maxLength: 200, nullable: false),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Products", x => x.ProductID);
            //        table.ForeignKey(
            //            name: "FK_tbl_Products_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PurchaseOrder",
            //    columns: table => new
            //    {
            //        PO_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        IssuedTo = table.Column<string>(maxLength: 200, nullable: false),
            //        IssuedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        QuoteRef = table.Column<string>(maxLength: 500, nullable: false),
            //        POCode = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PurchaseOrder", x => x.PO_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_PurchaseOrder_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QualityCertification",
            //    columns: table => new
            //    {
            //        QualCertID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        Details = table.Column<string>(nullable: false),
            //        NameofCertificate = table.Column<string>(maxLength: 200, nullable: false),
            //        CertOrgID = table.Column<int>(nullable: false),
            //        ValidityDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CertificateCopy = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_QualityCertification", x => x.QualCertID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QualityCertification_tbl_CertifyingOrg",
            //            column: x => x.CertOrgID,
            //            principalTable: "tbl_CertifyingOrg",
            //            principalColumn: "CertOrgID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_QualityCertification_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QualityManagement",
            //    columns: table => new
            //    {
            //        QualMgtID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        QualityPolicy = table.Column<string>(maxLength: 100, nullable: true),
            //        ProductQualMgt = table.Column<string>(maxLength: 100, nullable: true),
            //        QualityMgt = table.Column<string>(maxLength: 100, nullable: true),
            //        QualManagerName = table.Column<string>(maxLength: 200, nullable: false),
            //        QualManagerEmail = table.Column<string>(maxLength: 100, nullable: false),
            //        PhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
            //        WorkPhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
            //        Fax = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_QualityManagement", x => x.QualMgtID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QualityManagement_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QuotationMasters",
            //    columns: table => new
            //    {
            //        QuoMasterID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        RFQNumber = table.Column<string>(maxLength: 50, nullable: false),
            //        QuotationDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Project = table.Column<string>(maxLength: 500, nullable: false),
            //        Client = table.Column<string>(maxLength: 100, nullable: false),
            //        RequestTitle = table.Column<string>(maxLength: 200, nullable: false),
            //        FormNumber = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "(newid())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("tbl_QuotationMaster", x => x.QuoMasterID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QuotationMaster_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Services",
            //    columns: table => new
            //    {
            //        ServiceID = table.Column<int>(nullable: false),
            //        ServiceName = table.Column<string>(maxLength: 200, nullable: false),
            //        SupplierID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Services", x => x.ServiceID);
            //        table.ForeignKey(
            //            name: "FK_tbl_Services_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SP_DirectServiceScope",
            //    columns: table => new
            //    {
            //        SP_DSS_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(nullable: false),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SP_DirectServiceScope", x => x.SP_DSS_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SP_DirectServiceScope_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SubCategory",
            //    columns: table => new
            //    {
            //        SubCategoryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 200, nullable: false),
            //        SupplierID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SubCategory", x => x.SubCategoryID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubCategory_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SubsidiaryCompany",
            //    columns: table => new
            //    {
            //        SubsidiaryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        SubsidiaryCompanyName = table.Column<string>(maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SubsidiaryCompany", x => x.SubsidiaryID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubsidiaryCompany_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SupplierOwnership",
            //    columns: table => new
            //    {
            //        OwnershipID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        MainShareholder = table.Column<string>(maxLength: 500, nullable: false),
            //        Shareholding = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
            //        CountryID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SupplierOwnership", x => x.OwnershipID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierOwnership_tbl_Country",
            //            column: x => x.CountryID,
            //            principalTable: "tbl_Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierOwnership_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SupplierProfile",
            //    columns: table => new
            //    {
            //        SupplierProfileID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierID = table.Column<int>(nullable: false),
            //        NatureOfBusiness = table.Column<string>(nullable: false),
            //        DateofCreation = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SupplierProfile", x => x.SupplierProfileID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SupplierProfile_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PaymentRequestDetails",
            //    columns: table => new
            //    {
            //        PayReqDetID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PayReqMasterID = table.Column<int>(nullable: false),
            //        Description = table.Column<string>(nullable: false),
            //        GLAccountCode = table.Column<string>(maxLength: 50, nullable: false),
            //        Amount = table.Column<decimal>(type: "money", nullable: false),
            //        TotalAmount = table.Column<decimal>(type: "money", nullable: false),
            //        AmountInWords = table.Column<string>(maxLength: 100, nullable: false),
            //        PreparedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        PBDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        PBSignature = table.Column<string>(maxLength: 100, nullable: false),
            //        CheckedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        CBDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CBSignature = table.Column<string>(maxLength: 100, nullable: false),
            //        ApprovedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        ABDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ABSignature = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PaymentRequestDetails", x => x.PayReqDetID);
            //        table.ForeignKey(
            //            name: "FK_tbl_PaymentRequestDetails_tbl_PaymentRequestMaster",
            //            column: x => x.PayReqMasterID,
            //            principalTable: "tbl_PaymentRequestMaster",
            //            principalColumn: "PayReqMasterID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_ForeignCompany",
            //    columns: table => new
            //    {
            //        ForComID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyName = table.Column<string>(maxLength: 500, nullable: false),
            //        ProductSupplied = table.Column<int>(nullable: false),
            //        Status = table.Column<int>(nullable: false),
            //        Others = table.Column<string>(nullable: true),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_ForeignCompany", x => x.ForComID);
            //        table.ForeignKey(
            //            name: "FK_tbl_ForeignCompany_tbl_Products",
            //            column: x => x.ProductSupplied,
            //            principalTable: "tbl_Products",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_ForeignCompany_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_TypicalSubconScopeProducts",
            //    columns: table => new
            //    {
            //        SCS_ProdID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductID = table.Column<int>(nullable: false),
            //        SubConScopeID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_TypicalSubconScopeProducts", x => x.SCS_ProdID);
            //        table.ForeignKey(
            //            name: "FK_tbl_TypicalSubconScopeProducts_tbl_Products",
            //            column: x => x.ProductID,
            //            principalTable: "tbl_Products",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_TypicalSubconScopeProducts_tbl_TypicalSubcontractedScope",
            //            column: x => x.SubConScopeID,
            //            principalTable: "tbl_TypicalSubcontractedScope",
            //            principalColumn: "SubConScopeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PurchaseCondition",
            //    columns: table => new
            //    {
            //        POCon_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PO_ID = table.Column<int>(nullable: false),
            //        PreparedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        PBDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        PBSignature = table.Column<string>(maxLength: 100, nullable: false),
            //        CheckedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        CBDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CBSignature = table.Column<string>(maxLength: 100, nullable: false),
            //        ApprovedBy = table.Column<string>(maxLength: 200, nullable: false),
            //        ABDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        ABSignature = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PurchaseCondition", x => x.POCon_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_PurchaseCondition_tbl_PurchaseOrder",
            //            column: x => x.PO_ID,
            //            principalTable: "tbl_PurchaseOrder",
            //            principalColumn: "PO_ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_PurchaseOrderDetails",
            //    columns: table => new
            //    {
            //        PODet_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PO_ID = table.Column<int>(nullable: false),
            //        Decsription = table.Column<string>(nullable: false),
            //        Quantity = table.Column<int>(nullable: false),
            //        Rate = table.Column<decimal>(type: "money", nullable: false),
            //        Amount = table.Column<decimal>(type: "money", nullable: false),
            //        Total = table.Column<decimal>(type: "money", nullable: false),
            //        PaymentTerms = table.Column<string>(maxLength: 500, nullable: true),
            //        DeliveryTerms = table.Column<string>(maxLength: 500, nullable: true),
            //        DeliveryAddress = table.Column<string>(maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_PurchaseOrderDetails", x => x.PODet_ID);
            //        table.ForeignKey(
            //            name: "FK_tbl_PurchaseOrderDetails_tbl_PurchaseOrder",
            //            column: x => x.PO_ID,
            //            principalTable: "tbl_PurchaseOrder",
            //            principalColumn: "PO_ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_DeliveryInfo",
            //    columns: table => new
            //    {
            //        DelInfoID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuoMasterID = table.Column<int>(nullable: false),
            //        DeliveryAddress = table.Column<string>(maxLength: 100, nullable: false),
            //        SpecialInstructions = table.Column<string>(nullable: false),
            //        RequiredDate = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_DeliveryInfo", x => x.DelInfoID);
            //        table.ForeignKey(
            //            name: "FK_tbl_DeliveryInfo_tbl_QuotationMaster",
            //            column: x => x.QuoMasterID,
            //            principalTable: "tbl_QuotationMasters",
            //            principalColumn: "QuoMasterID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QuotationApproval",
            //    columns: table => new
            //    {
            //        QuoAppID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuoMasterID = table.Column<int>(nullable: false),
            //        BuyerName = table.Column<string>(maxLength: 200, nullable: false),
            //        ApprovalSignature = table.Column<string>(maxLength: 100, nullable: true),
            //        ApprovalDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_QuotationApproval", x => x.QuoAppID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QuotationApproval_tbl_QuotationMasters",
            //            column: x => x.QuoMasterID,
            //            principalTable: "tbl_QuotationMasters",
            //            principalColumn: "QuoMasterID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QuotationDetail",
            //    columns: table => new
            //    {
            //        QuoDetID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuoMasterID = table.Column<int>(nullable: false),
            //        Decsription = table.Column<string>(nullable: false),
            //        Quantity = table.Column<int>(nullable: false),
            //        Unit = table.Column<int>(nullable: false),
            //        EstimatedCost = table.Column<decimal>(type: "money", nullable: false),
            //        DetailedSpec = table.Column<string>(nullable: true),
            //        RefCodeStd = table.Column<string>(nullable: true),
            //        TermsCondition = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_QuotationDetail", x => x.QuoDetID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QuotationDetail_tbl_QuotationMasters",
            //            column: x => x.QuoMasterID,
            //            principalTable: "tbl_QuotationMasters",
            //            principalColumn: "QuoMasterID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_QuotationOtherInfo",
            //    columns: table => new
            //    {
            //        OtherInfoID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuoMasterID = table.Column<int>(nullable: false),
            //        SparesRequired = table.Column<bool>(nullable: false),
            //        ASServicesRq = table.Column<string>(nullable: false),
            //        DataSheet = table.Column<string>(maxLength: 100, nullable: true),
            //        MTO = table.Column<string>(maxLength: 100, nullable: true),
            //        Details = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_QuotationOtherInfo", x => x.OtherInfoID);
            //        table.ForeignKey(
            //            name: "FK_tbl_QuotationOtherInfo_tbl_QuotationMasters",
            //            column: x => x.QuoMasterID,
            //            principalTable: "tbl_QuotationMasters",
            //            principalColumn: "QuoMasterID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SubContractedServices",
            //    columns: table => new
            //    {
            //        SubServID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ServiceID = table.Column<int>(nullable: false),
            //        PercentageOutsourced = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
            //        SupplierID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SubContractedServices", x => x.SubServID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubContractedServices_tbl_Services",
            //            column: x => x.ServiceID,
            //            principalTable: "tbl_Services",
            //            principalColumn: "ServiceID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubContractedServices_tbl_SupplierIdentification",
            //            column: x => x.SupplierID,
            //            principalTable: "tbl_SupplierIdentification",
            //            principalColumn: "SupplierID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SP_DSS_Services",
            //    columns: table => new
            //    {
            //        DSS_ServiceID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ServiceID = table.Column<int>(nullable: false),
            //        SP_DSSID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SP_DSS_Services", x => x.DSS_ServiceID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SP_DSS_Services_tbl_Services",
            //            column: x => x.ServiceID,
            //            principalTable: "tbl_Services",
            //            principalColumn: "ServiceID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SP_DSS_Services_tbl_SP_DirectServiceScope",
            //            column: x => x.SP_DSSID,
            //            principalTable: "tbl_SP_DirectServiceScope",
            //            principalColumn: "SP_DSS_ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_DirectServiceScope",
            //    columns: table => new
            //    {
            //        ServiceScopeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MaterialsName = table.Column<string>(maxLength: 500, nullable: false),
            //        SubCategoryID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_DirectServiceScope", x => x.ServiceScopeID);
            //        table.ForeignKey(
            //            name: "FK_tbl_DirectServiceScope_tbl_SubCategory",
            //            column: x => x.SubCategoryID,
            //            principalTable: "tbl_SubCategory",
            //            principalColumn: "SubCategoryID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_SubContractedDetails",
            //    columns: table => new
            //    {
            //        SubConID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SubServID = table.Column<int>(nullable: false),
            //        SubConName = table.Column<string>(maxLength: 500, nullable: false),
            //        SubConAddress = table.Column<string>(maxLength: 500, nullable: false),
            //        CountryID = table.Column<int>(nullable: false),
            //        IsLocal = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_SubContractedDetails", x => x.SubConID);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubContractedDetails_tbl_Country",
            //            column: x => x.CountryID,
            //            principalTable: "tbl_Country",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tbl_SubContractedDetails_tbl_SubContractedServices",
            //            column: x => x.SubServID,
            //            principalTable: "tbl_SubContractedServices",
            //            principalColumn: "SubServID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", null, "Default", "DEFAULT" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_Approval_SupplierID",
            //    table: "tbl_Approval",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_BusinessContinuityPolicy_SupplierID",
            //    table: "tbl_BusinessContinuityPolicy",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CorporateDistinctives_SupplierID",
            //    table: "tbl_CorporateDistinctives",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CorpSocialResponsibility_SupplierID",
            //    table: "tbl_CorpSocialResponsibility",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CY_MFG_FF_CityID",
            //    table: "tbl_CY_MFG_FF",
            //    column: "CityID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_CY_MFG_FF_SupplierID",
            //    table: "tbl_CY_MFG_FF",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_DeliveryInfo_QuoMasterID",
            //    table: "tbl_DeliveryInfo",
            //    column: "QuoMasterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_DirectServiceScope_SubCategoryID",
            //    table: "tbl_DirectServiceScope",
            //    column: "SubCategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_FinancialAudits_SupplierID",
            //    table: "tbl_FinancialAudits",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_FinancialStatements_SupplierID",
            //    table: "tbl_FinancialStatements",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_FinStockMarketInfo_SupplierID",
            //    table: "tbl_FinStockMarketInfo",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_ForeignCompany_ProductSupplied",
            //    table: "tbl_ForeignCompany",
            //    column: "ProductSupplied");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_ForeignCompany_SupplierID",
            //    table: "tbl_ForeignCompany",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_HealthSafetyEnvironment_SupplierID",
            //    table: "tbl_HealthSafetyEnvironment",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_HSE_Certification_CertOrgID",
            //    table: "tbl_HSE_Certification",
            //    column: "CertOrgID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_HSE_Certification_SupplierID",
            //    table: "tbl_HSE_Certification",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_KnowledgeDGSSysytems_ProdEquSerID",
            //    table: "tbl_KnowledgeDGSSysytems",
            //    column: "ProdEquSerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_MainCustomers_CountryID",
            //    table: "tbl_MainCustomers",
            //    column: "CountryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_MainCustomers_ProdEquSerID",
            //    table: "tbl_MainCustomers",
            //    column: "ProdEquSerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_MainCustomers_SupplierID",
            //    table: "tbl_MainCustomers",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_MainCustomers_ValueID",
            //    table: "tbl_MainCustomers",
            //    column: "ValueID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_NumberOfEmployees_DepartmentID",
            //    table: "tbl_NumberOfEmployees",
            //    column: "DepartmentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_NumberOfEmployees_SupplierID",
            //    table: "tbl_NumberOfEmployees",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_OfficeServiceCL_CityID",
            //    table: "tbl_OfficeServiceCL",
            //    column: "CityID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_OfficeServiceCL_CountryID",
            //    table: "tbl_OfficeServiceCL",
            //    column: "CountryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_OfficeServiceCL_SupplierID",
            //    table: "tbl_OfficeServiceCL",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PaymentRequestDetails_PayReqMasterID",
            //    table: "tbl_PaymentRequestDetails",
            //    column: "PayReqMasterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PaymentRequestMaster_DepartmentProject",
            //    table: "tbl_PaymentRequestMaster",
            //    column: "DepartmentProject");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PaymentRequestMaster_PymntBankID",
            //    table: "tbl_PaymentRequestMaster",
            //    column: "PymntBankID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PaymentRequestMaster_SupplierID",
            //    table: "tbl_PaymentRequestMaster",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_Products_SupplierID",
            //    table: "tbl_Products",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PurchaseCondition_PO_ID",
            //    table: "tbl_PurchaseCondition",
            //    column: "PO_ID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PurchaseOrder_SupplierID",
            //    table: "tbl_PurchaseOrder",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_PurchaseOrderDetails_PO_ID",
            //    table: "tbl_PurchaseOrderDetails",
            //    column: "PO_ID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QualityCertification_CertOrgID",
            //    table: "tbl_QualityCertification",
            //    column: "CertOrgID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QualityCertification_SupplierID",
            //    table: "tbl_QualityCertification",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QualityManagement_SupplierID",
            //    table: "tbl_QualityManagement",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QuotationApproval_QuoMasterID",
            //    table: "tbl_QuotationApproval",
            //    column: "QuoMasterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QuotationDetail_QuoMasterID",
            //    table: "tbl_QuotationDetail",
            //    column: "QuoMasterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QuotationMasters_SupplierID",
            //    table: "tbl_QuotationMasters",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_QuotationOtherInfo_QuoMasterID",
            //    table: "tbl_QuotationOtherInfo",
            //    column: "QuoMasterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_Services_SupplierID",
            //    table: "tbl_Services",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SP_DirectServiceScope_SupplierID",
            //    table: "tbl_SP_DirectServiceScope",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SP_DSS_Services_ServiceID",
            //    table: "tbl_SP_DSS_Services",
            //    column: "ServiceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SP_DSS_Services_SP_DSSID",
            //    table: "tbl_SP_DSS_Services",
            //    column: "SP_DSSID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubCategory_SupplierID",
            //    table: "tbl_SubCategory",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubContractedDetails_CountryID",
            //    table: "tbl_SubContractedDetails",
            //    column: "CountryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubContractedDetails_SubServID",
            //    table: "tbl_SubContractedDetails",
            //    column: "SubServID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubContractedServices_ServiceID",
            //    table: "tbl_SubContractedServices",
            //    column: "ServiceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubContractedServices_SupplierID",
            //    table: "tbl_SubContractedServices",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SubsidiaryCompany_SupplierID",
            //    table: "tbl_SubsidiaryCompany",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierIdentification_ContactPersonID",
            //    table: "tbl_SupplierIdentification",
            //    column: "ContactPersonID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierIdentification_FormID",
            //    table: "tbl_SupplierIdentification",
            //    column: "FormID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierIdentification_TPR_ID",
            //    table: "tbl_SupplierIdentification",
            //    column: "TPR_ID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierOwnership_CountryID",
            //    table: "tbl_SupplierOwnership",
            //    column: "CountryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierOwnership_SupplierID",
            //    table: "tbl_SupplierOwnership",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_SupplierProfile_SupplierID",
            //    table: "tbl_SupplierProfile",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_TypicalSubconScopeProducts_ProductID",
            //    table: "tbl_TypicalSubconScopeProducts",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_TypicalSubconScopeProducts_SubConScopeID",
            //    table: "tbl_TypicalSubconScopeProducts",
            //    column: "SubConScopeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_TypicalSubcontractedScope_CountryID",
            //    table: "tbl_TypicalSubcontractedScope",
            //    column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_Approval");

            migrationBuilder.DropTable(
                name: "tbl_BusinessContinuityPolicy");

            migrationBuilder.DropTable(
                name: "tbl_CorporateDistinctives");

            migrationBuilder.DropTable(
                name: "tbl_CorpSocialResponsibility");

            migrationBuilder.DropTable(
                name: "tbl_CY_MFG_FF");

            migrationBuilder.DropTable(
                name: "tbl_DeliveryInfo");

            migrationBuilder.DropTable(
                name: "tbl_DirectServiceScope");

            migrationBuilder.DropTable(
                name: "tbl_FinancialAudits");

            migrationBuilder.DropTable(
                name: "tbl_FinancialStatements");

            migrationBuilder.DropTable(
                name: "tbl_FinStockMarketInfo");

            migrationBuilder.DropTable(
                name: "tbl_ForeignCompany");

            migrationBuilder.DropTable(
                name: "tbl_HealthSafetyEnvironment");

            migrationBuilder.DropTable(
                name: "tbl_HSE_Certification");

            migrationBuilder.DropTable(
                name: "tbl_KnowledgeDGSSysytems");

            migrationBuilder.DropTable(
                name: "tbl_MainCustomers");

            migrationBuilder.DropTable(
                name: "tbl_NumberOfEmployees");

            migrationBuilder.DropTable(
                name: "tbl_OfficeServiceCL");

            migrationBuilder.DropTable(
                name: "tbl_PaymentRequestDetails");

            migrationBuilder.DropTable(
                name: "tbl_PurchaseCondition");

            migrationBuilder.DropTable(
                name: "tbl_PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "tbl_QualityCertification");

            migrationBuilder.DropTable(
                name: "tbl_QualityManagement");

            migrationBuilder.DropTable(
                name: "tbl_QuotationApproval");

            migrationBuilder.DropTable(
                name: "tbl_QuotationDetail");

            migrationBuilder.DropTable(
                name: "tbl_QuotationOtherInfo");

            migrationBuilder.DropTable(
                name: "tbl_SP_DSS_Services");

            migrationBuilder.DropTable(
                name: "tbl_State");

            migrationBuilder.DropTable(
                name: "tbl_SubContractedDetails");

            migrationBuilder.DropTable(
                name: "tbl_SubsidiaryCompany");

            migrationBuilder.DropTable(
                name: "tbl_SupplierOwnership");

            migrationBuilder.DropTable(
                name: "tbl_SupplierProfile");

            migrationBuilder.DropTable(
                name: "tbl_TypicalSubconScopeProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_SubCategory");

            migrationBuilder.DropTable(
                name: "tbl_ProductEquipmentService");

            migrationBuilder.DropTable(
                name: "tbl_ValueDetails");

            migrationBuilder.DropTable(
                name: "tbl_City");

            migrationBuilder.DropTable(
                name: "tbl_PaymentRequestMaster");

            migrationBuilder.DropTable(
                name: "tbl_PurchaseOrder");

            migrationBuilder.DropTable(
                name: "tbl_CertifyingOrg");

            migrationBuilder.DropTable(
                name: "tbl_QuotationMasters");

            migrationBuilder.DropTable(
                name: "tbl_SP_DirectServiceScope");

            migrationBuilder.DropTable(
                name: "tbl_SubContractedServices");

            migrationBuilder.DropTable(
                name: "tbl_Products");

            migrationBuilder.DropTable(
                name: "tbl_TypicalSubcontractedScope");

            migrationBuilder.DropTable(
                name: "tbl_Departments");

            migrationBuilder.DropTable(
                name: "tbl_PaymentBank");

            migrationBuilder.DropTable(
                name: "tbl_Services");

            migrationBuilder.DropTable(
                name: "tbl_Country");

            migrationBuilder.DropTable(
                name: "tbl_SupplierIdentification");

            migrationBuilder.DropTable(
                name: "tbl_ContactPersons");

            migrationBuilder.DropTable(
                name: "tbl_FormIdentification");

            migrationBuilder.DropTable(
                name: "tbl_ThirdPartyReference");
        }
    }
}
