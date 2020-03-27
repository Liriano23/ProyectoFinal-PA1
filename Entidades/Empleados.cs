using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal_PA1.Entidades
{
    public class Empleados
    {
		public int EmpleadoId { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Cedula { get; set; }
		public string Telefono { get; set; }
		public string Celular { get; set; }
		public string Direccion { get; set; }
		public string Email { get; set; }
		public string Cargo { get; set; }
		public decimal sueldo { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public DateTime FechaIngreso { get; set; }

		[ForeignKey("EmpleadoId")]
		public int UsuarioId { get; set; }

		public Empleados()
		{
			EmpleadoId = 0;
			Nombres = string.Empty;
			Apellidos = string.Empty;
			Cedula = string.Empty;
			Telefono = string.Empty;
			Celular = string.Empty;
			Direccion = string.Empty;
			Email = string.Empty;
			Celular = string.Empty;
			Cargo = string.Empty;
			sueldo = 0;
			FechaNacimiento = DateTime.Now;
			FechaIngreso = DateTime.Now;
			UsuarioId = 0;
		}
	}
}
