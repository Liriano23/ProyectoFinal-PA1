﻿using ProyectoFinal_PA1.BLL;
using ProyectoFinal_PA1.Entidades;
using ProyectoFinal_PA1.UI.Consultas;
using ProyectoFinal_PA1.UI.Registros;
using System.Windows;

namespace ProyectoFinal_PA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public MainWindow(int UsuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = UsuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UsuarioActivoTextBox.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());
        }

        //Boton registrar usuarios
        private void UsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuario = new rUsuarios();
            rUsuario.Show();
        }

        //Boton registrar clientes
        private void ClientesButton_Click(object sender, RoutedEventArgs e)
        {

            rClientes rCliente = new rClientes();
            rCliente.Show();
        }

        //Boton registrar Empleados
        private void EmpleadosButton_Click(object sender, RoutedEventArgs e)
        {

            rEmpleados formularioEmpleados = new rEmpleados();
            formularioEmpleados.Show();
        }

        //Boton registrar Suplidores
        private void SuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {

            rSuplidores rSuplidore = new rSuplidores();
            rSuplidore.Show();
        }

        //Boton registrar Productos
        private void ProductosButton_Click(object sender, RoutedEventArgs e)
        {

            rProductos rProducto = new rProductos(usuarioSiempreActivoId);
            rProducto.Show();
        }

        //Boton registrar Categorias
        private void CategoriasButton_Click(object sender, RoutedEventArgs e)
        {
            rCategorias rCategoria = new rCategorias();
            rCategoria.Show();

        }

        //Boton registrar Ventas
        private void VentasButton_Click(object sender, RoutedEventArgs e)
        {
            rVentas rVenta = new rVentas(usuarioSiempreActivoId);
            rVenta.Show();
        }

        //Boton registrar Compras
        private void ComprasButton_Click(object sender, RoutedEventArgs e)
        {
            rCompras rCompra = new rCompras(usuarioSiempreActivoId);
            rCompra.Show();
        }

        //Boton consultar usuarios
        private void ConsultarUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuario = new cUsuarios(usuarioSiempreActivoId);
            cUsuario.Show();
        }

        //Boton consultar Cliente
        private void ConsultarClientesButton_Click(object sender, RoutedEventArgs e)
        {

            cClientes cCliente = new cClientes(usuarioSiempreActivoId);
            cCliente.Show();
        }

        //Boton consultar Empleados
        private void ConsultarEmpleadosButton_Click(object sender, RoutedEventArgs e)
        {

            cEmpleados cEmpleado = new cEmpleados(usuarioSiempreActivoId);
            cEmpleado.Show();
        }

        //Boton consultar Suplidores
        private void ConsultarSuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {

            cSuplidores consultarSuplidor = new cSuplidores(usuarioSiempreActivoId);
            consultarSuplidor.Show();
        }

        //Boton consultar Productos
        private void ConsultarProductosButton_Click(object sender, RoutedEventArgs e)
        {

            cProductos cProducto = new cProductos(usuarioSiempreActivoId);
            cProducto.Show();
        }

        //Boton consultar Categorias
        private void ConsultarCategoriasButton_Click(object sender, RoutedEventArgs e)
        {

            cCategorias cCategoria = new cCategorias(usuarioSiempreActivoId);
            cCategoria.Show();
        }

        //Boton consultar Ventas
        private void ConsultarVentasButton_Click(object sender, RoutedEventArgs e)
        {

            cVentas cVenta = new cVentas(usuarioSiempreActivoId);
            cVenta.Show();

        }

        //Boton consultar compras
        private void ConsultarComprasButton_Click(object sender, RoutedEventArgs e)
        {
            cCompras cCompra = new cCompras(usuarioSiempreActivoId);
            cCompra.Show();
        }

        private void CerrarSecion_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Close();
            logIn.Show();
        }
    }
}
