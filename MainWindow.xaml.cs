using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoFinal_PA1.UI.Registros;
using ProyectoFinal_PA1.UI.Consultas;
using ProyectoFinal_PA1.Entidades;
using ProyectoFinal_PA1.BLL;

namespace ProyectoFinal_PA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            Usuarios usuarios = new Usuarios();
        }


        //Boton registrar usuarios
        private void UsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            FormUsuarios fu = new FormUsuarios();
            fu.Show();
        }

        //Boton registrar clientes
        private void ClientesButton_Click(object sender, RoutedEventArgs e)
        {
            
            FormClientes formularioClientes = new FormClientes();
            formularioClientes.Show();
        }

        //Boton registrar Empleados
        private void EmpleadosButton_Click(object sender, RoutedEventArgs e)
        {
            
            FormEmpleados formularioEmpleados = new FormEmpleados();
            formularioEmpleados.Show();
        }

        //Boton registrar Suplidores
        private void SuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {
            
            FormSuplidores formularioSuplidores = new FormSuplidores();
            formularioSuplidores.Show();
        }

        //Boton registrar Productos
        private void ProductosButton_Click(object sender, RoutedEventArgs e)
        {
            
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        //Boton registrar Categorias
        private void CategoriasButton_Click(object sender, RoutedEventArgs e)
        {
            FormCategoria formCategoria = new FormCategoria();
            formCategoria.Show();
            
        }

        //Boton registrar Ventas
        private void VentasButton_Click(object sender, RoutedEventArgs e)
        {
            
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        //Boton registrar Compras
        private void ComprasButton_Click(object sender, RoutedEventArgs e)
        {
            FormCompras formCompras = new FormCompras();
            formCompras.Show();
        }

        //Boton consultar usuarios
        private void ConsultarUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarUsuarios consultarUsuarios = new ConsultarUsuarios();
            consultarUsuarios.Show();
        }

        //Boton consultar Cliente
        private void ConsultarClientesButton_Click(object sender, RoutedEventArgs e)
        {
            
            ConsultarClientes consultarClientes = new ConsultarClientes();
            consultarClientes.Show();
        }

        //Boton consultar Empleados
        private void ConsultarEmpleadosButton_Click(object sender, RoutedEventArgs e)
        {
           
            ConsultaEmpleado consultaEmpleado = new ConsultaEmpleado();
            consultaEmpleado.Show();
        }

        //Boton consultar Suplidores
        private void ConsultarSuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {
            
            ConsultarSuplidor consultarSuplidor = new ConsultarSuplidor();
            consultarSuplidor.Show();
        }

        //Boton consultar Productos
        private void ConsultarProductosButton_Click(object sender, RoutedEventArgs e)
        {
            
            ConsultarProductos consultarProductos = new ConsultarProductos();
            consultarProductos.Show();
        }

        //Boton consultar Categorias
        private void ConsultarCategoriasButton_Click(object sender, RoutedEventArgs e)
        {
            
            ConsultarCategoria consultarCategoria = new ConsultarCategoria();
            consultarCategoria.Show();
        }

        //Boton consultar Ventas
        private void ConsultarVentasButton_Click(object sender, RoutedEventArgs e)
        {
            
            ConsultarVentas consultarVentas = new ConsultarVentas();
            consultarVentas.Show();
            
        }

        //Boton consultar compras
        private void ConsultarComprasButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarCompra consultarCompra = new ConsultarCompra();
            consultarCompra.Show();
        }

        private void CerrarSecion_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Close();
            logIn.Show();
        }
    }
}
