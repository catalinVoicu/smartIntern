using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmarTInterN.Models.Account.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        public string UserName { get; set; }
    }
}