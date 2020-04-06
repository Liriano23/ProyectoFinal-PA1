using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class ComprasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 3;
            compras.SuplidorId = 0;
            compras.FechaDeCompra = DateTime.Now;
            compras.SubTotal = 500;
            compras.ITBIS = 0.18;
            compras.Descuento = 50;
            compras.Total = 400;
            
            paso = ComprasBLL.Guardar(compras);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 1;
            compras.SuplidorId = 1;
            compras.FechaDeCompra = DateTime.Now;
            compras.SubTotal = 500;
            compras.ITBIS = 0.18;
            compras.Descuento = 50;
            compras.Total = 400;

            paso = ComprasBLL.Modificar(compras);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 1;
            paso = ComprasBLL.Eliminar(compras.CompraId);
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