using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;

namespace SmarTInterN.Models.TeamUser.ViewModels
{
    public class UploadImageModel
    {
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Application is required")]
        public string AppName { get; set; }
    }
}