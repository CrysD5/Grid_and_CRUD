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
    
    public partial class somRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public somRole()
        {
            this.somSites = new HashSet<somSite>();
            this.somUserRoles = new HashSet<somUserRole>();
        }
    
        public int roleid { get; set; }
        public string rolename { get; set; }
        public string roledescription { get; set; }
        public string domain { get; set; }
        public string userlogin { get; set; }
        public Nullable<System.DateTime> userdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<somSite> somSites { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<somUserRole> somUserRoles { get; set; }
    }
}