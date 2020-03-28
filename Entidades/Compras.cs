using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal_PA1.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public int SuplidorId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaDeCompra { get; set; }
        public decimal SubTotal { get; set; }
        public double ITBIS { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalles> Detalle { get; set; }

        public Compras()
        {
            CompraId = 0;
            SuplidorId = 0;
            EmpleadoId = 0;
            FechaDeCompra = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            this.Detalle = new List<VentasDetalles>();
        }
    }
}
