﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ogrenciBilgiSistemi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bilgiSistemiEntities : DbContext
    {
        public bilgiSistemiEntities()
            : base("name=bilgiSistemiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alınandersler> alınandersler { get; set; }
        public virtual DbSet<bolum> bolums { get; set; }
        public virtual DbSet<der> ders { get; set; }
        public virtual DbSet<devamsizlik> devamsizliks { get; set; }
        public virtual DbSet<egitman> egitmen { get; set; }
        public virtual DbSet<kullanici> kullanicis { get; set; }
        public virtual DbSet<not> nots { get; set; }
        public virtual DbSet<ogrenci> ogrencis { get; set; }
    }
}
