using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal_PA1.Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

        [ForeignKey("Usuarios")]
        public int UsuariosId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ICollection<Productos> Productos { get; set; }


        public Categorias()
        {
            CategoriaId = 0;
            NombreCategoria = string.Empty;
            UsuariosId = 0;
            FechaIngreso = DateTime.Now;
        }
    }
}
