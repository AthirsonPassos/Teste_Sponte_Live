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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MeuBD : DbContext
    {
        public MeuBD()
            : base("name=MeuBD")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inscrito> Inscrito { get; set; }
        public virtual DbSet<Instrutor> Instrutor { get; set; }
        public virtual DbSet<Live> Live { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
    }
}
