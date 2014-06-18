using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmarTInterN.Models.TeamUser.ViewModels
{
    public class StudentModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "University is required")]
        public string University { get; set; }
        
        public string UniversitySection { get; set; }
        
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
    }
}