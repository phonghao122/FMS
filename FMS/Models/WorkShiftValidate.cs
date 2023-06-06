using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class WorkShiftValidate
    {
        [Required(ErrorMessage = "Id Shift")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string IDShift { get; set; }

        [Required(ErrorMessage = "Shift Name")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string ShiftName { get; set; }

        [Required(ErrorMessage = "Shift Start Time")]
        [MaxLength(20, ErrorMessage = "Out of 20 characters")]
        public string ShiftStartTime { get; set; }

        [Required(ErrorMessage = "Shift End Time")]
        [MaxLength(20, ErrorMessage = "Out of 20 characters")]
        public DateTime ShiftEndTime { get; set; }
    }
}