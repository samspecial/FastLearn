using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastLearn.Infrastructures.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string RoleName { get; set; }
    }
}
