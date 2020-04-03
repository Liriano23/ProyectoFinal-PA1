using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 3;
            ventas.ClienteId = 0;
            ventas.EmpleadoId = 0;
            ventas.FechaEmision = DateTime.Now;
            ventas.SubTotal = 400;
            ventas.ITBIS = 0.18;
            ventas.Descuento = 10;
            ventas.Total = 350;

            paso = VentasBLL.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 1;
            ventas.ClienteId = 1;
            ventas.EmpleadoId = 1;
            ventas.FechaEmision = DateTime.Now;
            ventas.SubTotal = 430;
            ventas.ITBIS = 0.18;
            ventas.Descuento = 10;
            ventas.Total = 360;

            paso = VentasBLL.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 1;
            paso = VentasBLL.Eliminar(ventas.VentaId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}