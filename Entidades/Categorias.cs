﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal_PA1.Entidades
{
    public class Categorias
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("CategoriaId")]
        public int UsuarioId { get; set; }
        public Categorias()
        {
            CategoriaId = 0;
            NombreCategoria = string.Empty;
            Descripcion = string.Empty;
            UsuarioId = 0;
        }
    }
}
