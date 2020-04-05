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
using System.Linq;
using System.Linq.Expressions;
namespace ProyectoFinal_PA1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for ConsultarUsuarios.xaml
    /// </summary>
    
    public partial class cUsuarios : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cUsuarios(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UserActive.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

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
                        
                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = UsuariosBLL.GetList(x=> x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
            {
                listado = UsuariosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
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
