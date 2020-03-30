using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class CategoriasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 0;
            categorias.NombreCategoria = "Nuevo";
            categorias.UsuariosId = 1;

            paso = CategoriasBLL.Guardar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 1;
            categorias.NombreCategoria = "Usado";
            categorias.UsuariosId = 1;

            paso = CategoriasBLL.Guardar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 1;
            paso = CategoriasBLL.Eliminar(categorias.CategoriaId);
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