//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            this.STAFF = new HashSet<STAFF>();
        }
    
        public string C_Department_id { get; set; }
        public string C_Department_Name { get; set; }
        public string C_Department_Phone { get; set; }
        public string C_Department_Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFF> STAFF { get; set; }
    }
}
