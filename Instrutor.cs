//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teste_Sponte_Live
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instrutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instrutor()
        {
            this.Live = new HashSet<Live>();
        }
    
        public int Id_Instrutor { get; set; }
        public string nm_Instrutores { get; set; }
        public Nullable<System.DateTime> dt_Nasci_Instrutores { get; set; }
        public string email_Instrutores { get; set; }
        public string insta_Instrutores { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Live> Live { get; set; }
    }
}
