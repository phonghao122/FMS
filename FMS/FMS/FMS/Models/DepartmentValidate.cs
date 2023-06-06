using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class DepartmentValidate
    {
        [Required(ErrorMessage = "Depart ID")]
        [MaxLength(50, ErrorMessage = "Out of 50 characters")]
        public string DepartmentID { get; set; }

        [Required(ErrorMessage = "Depart Name")]
        [MaxLength(50, ErrorMessage = "Out of 50 characters")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Department Phone")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string DepartmentPhone { get; set; }

        [Required(ErrorMessage = "Department Address")]
        [MaxLength(100, ErrorMessage = "Out of 100 characters")]
        public string DepartmentAddress { get; set; }
    }
}