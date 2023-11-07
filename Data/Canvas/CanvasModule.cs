//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grid_and_CRUD.Data.Canvas
{
    using System;
    using System.Collections.Generic;
    
    public partial class CanvasModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanvasModule()
        {
            this.CanvasModuleItems = new HashSet<CanvasModuleItem>();
            this.zSOMModuleFaculties = new HashSet<zSOMModuleFaculty>();
            this.SOMSectionFaculties = new HashSet<SOMSectionFaculty>();
            this.SOMSectionFacultyFiles = new HashSet<SOMSectionFacultyFile>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> canvascourse_id { get; set; }
        public string unlock_at { get; set; }
        public Nullable<System.DateTime> start_at { get; set; }
        public Nullable<System.DateTime> end_at { get; set; }
    
        public virtual CanvasCourse CanvasCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasModuleItem> CanvasModuleItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zSOMModuleFaculty> zSOMModuleFaculties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMSectionFaculty> SOMSectionFaculties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMSectionFacultyFile> SOMSectionFacultyFiles { get; set; }
    }
}
