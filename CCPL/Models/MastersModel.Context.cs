﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCPL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NSDLEntities : DbContext
    {
        public NSDLEntities()
            : base("name=NSDLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Instrument_master> Instrument_master { get; set; }
        public DbSet<Vendor_master> Vendor_master { get; set; }
        public DbSet<Book_size> Book_size { get; set; }
    }
}
