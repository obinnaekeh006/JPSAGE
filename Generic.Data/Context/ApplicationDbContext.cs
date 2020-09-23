using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Generic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Generic.Data.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<TblApproval> TblApproval { get; set; }
        public virtual DbSet<TblBusinessExperience> TblBusinessExperience { get; set; }
        public virtual DbSet<TblCertifyingOrg> TblCertifyingOrg { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblContactPersons> TblContactPersons { get; set; }
        public virtual DbSet<TblCorpSocialResponsibility> TblCorpSocialResponsibility { get; set; }
        public virtual DbSet<TblCorporateDistinctives> TblCorporateDistinctives { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblCyMfgFf> TblCyMfgFf { get; set; }
        public virtual DbSet<TblDeliveryInfo> TblDeliveryInfo { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblDirectServiceScope> TblDirectServiceScope { get; set; }
        public virtual DbSet<TblFinancialStatements> TblFinancialStatements { get; set; }
        public virtual DbSet<TblForeignCompany> TblForeignCompany { get; set; }
        public virtual DbSet<TblFormIdentification> TblFormIdentification { get; set; }
        public virtual DbSet<TblHealthSafetyEnvironment> TblHealthSafetyEnvironment { get; set; }
        public virtual DbSet<TblHseCertification> TblHseCertification { get; set; }
        public virtual DbSet<TblMainCustomers> TblMainCustomers { get; set; }
        public virtual DbSet<TblNumberofEmployees> TblNumberofEmployees { get; set; }
        public virtual DbSet<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual DbSet<TblPaymentBank> TblPaymentBank { get; set; }
        public virtual DbSet<TblPaymentRequestDetails> TblPaymentRequestDetails { get; set; }
        public virtual DbSet<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
        public virtual DbSet<TblProductEquipmentService> TblProductEquipmentService { get; set; }
        public virtual DbSet<TblProducts> TblProducts { get; set; }
        public virtual DbSet<TblPurchaseCondition> TblPurchaseCondition { get; set; }
        public virtual DbSet<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual DbSet<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual DbSet<TblQualityCertification> TblQualityCertification { get; set; }
        public virtual DbSet<TblQualityManagement> TblQualityManagement { get; set; }
        public virtual DbSet<TblQuotationApproval> TblQuotationApproval { get; set; }
        public virtual DbSet<TblQuotationDetail> TblQuotationDetail { get; set; }
        public virtual DbSet<TblQuotationMasters> TblQuotationMasters { get; set; }
        public virtual DbSet<TblQuotationOtherInfo> TblQuotationOtherInfo { get; set; }
        public virtual DbSet<TblServices> TblServices { get; set; }
        public virtual DbSet<TblSpDirectServiceScope> TblSpDirectServiceScope { get; set; }
        public virtual DbSet<TblSpDssServices> TblSpDssServices { get; set; }
        public virtual DbSet<TblStaffStrengthComp> TblStaffStrengthComp { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblSubCategory> TblSubCategory { get; set; }
        public virtual DbSet<TblSubContractedDetails> TblSubContractedDetails { get; set; }
        public virtual DbSet<TblSubContractedServices> TblSubContractedServices { get; set; }
        public virtual DbSet<TblSubsidiaryCompany> TblSubsidiaryCompany { get; set; }
        public virtual DbSet<TblSupplierIdentification> TblSupplierIdentification { get; set; }
        public virtual DbSet<TblSupplierOwnership> TblSupplierOwnership { get; set; }
        public virtual DbSet<TblSupplierProfile> TblSupplierProfile { get; set; }
        public virtual DbSet<TblSupplierTaxCertificate> TblSupplierTaxCertificate { get; set; }
        public virtual DbSet<TblThirdPartyReference> TblThirdPartyReference { get; set; }
        public virtual DbSet<TblTypicalSubconScopeProducts> TblTypicalSubconScopeProducts { get; set; }
        public virtual DbSet<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
        public virtual DbSet<TblValueDetails> TblValueDetails { get; set; }
        public virtual DbSet<TblVendorRegFormApproval> TblVendorRegFormApproval { get; set; }

   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Default", NormalizedName = "DEFAULT" },
                new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }

                );



            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<TblApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId);

                entity.ToTable("tbl_Approval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnName("Approval_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblApproval)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Approval_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblBusinessExperience>(entity =>
            {
                entity.HasKey(e => e.BizExId);

                entity.ToTable("tbl_BusinessExperience");

                entity.Property(e => e.BizExId).HasColumnName("BizExID");

                entity.Property(e => e.CompanyWorkedWith).HasMaxLength(100);

                entity.Property(e => e.ContinuityPolicy).HasMaxLength(100);

                entity.Property(e => e.HasContinuityPolicy).HasMaxLength(10);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.ScopeCovered).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TimeFrame).HasMaxLength(10);

                entity.Property(e => e.TransactionReference).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblBusinessExperience)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_BusinessExperience_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCertifyingOrg>(entity =>
            {
                entity.HasKey(e => e.CertOrgId);

                entity.ToTable("tbl_CertifyingOrg");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertOrgName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tbl_City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblContactPersons>(entity =>
            {
                entity.HasKey(e => e.ContactPersonId);

                entity.ToTable("tbl_ContactPersons");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.ContactPersonName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblContactPersons)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ContactPersons_tbl_FormIdentification");
            });

            modelBuilder.Entity<TblCorpSocialResponsibility>(entity =>
            {
                entity.HasKey(e => e.CsrId);

                entity.ToTable("tbl_CorpSocialResponsibility");

                entity.Property(e => e.CsrId).HasColumnName("CSR_ID");

                entity.Property(e => e.FraudMalpracticePolicy).HasMaxLength(100);

                entity.Property(e => e.SrethHumanLaborLaws)
                    .HasColumnName("SREthHumanLaborLaws")
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartySocAudit).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCorpSocialResponsibility)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CorpSocialResponsibility_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCorporateDistinctives>(entity =>
            {
                entity.HasKey(e => e.CorpDisId);

                entity.ToTable("tbl_CorporateDistinctives");

                entity.Property(e => e.CorpDisId).HasColumnName("CorpDisID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCorporateDistinctives)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CorporateDistinctives_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("tbl_Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblCyMfgFf>(entity =>
            {
                entity.HasKey(e => e.CyMfgFfId);

                entity.ToTable("tbl_CY_MFG_FF");

                entity.Property(e => e.CyMfgFfId).HasColumnName("CY_MFG_FF_ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.FactoryArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.PlantsEquipmentType).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Utilization).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblCyMfgFf)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_CY_MFG_FF_tbl_City");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCyMfgFf)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_CY_MFG_FF_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblDeliveryInfo>(entity =>
            {
                entity.HasKey(e => e.DelInfoId);

                entity.ToTable("tbl_DeliveryInfo");

                entity.Property(e => e.DelInfoId).HasColumnName("DelInfoID");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.SpecialInstructions).IsRequired();

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblDeliveryInfo)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_DeliveryInfo_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tbl_Departments");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblDirectServiceScope>(entity =>
            {
                entity.HasKey(e => e.ServiceScopeId);

                entity.ToTable("tbl_DirectServiceScope");

                entity.Property(e => e.ServiceScopeId).HasColumnName("ServiceScopeID");

                entity.Property(e => e.MaterialsName).HasMaxLength(500);

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblDirectServiceScope)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_tbl_DirectServiceScope_tbl_SubCategory");
            });

            modelBuilder.Entity<TblFinancialStatements>(entity =>
            {
                entity.HasKey(e => e.FinStatId);

                entity.ToTable("tbl_FinancialStatements");

                entity.Property(e => e.FinStatId).HasColumnName("FinStatID");

                entity.Property(e => e.AuditorAddress).HasMaxLength(500);

                entity.Property(e => e.AuditorName).HasMaxLength(200);

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.FinancialStatementYear1).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear2).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear3).HasMaxLength(100);

                entity.Property(e => e.IsListed).HasMaxLength(10);

                entity.Property(e => e.StockMarketInfo).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxIdentificationNo).HasMaxLength(20);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblFinancialStatements)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_FinancialStatements_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblForeignCompany>(entity =>
            {
                entity.HasKey(e => e.ForComId);

                entity.ToTable("tbl_ForeignCompany");

                entity.Property(e => e.ForComId).HasColumnName("ForComID");

                entity.Property(e => e.CompanyName).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.ProductSuppliedNavigation)
                    .WithMany(p => p.TblForeignCompany)
                    .HasForeignKey(d => d.ProductSupplied)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ForeignCompany_tbl_Products");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblForeignCompany)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ForeignCompany_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblFormIdentification>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_FormIdentification");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblHealthSafetyEnvironment>(entity =>
            {
                entity.HasKey(e => e.HseId);

                entity.ToTable("tbl_HealthSafetyEnvironment");

                entity.Property(e => e.HseId).HasColumnName("HSE_ID");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.HseCompanyKpi)
                    .HasColumnName("HSE_CompanyKPI")
                    .HasMaxLength(100);

                entity.Property(e => e.HseManagerEmail)
                    .HasColumnName("HSE_ManagerEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.HseManagerName)
                    .HasColumnName("HSE_ManagerName")
                    .HasMaxLength(200);

                entity.Property(e => e.HseYearN1results)
                    .HasColumnName("HSE_YearN1Results")
                    .HasMaxLength(100);

                entity.Property(e => e.Hsepolicy)
                    .HasColumnName("HSEPolicy")
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.StaffTraining).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartyAudit).HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber).HasMaxLength(20);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblHealthSafetyEnvironment)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HealthSafetyEnvironment_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblHseCertification>(entity =>
            {
                entity.HasKey(e => e.HseCertId);

                entity.ToTable("tbl_HSE_Certification");

                entity.Property(e => e.HseCertId).HasColumnName("HSE_CertID");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertificateCopy).HasMaxLength(100);

                entity.Property(e => e.NameofCertificate).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValidityDate).HasColumnType("datetime");

                entity.HasOne(d => d.CertOrg)
                    .WithMany(p => p.TblHseCertification)
                    .HasForeignKey(d => d.CertOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HSE_Certification_tbl_CertifyingOrg");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblHseCertification)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HSE_Certification_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblMainCustomers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tbl_MainCustomers");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_SupplierIdentification");

                entity.HasOne(d => d.Value)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.ValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_ValueDetails");
            });

            modelBuilder.Entity<TblNumberofEmployees>(entity =>
            {
                entity.HasKey(e => e.NoofEmpId);

                entity.ToTable("tbl_NumberofEmployees");

                entity.Property(e => e.NoofEmpId).HasColumnName("NoofEmpID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.StaffStrCompId).HasColumnName("StaffStrCompID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblNumberofEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tbl_NumberofEmployees_tbl_Departments");

                entity.HasOne(d => d.StaffStrComp)
                    .WithMany(p => p.TblNumberofEmployees)
                    .HasForeignKey(d => d.StaffStrCompId)
                    .HasConstraintName("FK_tbl_NumberofEmployees_tbl_StaffStrengthComp");
            });

            modelBuilder.Entity<TblOfficeServiceCl>(entity =>
            {
                entity.HasKey(e => e.OfficeServClId);

                entity.ToTable("tbl_OfficeServiceCL");

                entity.Property(e => e.OfficeServClId).HasColumnName("OfficeServCL_ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblPaymentBank>(entity =>
            {
                entity.HasKey(e => e.PymntBankId);

                entity.ToTable("tbl_PaymentBank");

                entity.Property(e => e.PymntBankId).HasColumnName("PymntBankID");

                entity.Property(e => e.PaymentBankName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblPaymentRequestDetails>(entity =>
            {
                entity.HasKey(e => e.PayReqDetId);

                entity.ToTable("tbl_PaymentRequestDetails");

                entity.Property(e => e.PayReqDetId).HasColumnName("PayReqDetID");

                entity.Property(e => e.Abdate)
                    .HasColumnName("ABDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Absignature)
                    .IsRequired()
                    .HasColumnName("ABSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountInWords)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ApprovedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Cbdate)
                    .HasColumnName("CBDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbsignature)
                    .IsRequired()
                    .HasColumnName("CBSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.CheckedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.GlaccountCode)
                    .IsRequired()
                    .HasColumnName("GLAccountCode")
                    .HasMaxLength(50);

                entity.Property(e => e.PayReqMasterId).HasColumnName("PayReqMasterID");

                entity.Property(e => e.Pbdate)
                    .HasColumnName("PBDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pbsignature)
                    .IsRequired()
                    .HasColumnName("PBSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.PreparedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.PayReqMaster)
                    .WithMany(p => p.TblPaymentRequestDetails)
                    .HasForeignKey(d => d.PayReqMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestDetails_tbl_PaymentRequestMaster");
            });

            modelBuilder.Entity<TblPaymentRequestMaster>(entity =>
            {
                entity.HasKey(e => e.PayReqMasterId);

                entity.ToTable("tbl_PaymentRequestMaster");

                entity.Property(e => e.PayReqMasterId).HasColumnName("PayReqMasterID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PayReqDate).HasColumnType("datetime");

                entity.Property(e => e.PayReqNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Payee)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ponumber)
                    .IsRequired()
                    .HasColumnName("PONumber")
                    .HasMaxLength(50);

                entity.Property(e => e.PymntBankId).HasColumnName("PymntBankID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.DepartmentProjectNavigation)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.DepartmentProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_Departments");

                entity.HasOne(d => d.PymntBank)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.PymntBankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_PaymentBank");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblProductEquipmentService>(entity =>
            {
                entity.HasKey(e => e.ProdEquSerId);

                entity.ToTable("tbl_ProductEquipmentService");

                entity.Property(e => e.ProdEquSerId).HasColumnName("ProdEquSerID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tbl_Products");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblPurchaseCondition>(entity =>
            {
                entity.HasKey(e => e.PoconId);

                entity.ToTable("tbl_PurchaseCondition");

                entity.Property(e => e.PoconId).HasColumnName("POCon_ID");

                entity.Property(e => e.Abdate)
                    .HasColumnName("ABDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Absignature)
                    .IsRequired()
                    .HasColumnName("ABSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.ApprovedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Cbdate)
                    .HasColumnName("CBDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cbsignature)
                    .IsRequired()
                    .HasColumnName("CBSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.CheckedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pbdate)
                    .HasColumnName("PBDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pbsignature)
                    .IsRequired()
                    .HasColumnName("PBSignature")
                    .HasMaxLength(100);

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.PreparedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblPurchaseCondition)
                    .HasForeignKey(d => d.PoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PurchaseCondition_tbl_PurchaseOrder");
            });

            modelBuilder.Entity<TblPurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PoId);

                entity.ToTable("tbl_PurchaseOrder");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedTo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pocode)
                    .IsRequired()
                    .HasColumnName("POCode")
                    .HasMaxLength(100);

                entity.Property(e => e.QuoteRef)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PurchaseOrder_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblPurchaseOrderDetails>(entity =>
            {
                entity.HasKey(e => e.PodetId);

                entity.ToTable("tbl_PurchaseOrderDetails");

                entity.Property(e => e.PodetId).HasColumnName("PODet_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Decsription).IsRequired();

                entity.Property(e => e.DeliveryAddress).HasMaxLength(500);

                entity.Property(e => e.DeliveryTerms).HasMaxLength(500);

                entity.Property(e => e.PaymentTerms).HasMaxLength(500);

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblPurchaseOrderDetails)
                    .HasForeignKey(d => d.PoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PurchaseOrderDetails_tbl_PurchaseOrder");
            });

            modelBuilder.Entity<TblQualityCertification>(entity =>
            {
                entity.HasKey(e => e.QualCertId);

                entity.ToTable("tbl_QualityCertification");

                entity.Property(e => e.QualCertId).HasColumnName("QualCertID");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertificateCopy).HasMaxLength(100);

                entity.Property(e => e.NameofCertificate).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValidityDate).HasColumnType("datetime");

                entity.HasOne(d => d.CertOrg)
                    .WithMany(p => p.TblQualityCertification)
                    .HasForeignKey(d => d.CertOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityCertification_tbl_CertifyingOrg");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQualityCertification)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityCertification_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblQualityManagement>(entity =>
            {
                entity.HasKey(e => e.QualMgtId);

                entity.ToTable("tbl_QualityManagement");

                entity.Property(e => e.QualMgtId).HasColumnName("QualMgtID");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.ProductQualMgt).HasMaxLength(100);

                entity.Property(e => e.QualManagerEmail).HasMaxLength(100);

                entity.Property(e => e.QualManagerName).HasMaxLength(200);

                entity.Property(e => e.QualityMgt).HasMaxLength(100);

                entity.Property(e => e.QualityPolicy).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.WorkPhoneNumber).HasMaxLength(20);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQualityManagement)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityManagement_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblQuotationApproval>(entity =>
            {
                entity.HasKey(e => e.QuoAppId);

                entity.ToTable("tbl_QuotationApproval");

                entity.Property(e => e.QuoAppId).HasColumnName("QuoAppID");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalSignature).HasMaxLength(100);

                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationApproval)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationApproval_tbl_QuotationMasters");
            });

            modelBuilder.Entity<TblQuotationDetail>(entity =>
            {
                entity.HasKey(e => e.QuoDetId);

                entity.ToTable("tbl_QuotationDetail");

                entity.Property(e => e.QuoDetId).HasColumnName("QuoDetID");

                entity.Property(e => e.Decsription).IsRequired();

                entity.Property(e => e.EstimatedCost).HasColumnType("money");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationDetail)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationDetail_tbl_QuotationMasters");
            });

            modelBuilder.Entity<TblQuotationMasters>(entity =>
            {
                entity.HasKey(e => e.QuoMasterId)
                    .HasName("tbl_QuotationMaster");

                entity.ToTable("tbl_QuotationMasters");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FormNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Project)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.QuotationDate).HasColumnType("datetime");

                entity.Property(e => e.RequestTitle)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Rfqnumber)
                    .IsRequired()
                    .HasColumnName("RFQNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQuotationMasters)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblQuotationOtherInfo>(entity =>
            {
                entity.HasKey(e => e.OtherInfoId);

                entity.ToTable("tbl_QuotationOtherInfo");

                entity.Property(e => e.OtherInfoId).HasColumnName("OtherInfoID");

                entity.Property(e => e.AsservicesRq)
                    .IsRequired()
                    .HasColumnName("ASServicesRq");

                entity.Property(e => e.DataSheet).HasMaxLength(100);

                entity.Property(e => e.Mto)
                    .HasColumnName("MTO")
                    .HasMaxLength(100);

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationOtherInfo)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationOtherInfo_tbl_QuotationMasters");
            });

            modelBuilder.Entity<TblServices>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("tbl_Services");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblSpDirectServiceScope>(entity =>
            {
                entity.HasKey(e => e.SpDssId);

                entity.ToTable("tbl_SP_DirectServiceScope");

                entity.Property(e => e.SpDssId).HasColumnName("SP_DSS_ID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSpDirectServiceScope)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SP_DirectServiceScope_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSpDssServices>(entity =>
            {
                entity.HasKey(e => e.DssServiceId);

                entity.ToTable("tbl_SP_DSS_Services");

                entity.Property(e => e.DssServiceId).HasColumnName("DSS_ServiceID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SpDssid).HasColumnName("SP_DSSID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblSpDssServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SP_DSS_Services_tbl_Services");

                entity.HasOne(d => d.SpDss)
                    .WithMany(p => p.TblSpDssServices)
                    .HasForeignKey(d => d.SpDssid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SP_DSS_Services_tbl_SP_DirectServiceScope");
            });

            modelBuilder.Entity<TblStaffStrengthComp>(entity =>
            {
                entity.HasKey(e => e.StaffStrCompId);

                entity.ToTable("tbl_StaffStrengthComp");

                entity.Property(e => e.StaffStrCompId).HasColumnName("StaffStrCompID");

                entity.Property(e => e.Audit3rdParty).HasMaxLength(100);

                entity.Property(e => e.StaffPolicy).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblStaffStrengthComp)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_StaffStrengthComp_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tbl_State");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("tbl_SubCategory");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSubCategory)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_SubCategory_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSubContractedDetails>(entity =>
            {
                entity.HasKey(e => e.SubConId);

                entity.ToTable("tbl_SubContractedDetails");

                entity.Property(e => e.SubConId).HasColumnName("SubConID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.SubConAddress).HasMaxLength(500);

                entity.Property(e => e.SubConName).HasMaxLength(200);

                entity.Property(e => e.SubServId).HasColumnName("SubServID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSubContractedDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SubContractedDetails_tbl_Country");

                entity.HasOne(d => d.SubServ)
                    .WithMany(p => p.TblSubContractedDetails)
                    .HasForeignKey(d => d.SubServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubContractedDetails_tbl_SubContractedServices");
            });

            modelBuilder.Entity<TblSubContractedServices>(entity =>
            {
                entity.HasKey(e => e.SubServId);

                entity.ToTable("tbl_SubContractedServices");

                entity.Property(e => e.SubServId).HasColumnName("SubServID");

                entity.Property(e => e.PercentageOutsourced).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblSubContractedServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubContractedServices_tbl_Services");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSubContractedServices)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubContractedServices_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSubsidiaryCompany>(entity =>
            {
                entity.HasKey(e => e.SubsidiaryId);

                entity.ToTable("tbl_SubsidiaryCompany");

                entity.Property(e => e.SubsidiaryId).HasColumnName("SubsidiaryID");

                entity.Property(e => e.SubsidiaryCompanyName).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSubsidiaryCompany)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubsidiaryCompany_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSupplierIdentification>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("tbl_SupplierIdentification");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.BankReference).HasMaxLength(100);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CompanyProfile).HasMaxLength(100);

                entity.Property(e => e.CompanyRegNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyWebsiteUrl)
                    .HasColumnName("CompanyWebsiteURL")
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.CorporateAffairsCommisionNo).HasMaxLength(20);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.HeadOfficeAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ThirdPartyReference).HasMaxLength(100);

                entity.Property(e => e.TprId).HasColumnName("TPR_ID");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.ContactPersonId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ContactPersons");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_FormIdentification");

                entity.HasOne(d => d.Tpr)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.TprId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ThirdPartyReference");
            });

            modelBuilder.Entity<TblSupplierOwnership>(entity =>
            {
                entity.HasKey(e => e.OwnershipId);

                entity.ToTable("tbl_SupplierOwnership");

                entity.Property(e => e.OwnershipId).HasColumnName("OwnershipID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.MainShareholder).HasMaxLength(200);

                entity.Property(e => e.Shareholding).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSupplierOwnership)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SupplierOwnership_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSupplierOwnership)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierOwnership_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSupplierProfile>(entity =>
            {
                entity.HasKey(e => e.SupplierProfileId);

                entity.ToTable("tbl_SupplierProfile");

                entity.Property(e => e.SupplierProfileId).HasColumnName("SupplierProfileID");

                entity.Property(e => e.CodeofConduct).HasMaxLength(100);

                entity.Property(e => e.DateofCreation).HasColumnType("datetime");

                entity.Property(e => e.MissionVisionStatement).HasMaxLength(100);

                entity.Property(e => e.NatureOfBusiness).IsRequired();

                entity.Property(e => e.OrganizationCharts).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSupplierProfile)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierProfile_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSupplierTaxCertificate>(entity =>
            {
                entity.HasKey(e => e.TaxCertId)
                    .HasName("PK_SupplierTaxCertificate");

                entity.ToTable("tbl_SupplierTaxCertificate");

                entity.Property(e => e.TaxCertId).HasColumnName("TaxCertID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxCertificate)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSupplierTaxCertificate)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierTaxCertificate_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblThirdPartyReference>(entity =>
            {
                entity.HasKey(e => e.TprId);

                entity.ToTable("tbl_ThirdPartyReference");

                entity.Property(e => e.TprId).HasColumnName("TPR_ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.TprAddress)
                    .HasColumnName("TPR_Address")
                    .HasMaxLength(500);

                entity.Property(e => e.TprEmailAddress)
                    .HasColumnName("TPR_EmailAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.TprName)
                    .HasColumnName("TPR_Name")
                    .HasMaxLength(200);

                entity.Property(e => e.TprOrganization)
                    .HasColumnName("TPR_Organization")
                    .HasMaxLength(100);

                entity.Property(e => e.TprPhoneNumber)
                    .HasColumnName("TPR_PhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.TprWorkPhoneNumber)
                    .HasColumnName("TPR_WorkPhoneNumber")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblThirdPartyReference)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ThirdPartyReference_tbl_FormIdentification");
            });

            modelBuilder.Entity<TblTypicalSubconScopeProducts>(entity =>
            {
                entity.HasKey(e => e.ScsProdId);

                entity.ToTable("tbl_TypicalSubconScopeProducts");

                entity.Property(e => e.ScsProdId).HasColumnName("SCS_ProdID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubConScopeId).HasColumnName("SubConScopeID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblTypicalSubconScopeProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_TypicalSubconScopeProducts_tbl_Products");

                entity.HasOne(d => d.SubConScope)
                    .WithMany(p => p.TblTypicalSubconScopeProducts)
                    .HasForeignKey(d => d.SubConScopeId)
                    .HasConstraintName("FK_tbl_TypicalSubconScopeProducts_tbl_TypicalSubcontractedScope");
            });

            modelBuilder.Entity<TblTypicalSubcontractedScope>(entity =>
            {
                entity.HasKey(e => e.SubConScopeId);

                entity.ToTable("tbl_TypicalSubcontractedScope");

                entity.Property(e => e.SubConScopeId).HasColumnName("SubConScopeID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.SubConAddress).HasMaxLength(500);

                entity.Property(e => e.SubConName).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblTypicalSubcontractedScope)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_TypicalSubcontractedScope_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblTypicalSubcontractedScope)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_TypicalSubcontractedScope_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblValueDetails>(entity =>
            {
                entity.HasKey(e => e.ValueId);

                entity.ToTable("tbl_ValueDetails");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblVendorRegFormApproval>(entity =>
            {
                entity.HasKey(e => e.VendorApprovalId);

                entity.ToTable("tbl_VendorRegFormApproval");

                entity.Property(e => e.VendorApprovalId).HasColumnName("VendorApprovalID");

                entity.Property(e => e.AdforeignCompanyName)
                    .HasColumnName("ADForeignCompanyName")
                    .HasMaxLength(100);

                entity.Property(e => e.AdforeignCompanyOther).HasColumnName("ADForeignCompanyOther");

                entity.Property(e => e.AdforeignCompanyProductSupplied)
                    .HasColumnName("ADForeignCompanyProductSupplied")
                    .HasMaxLength(100);

                entity.Property(e => e.AdforeignCompanyStatus)
                    .HasColumnName("ADForeignCompanyStatus")
                    .HasMaxLength(20);

                entity.Property(e => e.ApprovalStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedBy).HasMaxLength(200);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.BankReference).HasMaxLength(100);

                entity.Property(e => e.BusinessExCompanyWorkedWith).HasMaxLength(100);

                entity.Property(e => e.BusinessExContinuityPolicy).HasMaxLength(100);

                entity.Property(e => e.BusinessExHasContinuityPolicy).HasMaxLength(10);

                entity.Property(e => e.BusinessExRegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.BusinessExScopeCovered).HasMaxLength(500);

                entity.Property(e => e.BusinessExTimeFrame).HasMaxLength(10);

                entity.Property(e => e.BusinessExTransactionReference).HasMaxLength(100);

                entity.Property(e => e.CodeofConduct).HasMaxLength(100);

                entity.Property(e => e.CorporateDistinctives).HasMaxLength(200);

                entity.Property(e => e.CsrsocRespEthHumanLaborLaws)
                    .HasColumnName("CSRSocRespEthHumanLaborLaws")
                    .HasMaxLength(100);

                entity.Property(e => e.Cymfgffcity)
                    .HasColumnName("CYMFGFFCity")
                    .HasMaxLength(50);

                entity.Property(e => e.CymfgfffactoryArea)
                    .HasColumnName("CYMFGFFFactoryArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CymfgffplantEquipmentNumber).HasColumnName("CYMFGFFPlantEquipmentNumber");

                entity.Property(e => e.CymfgffplantEquipmentType)
                    .HasColumnName("CYMFGFFPlantEquipmentType")
                    .HasMaxLength(50);

                entity.Property(e => e.Cymfgffutilization)
                    .HasColumnName("CYMFGFFUtilization")
                    .HasMaxLength(100);

                entity.Property(e => e.DirectServiceScopeMaterials).HasMaxLength(100);

                entity.Property(e => e.DirectServiceScopeSubCategories).HasMaxLength(100);

                entity.Property(e => e.FinancialAuditorAddress).HasMaxLength(200);

                entity.Property(e => e.FinancialAuditorContactNumber).HasMaxLength(20);

                entity.Property(e => e.FinancialAuditorName).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementTaxIdnumber)
                    .HasColumnName("FinancialStatementTaxIDNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.FinancialStatementYear1).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear2).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear3).HasMaxLength(100);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.FormIdentificationEmailAddress).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationName).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.FormIdentificationPosition).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationWorkPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.HealthSafetyEnvironmentPolicy).HasMaxLength(100);

                entity.Property(e => e.HsecertficationValidityDate)
                    .HasColumnName("HSECertficationValidityDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HsecertificationCertAuthority)
                    .HasColumnName("HSECertificationCertAuthority")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecertificationName)
                    .HasColumnName("HSECertificationName")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecompanyKpi)
                    .HasColumnName("HSECompanyKPI")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecompanyYearN1results)
                    .HasColumnName("HSECompanyYearN1Results")
                    .HasMaxLength(100);

                entity.Property(e => e.HsefaxNumber)
                    .HasColumnName("HSEFaxNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.HsemanagerEmail)
                    .HasColumnName("HSEManagerEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.HsemanagerName)
                    .HasColumnName("HSEManagerName")
                    .HasMaxLength(100);

                entity.Property(e => e.HsephoneNumber)
                    .HasColumnName("HSEPhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.HsestaffTrainingPolicy)
                    .HasColumnName("HSEStaffTrainingPolicy")
                    .HasMaxLength(100);

                entity.Property(e => e.HsethirdPartyAudit)
                    .HasColumnName("HSEThirdPartyAudit")
                    .HasMaxLength(100);

                entity.Property(e => e.HseworkPhoneNumber)
                    .HasColumnName("HSEWorkPhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.IsListedStockMarket).HasMaxLength(10);

                entity.Property(e => e.KnowledgeofDgssystemsContractNo)
                    .HasColumnName("KnowledgeofDGSSystemsContractNo")
                    .HasMaxLength(50);

                entity.Property(e => e.KnowledgeofDgssystemsDgsref)
                    .HasColumnName("KnowledgeofDGSSystemsDGSRef")
                    .HasMaxLength(50);

                entity.Property(e => e.KnowledgeofDgssystemsProdEquServ)
                    .HasColumnName("KnowledgeofDGSSystemsProdEquServ")
                    .HasMaxLength(100);

                entity.Property(e => e.KnowledgeofDgssystemsStartDate)
                    .HasColumnName("KnowledgeofDGSSystemsStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MainContactPersonEmail).HasMaxLength(50);

                entity.Property(e => e.MainContactPersonName).HasMaxLength(100);

                entity.Property(e => e.MainContactPersonPhone).HasMaxLength(20);

                entity.Property(e => e.MainContactPersonPosition).HasMaxLength(50);

                entity.Property(e => e.MainContactPersonWorkPhone).HasMaxLength(20);

                entity.Property(e => e.OwnershipMainShareholders).HasMaxLength(100);

                entity.Property(e => e.OwnershipNationality).HasMaxLength(50);

                entity.Property(e => e.PercentageShareholding).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductQualityManagement).HasMaxLength(100);

                entity.Property(e => e.QualityCertficationValidityDate).HasColumnType("datetime");

                entity.Property(e => e.QualityCertificationCertOrganization).HasMaxLength(100);

                entity.Property(e => e.QualityCertificationName).HasMaxLength(100);

                entity.Property(e => e.QualityManagement).HasMaxLength(100);

                entity.Property(e => e.QualityManagerEmail).HasMaxLength(200);

                entity.Property(e => e.QualityManagerFaxNumber).HasMaxLength(20);

                entity.Property(e => e.QualityManagerName).HasMaxLength(100);

                entity.Property(e => e.QualityManagerPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.QualityManagerWorkPhoneNo).HasMaxLength(20);

                entity.Property(e => e.QualityPolicy).HasMaxLength(100);

                entity.Property(e => e.SpdirectServiceScopeService)
                    .HasColumnName("SPDirectServiceScopeService")
                    .HasMaxLength(100);

                entity.Property(e => e.SpdirectServiceScopeServiceDetails).HasColumnName("SPDirectServiceScopeServiceDetails");

                entity.Property(e => e.SpofficeServiceCenterCity)
                    .HasColumnName("SPOfficeServiceCenterCity")
                    .HasMaxLength(50);

                entity.Property(e => e.SpofficeServiceCenterCountry)
                    .HasColumnName("SPOfficeServiceCenterCountry")
                    .HasMaxLength(50);

                entity.Property(e => e.SpsubContractedServices)
                    .HasColumnName("SPSubContractedServices")
                    .HasMaxLength(100);

                entity.Property(e => e.SpsubContractedServicesPercOutsourced)
                    .HasColumnName("SPSubContractedServicesPercOutsourced")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpsubContractorAddress)
                    .HasColumnName("SPSubContractorAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.SpsubContractorIsLocal).HasColumnName("SPSubContractorIsLocal");

                entity.Property(e => e.SpsubContractorName)
                    .HasColumnName("SPSubContractorName")
                    .HasMaxLength(100);

                entity.Property(e => e.SpsubContractorNationality)
                    .HasColumnName("SPSubContractorNationality")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffTrainingPolicy).HasMaxLength(100);

                entity.Property(e => e.StaffTrainingPolicyThirdPartyAudit).HasMaxLength(100);

                entity.Property(e => e.StockMarketInfo).HasMaxLength(100);

                entity.Property(e => e.SubsidiaryCompanyName).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartyRefContactNo).HasMaxLength(20);

                entity.Property(e => e.ThirdPartyRefEmail).HasMaxLength(50);

                entity.Property(e => e.ThirdPartyRefName).HasMaxLength(100);

                entity.Property(e => e.ThirdPartyRefOrgAddress).HasMaxLength(200);

                entity.Property(e => e.TypicalSubContractedScopeAddress).HasMaxLength(100);

                entity.Property(e => e.TypicalSubContractedScopeName).HasMaxLength(100);

                entity.Property(e => e.TypicalSubContractedScopeNationality).HasMaxLength(50);

                entity.Property(e => e.TypicalSubContractedScopeProducts).HasMaxLength(50);

                entity.Property(e => e.VendorCompanyDateofCreation).HasColumnType("datetime");

                entity.Property(e => e.VendorCompanyDepartment).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyName).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyProfile).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyRegistrationNumber).HasMaxLength(20);

                entity.Property(e => e.VendorCompanyWebsiteAddress).HasMaxLength(50);

                entity.Property(e => e.VendorCorporateAffairsCommisionNo).HasMaxLength(20);

                entity.Property(e => e.VendorFraudMalpracticePolicy).HasMaxLength(100);

                entity.Property(e => e.VendorHeadOfficeAddress).HasMaxLength(200);

                entity.Property(e => e.VendorMainCustomerCountry).HasMaxLength(50);

                entity.Property(e => e.VendorMainCustomerName).HasMaxLength(100);

                entity.Property(e => e.VendorMainCustomerValue).HasMaxLength(50);

                entity.Property(e => e.VendorMissionVisionStatement).HasMaxLength(100);

                entity.Property(e => e.VendorNatureofBusiness).HasMaxLength(500);

                entity.Property(e => e.VendorOrganizationChart).HasMaxLength(100);

                entity.Property(e => e.VendorThirdPartySocialAudit).HasMaxLength(100);

                entity.Property(e => e.VendorUsername).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
