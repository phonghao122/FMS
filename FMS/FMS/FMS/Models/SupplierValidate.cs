using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class SupplierValidate
    {
        [Required(ErrorMessage = "Food ID")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string SupplierID { get; set; }

        [Required(ErrorMessage = "Food Name")]
        [MaxLength(100, ErrorMessage = "Out of 100 characters")]
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierAddress { get; set; }
    }
}