using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class FoodValidate
    {
        public int Orderid { get; set; }

        [Required(ErrorMessage = "Food ID")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string FoodID { get; set; }

        [Required(ErrorMessage = "Food Name")]
        [MaxLength(20, ErrorMessage = "Out of 20 characters")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "Department Phone")]
        [MaxLength(100, ErrorMessage = "Out of 100 characters")]
        public string FoodDescrip { get; set; }

        [Required(ErrorMessage = "Department Phone")]
        [MaxLength(100, ErrorMessage = "Out of 100 characters")]
        public string Shiftid { get; set; }
    }
}