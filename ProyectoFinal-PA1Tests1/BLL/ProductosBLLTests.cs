using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 0;
            productos.NombreProducto = "Goma";
            productos.MarcaProducto = "Michelin";
            productos.Inventario = 5;
            productos.FechaIngreso = DateTime.Now;
            productos.SuplidorId = 1;
            productos.CategoriaId = 1;
            productos.UsuariosId = 1;
            

            paso = ProductosBLL.Guardar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 0;
            productos.NombreProducto = "Tanque de Motor CG150";
            productos.MarcaProducto = "Super Gato";
            productos.Inventario = 5;
            productos.FechaIngreso = DateTime.Now;
            productos.SuplidorId = 1;
            productos.CategoriaId = 1;
            productos.UsuariosId = 1;


            paso = ProductosBLL.Modificar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 1;
            paso = ProductosBLL.Eliminar(productos.ProductoId);
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

        [TestMethod()]
        public void DisminuirInventarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AumentarInventarioTest()
        {
            Assert.Fail();
        }
    }
}