using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class MaterialValidate
    {
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public Nullable<int> MaterialQT { get; set; }
        public string MaterialUnit { get; set; }
    }
}