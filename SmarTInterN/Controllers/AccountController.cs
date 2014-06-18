using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmarTInterN.Models.Account.ViewModels;
using SmarTInterN.Models.Account;
using System.Web.Security;

namespace SmarTInterN.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginGet()
        {
            return View("Login");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService();
                try
                {
                    service.Login(model);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewData["errorMessage"] = ex.Message;
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult RegisterUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegisterUser(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService();
                try
                {
                    service.RegisterUser(model);
                }
                catch (Exception ex)
                {
                    ViewData["errorMessage"] = ex.Message;
                    return View(model);
                }

                TempData["registrationSucces"] = "Thank you for registring";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //[ChildActionOnly]
        //[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LoginStatus()
        {
            AccountService service = new AccountService();
            return PartialView("LoginStatus", service.LoginStatus());
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            AccountService hs = new AccountService();
            if (ModelState.IsValid)
            {
                try
                {
                    hs.ChangePassword(model);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewData["errorMessage"] = ex.Message;
                    return View(model);
                }
            }
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            AccountService service = new AccountService();

            MembershipUser user = Membership.GetUser(model.UserName);
            string password = user.ResetPassword();

            service.ForgotPassword(password,model);

            return RedirectToAction("Index", "Home");
        }

    }
}
