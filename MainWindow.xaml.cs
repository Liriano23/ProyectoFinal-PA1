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

        private void RegistrarUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormUsuarios fu = new FormUsuarios();
            fu.Show();
        }

        private void ConsultarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ConsultarUsuarios cu = new ConsultarUsuarios();
            cu.Show();
        }

        //private void ConsultarClientes_Click(object sender, RoutedEventArgs e)
        //{
        //    ConsultarClientes consultarClientes = new ConsultarClientes();
        //    consultarClientes.Show();
        //}

        private void RegistrarClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormClientes formularioClientes = new FormClientes();
            formularioClientes.Show();
        }

        private void ConsultarClientes_Click(object sender, RoutedEventArgs e)
        {
            ConsultarClientes consultarClientes = new ConsultarClientes();
            consultarClientes.Show();
        }
    }
}
