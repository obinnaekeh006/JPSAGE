using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGSWeb.Email;
using DGSWeb.Helpers;
using Generic.Dapper.Interfaces;
using Generic.Dapper.Repository;
using Generic.Dapper.UnitOfWork;
using Generic.Data.Context;
using Generic.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DGSWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Specifiying  we are going to use Identity Framework
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews();

            // Email sending service sendgrid extension method dependency injection
            services.AddSendGridEmailSender();

            //Configure Strongly typed Object
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appsettings = appSettingsSection.Get<AppSettings>();



            services.ConfigureApplicationCookie(options =>
            {

                options.Cookie.Name = "Identity.Cookie";
                options.LoginPath = "/Account/Login";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;


            });




            //services.AddAntiforgery(opts => {
            //    opts.Cookie.SameSite = SameSiteMode.Unspecified;
            //});

            // for our password reset token to be valid for a limited time
            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));


            // Adding google authentication middleware for  Microsoft.AspNetCore.Authentication.Google package
            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //});



            //Adding facebook authentication middleware for  Microsoft.AspNetCore.Authentication.Facebook package
            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});


            //Adding twitter authentication middleware for  Microsoft.AspNetCore.Authentication.Twitter package
            //services.AddAuthentication().AddTwitter(twitterOptions => {
            //    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
            //    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //});



            //Adding linkedin authentication middleware for  AspNet.Security.OAuth.LinkedIn package
            //services.AddAuthentication().AddLinkedIn(options =>
            //{
            //    options.ClientId = Configuration["Authentication:LinkedIn:ClientId"];
            //    options.ClientSecret = Configuration["Authentication:LinkedIn:ClientSecret"];

            //    options.Events = new OAuthEvents()
            //    {
            //        OnRemoteFailure = loginFailureHandler =>
            //        {
            //            var authProperties = options.StateDataFormat.Unprotect(loginFailureHandler.Request.Query["state"]);
            //            loginFailureHandler.Response.Redirect("/Home/index");
            //            loginFailureHandler.HandleResponse();
            //            return Task.FromResult(0);
            //        }
            //    };

            //});

            // Adding Instagram authentication middleware for  Microsoft.AspNetCore.Authentication.Instagram package
            //services.AddAuthentication().AddInstagram(googleOptions =>
            //{
            //    instagramOptions.ClientId = Configuration["Authentication:Instagram:ClientId"];
            //    instagramOptions.ClientSecret = Configuration["Authentication:Instagram:ClientSecret"];
            //});


            // Authorization Middleware
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireLoggedIn", policy => policy.RequireRole("Default", "Admin", "Moderator").RequireAuthenticatedUser());

                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin").RequireAuthenticatedUser());

                //options.AddPolicy("RequireInstructorRole", policy => policy.RequireRole("Instructor").RequireAuthenticatedUser());
            });



            // Connect to Database
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),

                b => b.MigrationsAssembly("Generic.Data")), ServiceLifetime.Transient);


            // Ensure run time compilation and code changes applied when app is running

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // to set the password hash for version 2 compatability
            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );

            //Connect to Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IGeneralUnitOfWork, GeneralUnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCookiePolicy();



            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
