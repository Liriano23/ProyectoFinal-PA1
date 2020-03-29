using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoFinal_PA1.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }

        public string MarcaProducto { get; set; }

        public int Inventario { get; set; }
        public DateTime FechaIngreso { get; set; }
        [ForeignKey("Suplidores")]
        public int SuplidorId { get; set; }

        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }

        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }

        public Productos()
        {
            ProductoId = 0;
            NombreProducto = string.Empty;
            MarcaProducto = string.Empty;
            Inventario = 0;
            FechaIngreso = DateTime.Now;
        }

    }
}
