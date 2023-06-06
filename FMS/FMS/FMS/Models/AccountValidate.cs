using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class AccountValidate
    {
        [Required(ErrorMessage = "Enter UserName")]
        [MaxLength(20, ErrorMessage = "Out of 20 characters")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [MaxLength(50, ErrorMessage = "Out of 20 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "RePassword")]
        [MaxLength(50, ErrorMessage = "Out of 20 characters")]
        [Compare("Password", ErrorMessage = "The Password do not match")]
        public string RePassword { get; set; }

        public int Role { get; set; }
        public string StaffId { get; set; }
    }
}