using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Nombres = "Enmanuel";
            clientes.Apellidos = "Gonzalez liriano";
            clientes.Cedula = "888-888-888";
            clientes.Sexo = "masculino";
            clientes.Direccion = "Deep Park";
            clientes.Telefono = "888-888-888";
            clientes.Celular = "888-888-888";
            clientes.Email = "lol";
            clientes.FechaNacimiento = DateTime.Now;
            clientes.FechaIngreso = DateTime.Now;
            clientes.UsuariosId = 0;

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Nombres = "juan de dios";
            clientes.Apellidos = "Fernandez camilo";
            clientes.Cedula = "111-888-888";
            clientes.Sexo = "masculino";
            clientes.Direccion = "Park";
            clientes.Telefono = "111-888-888";
            clientes.Celular = "111-888-888";
            clientes.Email = "hola";
            clientes.FechaNacimiento = DateTime.Now;
            clientes.FechaIngreso = DateTime.Now;
            clientes.UsuariosId = 0;

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 7;
            paso = ClientesBLL.Eliminar(clientes.ClienteId);
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