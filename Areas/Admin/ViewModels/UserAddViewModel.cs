using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Areas.Admin.ViewModels
{
    public class UserAddViewModel
    {
        [Required]
        [MinLength(8)]
        [Display(Name = "full name")]
        public string FullName { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "address name")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your role")]
        [DataType(DataType.Text)]
        public string Role { get; set; }
        public ICollection<SelectListItem> UserRoles { get; set; } = new List<SelectListItem>();

    }
}
