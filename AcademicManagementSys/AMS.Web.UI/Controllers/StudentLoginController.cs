using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AMS.DTO;
using AMS.ViewModel;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
//using AMS.Web.UI.Models;
using System.Configuration;
using AMS.ServiceAccess;
using AMS.Base.DTO;
using System.Security.Principal;

namespace AMS.Web.UI.Controllers
{
    public class StudentLoginController : BaseController
    {

        IStudentSelfRegistrationServiceAccess _studentSelfRegistrationServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentLoginController()
        {
            _studentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();
        }

        //
        // GET: /StudentLogin/Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            //throw new NullReferenceException("This is error");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //throw new NullReferenceException("This is error");
            ViewBag.ReturnUrl = returnUrl;
            return View("/Views/StudentLogin/Login.cshtml");
        }
        //
        // POST: /StudentLogin/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentLoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
            {
                StudentLoginViewModel _StudentLoginViewModel = new StudentLoginViewModel();
                StudentSelfRegistrationViewModel _studentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
                _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO = new StudentSelfRegistration();
                _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO.EmailID = model.EmailID;
                _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO.Password = model.Password;
                _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<StudentSelfRegistration> response = _studentSelfRegistrationServiceAccess.SelectByStudentEmailIDPassword(_studentSelfRegistrationViewModel.StudentSelfRegistrationDTO);

                if (response != null && response.Entity != null)
                {
                    _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO.ID = response.Entity.ID;
                    _studentSelfRegistrationViewModel.StudentSelfRegistrationDTO.Password = response.Entity.Password;
                   // _StudentLoginViewModel.StudentLoginDTO.UserTypeID = response.Entity.UserTypeID;
                    Session["UserId"] = response.Entity.ID;
                    Session["UserName"] = response.Entity.Title+" " +response.Entity.FirstName + " " + response.Entity.MiddleName + " " + response.Entity.LastName;
                    Session["EmailID"] = model.EmailID;
                    Session["Password"] = model.Password;
                    Session["StudentRegistrationMasterID"] = response.Entity.StudentRegistrationMasterID;
                    //FormsAuthentication.SetAuthCookie(_userMasterViewModel.UserMasterDTO.EmailID, false);
                   
                    //SetFormAuthentication(_StudentLoginViewModel);
                   // SetUserGenericPrincipal();

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else if (response.Entity.StudentRegistrationMasterID == 0 && response.Entity.ApproveRejectStatus == "Pending")
                    {
                      
                        return RedirectToAction("Index", "StudentRegistrationForm");
                       // return RedirectToAction("StudentProfileStatus", "StudentSelfRegistration");
                    }
                    else if (response.Entity.StudentRegistrationMasterID > 0 && (response.Entity.ApproveRejectStatus == "Rejected" || response.Entity.ApproveRejectStatus == "Pending"))
                    {
                        if (response.Entity.ApproveRejectStatus == "Rejected")
                        {
                            return RedirectToAction("Edit", "StudentRegistrationForm", new { status = response.Entity.ApproveRejectStatus });
                        }
                        else
                        {
                            return RedirectToAction("Edit", "StudentRegistrationForm", new { status = response.Entity.ApproveRejectStatus });
                        }
                    }
                    else if (response.Entity.StudentRegistrationMasterID > 0 && (response.Entity.ApproveRejectStatus == "Approved" || response.Entity.ApproveRejectStatus == "InApproval"))
                    {
                        return RedirectToAction("ViewDetails", "StudentRegistrationForm");
                       // return RedirectToAction("StudentProfileStatus", "StudentSelfRegistration");
                    }
                }
                else {
                    ModelState.AddModelError("", " This Student Login doesn't exist. Enter a valid email address or password ");
               
                }
            }
            if (string.IsNullOrEmpty(model.EmailID))
            {
                ModelState.AddModelError("", "Please enter your email address in the format someone@example.com.");
            }

            return RedirectToAction("Index","StudentLogin");
        }


      

    }
}

