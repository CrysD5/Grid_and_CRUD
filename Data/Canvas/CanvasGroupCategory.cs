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
    
    public partial class CanvasGroupCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanvasGroupCategory()
        {
            this.CanvasAssignments = new HashSet<CanvasAssignment>();
            this.CanvasGroups = new HashSet<CanvasGroup>();
            this.SOMFCMGradings = new HashSet<SOMFCMGrading>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> canvascourse_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasAssignment> CanvasAssignments { get; set; }
        public virtual CanvasCourse CanvasCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanvasGroup> CanvasGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMFCMGrading> SOMFCMGradings { get; set; }
    }
}
