﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class estiEntities : DbContext
    {
        public estiEntities()
            : base("name=estiEntities")
        {
        }
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ROOM> ROOMS { get; set; }
        public virtual DbSet<STEDENT> STEDENTS { get; set; }
    }
}
