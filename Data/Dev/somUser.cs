//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grid_and_CRUD.Data.Dev
{
    using System;
    using System.Collections.Generic;
    
    public partial class somUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public somUser()
        {
            this.somUserRoles = new HashSet<somUserRole>();
        }
    
        public int userid { get; set; }
        public string caseid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mname { get; set; }
        public string som_phone { get; set; }
        public string oth_phone { get; set; }
        public string room { get; set; }
        public string dept { get; set; }
        public string title { get; set; }
        public string userlogin { get; set; }
        public Nullable<System.DateTime> userdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<somUserRole> somUserRoles { get; set; }
    }
}
