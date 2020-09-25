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
using Generic.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGSWeb.Controllers
{
    [Authorize("RequireAdministratorRole")]
    public class AdminController : Controller
    {
        private readonly IRepository<TblVendorRegFormApproval> _vendorRegFormApprovalRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AdminController(
            IRepository<TblVendorRegFormApproval> vendorRegFormApprovalRepository,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender
            )
        {
            _vendorRegFormApprovalRepository = vendorRegFormApprovalRepository;
            _signInManager = signInManager;
            _userManager = userManager;
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
            var vendorListModel = _vendorRegFormApprovalRepository.GetAll();            

            return View(vendorListModel);
        }



        [HttpGet]
        public IActionResult Registered()
        {
            var defaultUsers = _userManager.GetUsersInRoleAsync("Default").Result.ToList();

            var model = new AdminUsersListModel
            {
                ApplicationUserList = defaultUsers
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


        //private string GetContentType(string path)
        //{
        //    var types = GetMimeTypes();
        //    var ext = Path.GetExtension(path).ToLowerInvariant();
        //    return types[ext];
        //}

        //private Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".txt", "text/plain"},
        //        {".pdf", "application/pdf"},
        //        {".doc", "application/vnd.ms-word"},
        //        {".docx", "application/vnd.ms-word"},
        //        {".xls", "application/vnd.ms-excel"},
        //        {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"},
        //        {".csv", "text/csv"}
        //    };
        //}


        public IActionResult VendorFormView(int id)
        {
            var vendor = _vendorRegFormApprovalRepository.GetById(id);
            //var formIdentification = _formIdentificationRepository.GetById(vendor.id)
            var model = new AdminVendorViewModel
            {
                VendorForm = vendor
            };

            return View(model);
        }

        //[HttpPost]
        public IActionResult ApproveVendor(int id)
        {
            var vendorForm = _vendorRegFormApprovalRepository.GetById(id);
            //var formIdentification = _formIdentificationRepository.GetById(vendor.id)
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);

            if (claim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = claim.Value;

            


            vendorForm.ApprovalStatus = 1;
            vendorForm.ApprovedBy = userId;
            vendorForm.ApprovedDate = DateTime.Now;
            _vendorRegFormApprovalRepository.Update(vendorForm);

            return RedirectToAction("VendorFormList");
        }


        //[HttpPost]
        public IActionResult DisapproveVendor(int id)
        {

            var vendorForm = _vendorRegFormApprovalRepository.GetById(id);
            //var formIdentification = _formIdentificationRepository.GetById(vendor.id)
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);

            if (claim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = claim.Value;
            vendorForm.ApprovedBy = userId;
            vendorForm.ApprovedDate = DateTime.Now;
            vendorForm.ApprovalStatus = 2;
            _vendorRegFormApprovalRepository.Sp_VendorRegAdminDisapproved(vendorForm.FormId, vendorForm.SupplierId);
            _vendorRegFormApprovalRepository.Update(vendorForm);

            return RedirectToAction("VendorFormList");
        }



        public async Task<IActionResult> QueryVendor(string email, string query, int id)
        {
            if(email != null && query != null )
            {

                var vendorForm = _vendorRegFormApprovalRepository.GetById(id);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.Name);

                if (claim == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                var userId = claim.Value;
                vendorForm.ApprovedBy = userId;
                vendorForm.ApprovedDate = DateTime.Now;
                vendorForm.ApprovalStatus = 3;
                _vendorRegFormApprovalRepository.Update(vendorForm);

                await _emailSender.SendEmailAsync(email, "Vendor Form Query", query);

                return RedirectToAction("VendorFormList");
            }

            return RedirectToAction("VendorFormList");
        }


        public async Task<IActionResult> MakeAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Registered");
        }


        public async Task<IActionResult> MakeModerator(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            await _userManager.AddToRoleAsync(user, "Moderator");
            return RedirectToAction("Registered");
        }




        #region Helpers

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

        #endregion
    }
}
