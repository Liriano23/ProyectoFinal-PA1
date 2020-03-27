using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.DAL
{
    public class Contexto : DbContext
    {
        
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
       
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data/RepuestoRafa");
        }
    }
}
