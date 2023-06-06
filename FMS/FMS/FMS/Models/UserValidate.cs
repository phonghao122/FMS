using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class UserValidate
    {
        [Required(ErrorMessage = "Staff ID")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string StaffID { get; set; }

        [Required(ErrorMessage = "Staff Name")]
        [MaxLength(50, ErrorMessage = "Out of 30 characters")]
        public string StaffName { get; set; }

        [Required(ErrorMessage = "Birthday")]
        public DateTime Birthday { get; set; }

        public string Position { get; set; }

        [Required(ErrorMessage = "Department Address")]
        public Boolean Gender { get; set; }

        [Required(ErrorMessage = "Identity Card")]
        [MaxLength(12, ErrorMessage = "Out of 12 characters")]
        public string IdentityCard { get; set; }

        public string PhoneNumber { get; set; }

        public string Image { get; set; }

        public string Ethnic { get; set; }

        public string Ward { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string DepartmentID { get; set; }

        public string DepartmentName { get; set; }
    }
}