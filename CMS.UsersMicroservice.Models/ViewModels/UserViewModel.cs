using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.UsersMicroservice.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
