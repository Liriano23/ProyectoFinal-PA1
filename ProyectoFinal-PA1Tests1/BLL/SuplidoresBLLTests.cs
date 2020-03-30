using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 0;
            suplidores.NombreSuplidor = "Enmanuel";
            suplidores.Apellidos = "Gonzalez liriano";
            suplidores.NombreCompania = "Michelin";
            suplidores.Direccion = "SFM";
            suplidores.Telefono = "111-888-888";
            suplidores.Celular = "111-888-888";
            suplidores.Email = "hola";
            suplidores.UsuariosId = 1;

            paso = SuplidoresBLL.Guardar(suplidores);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 0;
            suplidores.NombreSuplidor = "juan";
            suplidores.Apellidos = "ferandez ";
            suplidores.NombreCompania = "Michelin";
            suplidores.Direccion = "Santigo";
            suplidores.Telefono = "000-888-888";
            suplidores.Celular = "000-888-888";
            suplidores.Email = "hey";
            suplidores.UsuariosId = 1;

            paso = SuplidoresBLL.Guardar(suplidores);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 7;
            paso = SuplidoresBLL.Eliminar(suplidores.SuplidorId);
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