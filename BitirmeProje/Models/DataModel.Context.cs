﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitirmeProje.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbWebSiteEntities : DbContext
    {
        public DbWebSiteEntities()
            : base("name=DbWebSiteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BLOGLAR> BLOGLAR { get; set; }
        public virtual DbSet<KATEGORILER> KATEGORILER { get; set; }
        public virtual DbSet<MESAJLAR> MESAJLAR { get; set; }
        public virtual DbSet<UYELER> UYELER { get; set; }
    }
}