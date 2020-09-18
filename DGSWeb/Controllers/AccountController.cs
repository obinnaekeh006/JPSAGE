using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using DGSWeb.Email;
using DGSWeb.Helpers;
using DGSWeb.Services;
using DGSWeb.ViewModels;
using Generic.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGSWeb.Controllers
{
    /// <summary>
    /// This controller handles User Registration, Login and Logout, it also handles custom user registration and login
    /// </summary>
    
    
    public class AccountController : Controller
    {
        // injecting ASP.NET identity userManager and signInManager to the Account Controller constructor for dependency injecion
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IEmailSender _emailSender;


        // Account controller constructor
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<AppSettings> appSettings,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _appSettings = appSettings;
            _emailSender = emailSender;
        }




        /// <summary>
        /// This gets the default login page of the application and returns the login view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        /// <summary>
        /// Action that handles email verification when user clickes on the email verification link
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> EmailLogin(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            if (user.EmailConfirmed)
            {
                return RedirectToAction("Login", "Account");
            }

            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return BadRequest();
        }



        /// <summary>
        /// This gets a LoginViewModel class object as it's parameter from the login page.
        /// This action is responsible for signing the identity user in based on his email and password
        /// if the Identity user is signed in successfully he is redirected to the home page
        /// if the user is not signed in successfully the sign in error is returned to the login page
        /// so that the user can sign in properly based on the application sign in specifications.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // checks if the model is valid and required objects in the model are not null
            if (ModelState.IsValid)
            {

                // Get the User from The database
                //var user = await userManager.FindByEmailAsync(model.Email);

                // Then Check If Email Is confirmed
                //if (user != null && !await userManager.IsEmailConfirmedAsync(user))
                //{
                //    // Sending Confirmation Email

                //    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                //    var callbackUrl = Url.Action(nameof(VerifyEmail), "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                //    var response = await _emailSender.SendEmailAsync(user.Email, "DGS.com - Confirm Your Email", "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>");

                //    ModelState.AddModelError(string.Empty, "Email not confirmed");

                //    return RedirectToAction("EmailVerification");

                //}

                

                // signing the user in using his email and password and also specifying if the user would
                // like to remain signed in on closure of browser
                var result = await signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                // if the sign in is successful, the user is redirected to the home page of the application
                if (result.Succeeded)
                {
                    var user = userManager.FindByEmailAsync(model.Email).Result;
                    var userRoles = userManager.GetRolesAsync(user).Result;

                    foreach(var userRole in userRoles)
                    {
                        if (userRole == "Admin")
                        {
                            return RedirectToAction("index", "admin");
                        }

                    }


                    // redirecting to the home page
                    return RedirectToAction("index", "vendor");

                }

                // if the sign in is unsuccessful, the sign in errors are returned to the login page where 
                // user can sign in appropriately based on the application specifications
                ModelState.AddModelError(string.Empty, "Incorrect email or password");
            }


            // returning the current invalid model state of the LoginViewModal for proper signing in
            return View(model);
        }





        /// <summary>
        /// This gets the Register page and returns its view to the user
        /// </summary>
        /// <returns></returns>
        [Authorize("RequireAdministratorRole")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }






        /// <summary>
        /// This action is initiated when the user clicks on the submit button in the sign up page. It checks for proper sign up
        /// details as specified for the application. If the form is filled correctly, it creates the Asp.Net Identity user in the
        /// database, using the filled details, and asign the default role of "Customer" to each User. It futher signs the user in 
        /// and redirects the user to the home page after registration. If there are registration errors, the invalid form details
        /// and corrections are rendered to the user to fill correctly.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        //[Authorize("RequireAdministratorRole")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // to check if the form model objects required is valid and not null
            if (ModelState.IsValid)
            {

                // create the identity user equivalent
                var identityUser = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailAddress = model.Email,
                    NormalizedUserName = model.Email,
                    CompanyName = model.CompanyName,
                    PhoneNumber = model.PhoneNumber.ToString()
                };

                // create the Identity user in the database
                var result = await userManager.CreateAsync(identityUser, model.Password);


                // checking if the user was created successfully
                if (result.Succeeded)
                {

                    // assigning the default "Default" role to the user
                    await userManager.AddToRoleAsync(identityUser, "Default");

                    // signing the current user into the application
                    //await signInManager.SignInAsync(identityUser, isPersistent: false);

                    // Sending Confirmation Email

                    // generation of the email token
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);

                    var callbackUrl = Url.Action(nameof(EmailLogin), "Account", new { UserId = identityUser.Id, Code = code }, protocol: HttpContext.Request.Scheme);
                    //var callbackUrl = Url.Action(nameof(Login), "Account");

                    
                    

                    await _emailSender.SendEmailAsync(
                        identityUser.Email, string.Format("DGS.com - Company Login To DGS Application"),
                        string.Format("Login Details-") + "\n"+
                        string.Format($"Email:{model.Email}")+"\n"+
                        string.Format($"Password:{model.Password}") + "\n"+
                        string.Format("Please navigate to the Login page by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>")
                        );

                    return RedirectToAction("EmailVerification");
                }


                // if the registration was unsuccessful, every error is rendered to the user in the sign up page
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // returning the current invalid model state of the RegisterViewModal for proper signing up
            return View(model);
        }





        /// <summary>
        /// Action that handles email verification when user clickes on the email verification link
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            if (user.EmailConfirmed)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        // to render the emailVerification view 
        //[Authorize("RequireAdministratorRole")]
        public IActionResult EmailVerification() => View();




        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);

            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);


            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));

            //var code = await userManager.GeneratePasswordResetTokenAsync(user);
            //var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

            //var message = new Message(new string[] { "codemazetest@gmail.com" }, "Reset password token", callback);
            //await _emailSender.SendEmailAsync(message);

            await _emailSender.SendEmailAsync(user.Email, "DGS.com - Reset password token", "Please reset your Password by clicking this link: <a href=\"" + callback + "\">click here</a>");

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);

            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }

            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }




        /// <summary>
        /// This action logs out the current signed in Identity user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            // signing out the user asynchronously
            await signInManager.SignOutAsync();

            //redirecting to the home page
            // redirecting to the loan index page for now
            return RedirectToAction("Login", "Account");
        }








        /// <summary>
        /// To render user profile
        /// </summary>
        /// <returns></returns>
        public IActionResult Profile()
        {
            return View();
        }
    }
}
