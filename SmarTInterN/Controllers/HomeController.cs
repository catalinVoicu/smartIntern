using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmarTInterN.Models.TeamUser;
using SmarTInterN.Models;
using SmarTInterN.Models.TeamUser.ViewModels;
using System.Web.Security;

namespace SmarTInterN.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return PartialView("Footer");
        }

        public ActionResult TeasingYou()
        {
            return View();
        }

        public ActionResult TellingYouMore()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Judges()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ViewProfile()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult CounterPartialView()
        {
            return PartialView();
        }

        public ActionResult RegisterStudent()
        {
            return View();
        }

        public ActionResult Target()
        {
            return PartialView("Target");
        }

        public ActionResult Teams()
        {
            return PartialView();
        }
        public ActionResult Apps()
        {
            return PartialView();
        }
        public ActionResult Submissions()
        {
            return PartialView();
        }
        public ActionResult JudgingCriteria()
        {
            return PartialView();
        }
        public ActionResult Prizes()
        {
            return PartialView();
        }
        public ActionResult Disclaimer()
        {
            return PartialView();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegisterStudent(StudentModel model)
        {
            HomeService service = new HomeService();
            int count = 0;
            smarTInternDataContext db = new smarTInternDataContext();
            MembershipUser user = Membership.GetUser();
            try
            {
                service.RegisterStudent(model);
                foreach (var item in db.StudentTables)
                {
                    if(item.Team_Id.Equals(user.ProviderUserKey))
                    {
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["errorMessage"] = ex.Message;
                return View(model);
            }

            if (count >= 3)
            {
                return View("Limit");
            }
            else
            {
                return View("RegisterStudent");
            }
        }

        public ActionResult Limit()
        {
            return View();
        }


        //public ActionResult Counter()
        //{
        //    HomeService hs = new HomeService();
        //    CounterModel model = new CounterModel();
        //    hs.countMembers(model);
        //    return PartialView(model);
        //}

       
        public ActionResult StudentInfo()
        {
            HomeService service = new HomeService();
            return PartialView("StudentInfo", service.StudentInfo());
        }
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult EditProfilePhoto(HttpPostedFileBase file)
        //{
        //    HomeService service = new HomeService();
        //    service.UploadImage(file);
   
        //    return View("EditProfile");
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult EditProfileFile(HttpPostedFileBase file)
        //{
        //    HomeService service = new HomeService();
        //    service.UploadFile(file);
        //    return View("EditProfile");
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public FilePathResult GetImage()
        //{
        //    HomeService service = new HomeService();

        //    Picture pic = service.GetPicture();

        //    return File(pic.PicturePath, pic.PicturePath);
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public FilePathResult GetFile()
        //{
        //    HomeService service = new HomeService();

        //    Application app = service.GetAppDescription();

        //    return File(app.Description, app.Description);
        //}
    }
}
