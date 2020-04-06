using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA1.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.BLL.Tests
{
    [TestClass()]
    public class EmpleadosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 0;
            empleados.Nombres = "Enmanuel";
            empleados.Apellidos = "Gonzalez liriano";
            empleados.Cedula = "111-888-888";
            empleados.Cargo = "Mecanico";
            empleados.Sueldo = 10000;
            empleados.Direccion = "Park";
            empleados.Telefono = "111-888-888";
            empleados.Celular = "111-888-888";
            empleados.Email = "hola";
            empleados.FechaNacimiento = DateTime.Now;
            empleados.FechaIngreso = DateTime.Now;
            empleados.UsuariosId = 1;

            paso = EmpleadosBLL.Guardar(empleados);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 1;
            empleados.Nombres = "juan de dios";
            empleados.Apellidos = "Fernandez camilo";
            empleados.Cedula = "000-888-888";
            empleados.Cargo = "Mecanico";
            empleados.Sueldo = 100000;
            empleados.Direccion = "Park";
            empleados.Telefono = "000-888-888";
            empleados.Celular = "000-888-888";
            empleados.Email = "hey";
            empleados.FechaNacimiento = DateTime.Now;
            empleados.FechaIngreso = DateTime.Now;
            empleados.UsuariosId = 1;

            paso = EmpleadosBLL.Modificar(empleados);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 1;
            paso = EmpleadosBLL.Eliminar(empleados.EmpleadoId);
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