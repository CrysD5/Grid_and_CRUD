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
    
    public partial class SOMFCMGrading
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOMFCMGrading()
        {
            this.SOMFCMGradingGroups = new HashSet<SOMFCMGradingGroup>();
        }
    
        public int id { get; set; }
        public int recnumSch { get; set; }
        public Nullable<int> canvasGroupCategory_id { get; set; }
        public string type { get; set; }
        public string gradeBy { get; set; }
        public string accessLog { get; set; }
    
        public virtual CanvasGroupCategory CanvasGroupCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOMFCMGradingGroup> SOMFCMGradingGroups { get; set; }
    }
}