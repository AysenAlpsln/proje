//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KITAPLIK.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class yazarlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yazarlar()
        {
            this.Kıtaplar = new HashSet<Kıtaplar>();
        }
    
        public int Yazarıd { get; set; }
        public string YazarAdSoyad { get; set; }
        public string dogum { get; set; }
        public string olum { get; set; }
        public string okul { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kıtaplar> Kıtaplar { get; set; }
    }
}
