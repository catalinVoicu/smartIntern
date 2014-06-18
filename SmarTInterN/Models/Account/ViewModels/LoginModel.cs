using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmarTInterN.Models.Account.ViewModels
{
    public class LoginModel
    {
        [Required]
        public String UserName { get; set; }

        [Required(ErrorMessage="Incorect password") ]
        public String Password { get; set; }

        public bool KeepMeSignedIn { get; set; }
    }
}