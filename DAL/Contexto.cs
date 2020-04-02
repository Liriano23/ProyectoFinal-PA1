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
        
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data/RepuestoRafa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario por Defecto
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Admin",
                Apellidos = "Admin",
                Cedula= "88888888888",
                Sexo = "Femenino",
                Telefono = "8888888888",
                Celular="8888888888",
                Direccion = "SFM",
                Email = "admin123@gmail.com",
                TipoUsuario = "Administrador",
                FechaIngreso=DateTime.Now,
                NombreUsuario = "Admin",
                Contrasena = "Admin"
            });
        }
    }
}
