﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Processors
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SomeOnlineApplicationDBEntities : DbContext
    {
        public SomeOnlineApplicationDBEntities()
            : base("name=SomeOnlineApplicationDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreProductAssociation> StoreProductAssociations { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<UserCartRelation> UserCartRelations { get; set; }
    }
}
