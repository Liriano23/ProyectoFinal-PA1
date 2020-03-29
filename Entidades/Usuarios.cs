using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_PA1.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public ICollection<Categorias> Categorias { get; set; }
        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<Compras> Compras { get; set; }
        public ICollection<Empleados> Empleados { get; set; }
        public ICollection<Productos> Productos { get; set; }
        public ICollection<Suplidores> Suplidores { get; set; }
        //public ICollection<Ventas> Suplidores { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Sexo = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            FechaIngreso = DateTime.Now;
            TipoUsuario = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
        }
    }
}
