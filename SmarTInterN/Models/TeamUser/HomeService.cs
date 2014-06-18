using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using SmarTInterN.Models.TeamUser.ViewModels;

namespace SmarTInterN.Models.TeamUser
{
    public class HomeService
    {
         smarTInternDataContext _db = new smarTInternDataContext();

         public void RegisterStudent(StudentModel model)
         {
             MembershipUser user = Membership.GetUser();
             StudentTable stud = new StudentTable();
             Guid studId = Guid.NewGuid();
             stud.StudentId = studId;
             stud.Team_Id = (Guid)user.ProviderUserKey;
             stud.Name = model.FirstName;
             stud.LastName = model.LastName;
             stud.Email = model.Email;
             stud.Phone = model.Phone;
             stud.University = model.University;
             stud.UniversitySection = model.UniversitySection;

             _db.StudentTables.InsertOnSubmit(stud);
             _db.SubmitChanges();
        }

         //public void countMembers(CounterModel model)
         //{
         //    int count = _db.aspnet_Memberships.Count();
         //    int max = 40;
         //    model.counter = max - count;
        //}
        //public void RegisterStudent1(Stu model)
        //{
        //    MembershipUser user = Membership.GetUser();
        //    StudentTable stud = new StudentTable();
        //    Guid studId = new Guid();
        //    stud.StudentId = studId;
        //    stud.Team_Id = (Guid)user.ProviderUserKey;
        //    stud.Name = model.FirstName1;
        //    stud.LastName = model.LastName1;
        //    stud.Email = model.Email1;
        //    stud.Phone = model.Phone1;
        //    stud.University = model.University1;
        //    stud.UniversitySection = model.UniversitySection1;

        //    _db.StudentTables.InsertOnSubmit(stud);
        //    _db.SubmitChanges();
        //}
        //public void RegisterStudent2(StudentModel2 model)
        //{
        //    MembershipUser user = Membership.GetUser();
        //    StudentTable stud = new StudentTable();
        //    Guid studId = new Guid();
        //    stud.StudentId = studId;
        //    stud.Team_Id = (Guid)user.ProviderUserKey;
        //    stud.Name = model.FirstName2;
        //    stud.LastName = model.LastName2;
        //    stud.Email = model.Email2;
        //    stud.Phone = model.Phone2;
        //    stud.University = model.University2;
        //    stud.UniversitySection = model.UniversitySection2;

        //    _db.StudentTables.InsertOnSubmit(stud);
        //    _db.SubmitChanges();
        //}

        public StudentInfoModel StudentInfo()
        {
            StudentTable student = new StudentTable();
            return new StudentInfoModel
            {
                FirstName = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone
            };
        }

         //public void UploadImage(HttpPostedFileBase file)
         //{
         //    if (file != null && file.ContentLength > 0)
         //    {
         //        Picture pic = new Picture();
                 
                 
         //        Guid picId = new Guid();
         //        pic.PictureId = picId;
         //        //pic.App_id = app.AppId;

         //        var fileName = Path.GetFileName(file.FileName);
         //        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/uploads/images/"), fileName);
         //        pic.PicturePath = path;
         //        file.SaveAs(pic.PicturePath);

         //        _db.Pictures.InsertOnSubmit(pic);
         //        _db.SubmitChanges();
         //    }
         //}

         //public Picture GetPicture()
         //{
         //    Picture pic = new Picture();
         //    //Guid userId = (Guid)pic.Picture_Id;

         //    //Picture picture = _db.Pictures.First(select => select.Picture_Id == userId);
         //    return pic;
         //}

         //public void UploadFile(HttpPostedFileBase file)
         //{
         //    if (file != null && file.ContentLength > 0)
         //    {
         //        Application app = new Application();


         //        var fileName = Path.GetFileName(file.FileName);
         //        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/uploads/files/"), fileName);
         //        app.Description = path;
         //        //file.SaveAs(application.Description);

         //        _db.Applications.InsertOnSubmit(app);
         //        _db.SubmitChanges();
         //    }
         //}

         //public Application GetAppDescription()
         //{
         //    Application app = new Application();
         //    Guid userId = app.AppId;

         //    Application application = _db.Applications.First(select => select.AppId == userId);
         //    return application;
         //}

    }
}