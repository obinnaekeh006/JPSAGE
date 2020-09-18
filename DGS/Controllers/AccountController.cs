using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DGS.DataObjects.Account;
using DGS.Email;
using DGS.Helpers;
using Generic.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGS.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly AppSettings _appSettings;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _appSettings = appSettings.Value;
        }


        // Register Method

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel RegData)
        {
            // Will hold all errors related to registration 
            List<string> errorList = new List<string>();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    Email = RegData.Email,
                    UserName = RegData.Email,
                    FirstName = RegData.FirstName,
                    LastName = RegData.LastName,
                    PhoneNumber = RegData.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString() 
                };

                var result = await _userManager.CreateAsync(user, RegData.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Default");

                    // Sending Confirmation Email

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "DGS.com - Confirm Your Email", "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>");

                    return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registration Successful" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        errorList.Add(error.Description);
                    }
                }
            }
            return BadRequest(new JsonResult(errorList));
        }


        // Login Method
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel LoginData)
        {
            // Get the User from The database
            var user = await _userManager.FindByNameAsync(LoginData.Email);

            //var roles = await _userManager.GetRolesAsync(user);

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));

            var tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);

            if (user != null && await _userManager.CheckPasswordAsync(user, LoginData.Password))
            {

                // Then Check If Email Is confirmed
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "User Has not Confirmed Email.");

                    return Unauthorized(new { LoginError = "We sent you an Confirmation Email. Please Confirm Your Registration With DGS.com To Log in." });
                }

                // get user Role
                var roles = await _userManager.GetRolesAsync(user);

                // Generate Token
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim(JwtRegisteredClaimNames.Sub, LoginData.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                       new Claim(ClaimTypes.NameIdentifier, user.Id),
                       new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                       new Claim("LoggedOn", DateTime.Now.ToString()),
                    }),
                    SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Site,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };
                //Generate Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, username = user.UserName, userRole = roles.FirstOrDefault() });
            }
            // return Error
            ModelState.AddModelError("", "UserName/Password was not found sorry");
            return Unauthorized(new { LoginError = "Please Check the Login Credentials - Invalid Username/Password was Entered" });
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);

            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new JsonResult("ERROR");
            }

            if (user.EmailConfirmed)
            {
                return Redirect("/login");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {

                return RedirectToAction("EmailConfirmed", "Notifications", new { userId, code });

            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ToString());
                }
                return new JsonResult(errors);
            }


        }


    }
}
