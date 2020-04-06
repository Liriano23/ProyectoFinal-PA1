using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_PA1.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal SubTotal { get; set; }
        public double ITBIS { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalles> Detalle { get; set; }

        [ForeignKey("Usuarios")]

        public int UsuariosId { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            EmpleadoId = 0;
            FechaEmision = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            Detalle = new List<VentasDetalles>();
            UsuariosId = 0;
        }
    }
}
