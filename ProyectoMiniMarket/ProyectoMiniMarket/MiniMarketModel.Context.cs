﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoMiniMarket
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class minimarketDBEntities1 : DbContext
    {
        public minimarketDBEntities1()
            : base("name=minimarketDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<detallesdeVentas> detallesdeVentas { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    }
}
