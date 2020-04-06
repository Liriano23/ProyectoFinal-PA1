using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.NombreUsuario = "LaPampara";
            usuarios.Nombres = "Enmanuel";
            usuarios.Contrasena = "LaPampara123";
            usuarios.Apellidos = "Gonzalez liriano";
            usuarios.Cedula = "888-888-888";
            usuarios.Sexo = "masculino";
            usuarios.Direccion = "Deep Park";
            usuarios.Telefono = "888-888-888";
            usuarios.Celular = "888-888-888";
            usuarios.Email = "lol";
            usuarios.TipoUsuario = "";
            
            usuarios.FechaIngreso = DateTime.Now;

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.NombreUsuario = "LaGrasa";
            usuarios.Nombres = "Juan ";
            usuarios.Contrasena = "LaGrasa123";
            usuarios.Apellidos = "fernandez ";
            usuarios.Cedula = "000-888-888";
            usuarios.Sexo = "masculino";
            usuarios.Direccion = " Park";
            usuarios.Telefono = "0-888-888";
            usuarios.Celular = "0-888-888";
            usuarios.Email = "hey";
            usuarios.TipoUsuario = "";

            usuarios.FechaIngreso = DateTime.Now;

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 7;
            paso = UsuariosBLL.Eliminar(usuarios.UsuarioId);
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