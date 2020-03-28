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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormUsuarios fu = new FormUsuarios();
            fu.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FormClientes formularioClientes = new FormClientes();
            formularioClientes.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FormEmpleados formularioEmpleados = new FormEmpleados();
            formularioEmpleados.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FormSuplidores formularioSuplidores = new FormSuplidores();
            formularioSuplidores.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ConsultarUsuarios consultarUsuarios = new ConsultarUsuarios();
            consultarUsuarios.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ConsultarClientes consultarClientes = new ConsultarClientes();
            consultarClientes.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ConsultaEmpleado consultaEmpleado = new ConsultaEmpleado();
            consultaEmpleado.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ConsultarSuplidor consultarSuplidor = new ConsultarSuplidor();
            consultarSuplidor.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            ConsultarProductos consultarProductos = new ConsultarProductos();
            consultarProductos.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Te falta ingresar la consulta de veta");
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            ConsultarCategoria consultarCategoria = new ConsultarCategoria();
            consultarCategoria.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            FormCategoria formCategoria = new FormCategoria();
            formCategoria.Show();
        }
    }
}
