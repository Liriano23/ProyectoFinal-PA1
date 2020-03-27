using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

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
        public Suplidores SuplidorId { get; set; }
        public Categorias CategoriaId { get; set; }
        public Usuarios UsuarioId { get; set; }

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
