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
    
    public partial class CanvasCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanvasCourse()
        {
            this.CanvasAssignments = new HashSet<CanvasAssignment>();
            this.CanvasGroupCategories = new HashSet<CanvasGroupCategory>();
            this.CanvasModules = new HashSet<CanvasModule>();
            this.CanvasSections = new HashSet<CanvasSection>();
            this.CanvasSectionEnrollments = new HashSet<CanvasSectionEnrollment>();
            this.SOMCourseClassYears = new HashSet<SOMCourseClassYear>();
            this.SOMCourseHyperlinks = new HashSet<SOMCourseHyperlink>();
            this.SOMSectionTeams = new HashSet<SOMSectionTeam>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Nullable<int> enrollmentterm_id { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
        public string sis_course_id { get; set; }
        public Nullable<int> account_id { get; set; }
        public Nullable<bool> is_public { get; set; }
        public string workflow_state { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasAssignment> CanvasAssignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasGroupCategory> CanvasGroupCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasModule> CanvasModules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasSection> CanvasSections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasSectionEnrollment> CanvasSectionEnrollments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMCourseClassYear> SOMCourseClassYears { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMCourseHyperlink> SOMCourseHyperlinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMSectionTeam> SOMSectionTeams { get; set; }
    }
}