﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_FMSEntities : DbContext
    {
        public db_FMSEntities()
            : base("name=db_FMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<FACE> FACE { get; set; }
        public virtual DbSet<INGREDIENT> INGREDIENT { get; set; }
        public virtual DbSet<LOGIN> LOGIN { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<SPLIT_TIME> SPLIT_TIME { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIER { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SPLIT_SHIFTS> SPLIT_SHIFTS { get; set; }
    }
}
