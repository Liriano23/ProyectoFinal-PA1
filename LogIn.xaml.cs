using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProyectoFinal_PA1.Entidades;
using ProyectoFinal_PA1.BLL;

namespace ProyectoFinal_PA1
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        List<Usuarios> lista = new List<Usuarios>();
        public int UsuarioId;

        public LogIn()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            
            lista = UsuariosBLL.GetList(p => true);
            bool paso = false;
            
            //Si existe usuario en base de datos
            foreach (var item in lista)
            {
                if ((item.NombreUsuario == NombreUsuarioTextBox.Text) && (item.Contrasena == contrasenaBox.Password))
                {
                    UsuarioId = Convert.ToInt32(item.UsuarioId);
                    MainWindow main = new MainWindow(UsuarioId);
                    main.Show();
                    paso = true;
                    this.Close();
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Nombre de usuario o Contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreUsuarioTextBox.Text = string.Empty;
                contrasenaBox.Password = string.Empty;
                NombreUsuarioTextBox.Focus();
            }
        }


    }
}
