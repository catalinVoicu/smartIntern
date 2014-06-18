using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmarTInterN.Models.Account.ViewModels;
using System.Web.Security;
using System.Net.Mail;
using SmarTInterN.Models.TeamUser.ViewModels;

namespace SmarTInterN.Models.Account
{
    public class AccountService
    {
        smarTInternDataContext _db = new smarTInternDataContext();

        //---------Inregistrare User---------------------------
        public MembershipUser RegisterUser(RegisterUserModel model)
        {
            MembershipUser membershipUser = null;

            try
            {
                membershipUser = Membership.CreateUser(model.UserName, model.Password, model.Email);
            }
            catch (MembershipCreateUserException ex)
            {
                throw ex;
            }

            TeamTable team = new TeamTable();
            team.TeamId = (Guid) membershipUser.ProviderUserKey;
            team.UserName = model.UserName;
            _db.TeamTables.InsertOnSubmit(team);
            _db.SubmitChanges();

            return membershipUser; 
        }

        public void Login(LoginModel model)
        {
            if(Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.KeepMeSignedIn);
            }
            else
            {
                throw new Exception("User name and password doesn't match");
            }
        }

        public LogedInInfoModel LoginStatus()
        {

            MembershipUser user = Membership.GetUser();
            Guid userId = (Guid)user.ProviderUserKey;

            TeamTable userName = _db.TeamTables.First(select => select.TeamId == userId);
            return new LogedInInfoModel
            {
                UserName = userName.UserName
            };
        }

        public void ForgotPassword(string newPassword, ForgotPasswordModel model)
        {
            MembershipUser user = Membership.GetUser(model.UserName);
            MailMessage mail = new MailMessage("smartIntern@asaff.ro", user.Email);
            //Guid guid = (Guid)user.ProviderUserKey;
            mail.Subject = "Password reset!";
            mail.Body = "New password: " + newPassword + " . Please sign in with your new password, you can change it from your profile.";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("smartInternRobot", "passwordTest");
            try
            {
                client.Send(mail);
            }
            catch
            {
                throw new Exception("This email adress doesn't exist.Please insert your correct adress!");
            }
        }

        public void ChangePassword(ChangePasswordModel model)
        {
            MembershipUser user = Membership.GetUser();
            Guid userId = (Guid)user.ProviderUserKey;
            TeamTable userProfile = _db.TeamTables.First(p => p.TeamId == userId);

            if (Membership.ValidateUser(user.UserName, model.Password))
            {
                user.ChangePassword(model.Password, model.NewPassword);
                Membership.UpdateUser(user);
                _db.SubmitChanges();
            }
            else
            {
                throw new Exception("Password don't match");
            }
        }
    }
}