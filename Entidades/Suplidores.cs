using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinal_PA1.Entidades
{
	public class Suplidores
	{
		
		[Key]
		public int SuplidorId { get; set; }

		public string NombreSuplidor { get; set; }
		public string Apellidos { get; set; }
		public string NombreCompania { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Celular { get; set; }
		public string Ciudad { get; set; }
		public string Email { get; set; }

		[ForeignKey("Usuarios")]
		public int UsuariosId { get; set; }
		public DateTime FechaIngreso { get; set; }
		public ICollection<Productos> Productos { get; set; }

		public Suplidores()
		{
			SuplidorId = 0;
			NombreSuplidor = string.Empty;
			Apellidos = string.Empty;
			NombreCompania = string.Empty;
			Direccion = string.Empty;
			Telefono = string.Empty;
			Celular = string.Empty;
			Ciudad = string.Empty;
			Email = string.Empty;
			FechaIngreso = DateTime.Now;
			UsuariosId = 0;
		}
	}
}
