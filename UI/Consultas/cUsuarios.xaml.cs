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
using ProyectoFinal_PA1.BLL;
using ProyectoFinal_PA1.Entidades;
namespace ProyectoFinal_PA1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for ConsultarUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = UsuariosBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = UsuariosBLL.GetList(x => x.UsuarioId == id);
                        break;

                    case 2:
                        listado = UsuariosBLL.GetList(x => x.Nombres == CriterioTextBox.Text);
                        break;
                    case 3:
                        listado = UsuariosBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
