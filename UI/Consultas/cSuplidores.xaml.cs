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

namespace ProyectoFinal_PA1.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para ConsultarSuplidor.xaml
    /// </summary>
    public partial class cSuplidores : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cSuplidores(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UserActive.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Suplidores>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = SuplidoresBLL.GetList(x => true);
                        break;

                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = SuplidoresBLL.GetList(x => x.SuplidorId == id);
                        break;

                    case 2:
                        listado = SuplidoresBLL.GetList(x => x.NombreSuplidor == CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = SuplidoresBLL.GetList(x => x.Apellidos == CriterioTextBox.Text);
                        break;

                    case 4:
                        listado = SuplidoresBLL.GetList(x => x.NombreCompania == CriterioTextBox.Text);
                        break;

                    case 5:
                        listado = SuplidoresBLL.GetList(x => x.Direccion == CriterioTextBox.Text);
                        break;

                    case 6:
                        listado = SuplidoresBLL.GetList(x => x.Telefono == CriterioTextBox.Text);
                        break;

                    case 7:
                        listado = SuplidoresBLL.GetList(x => x.Celular == CriterioTextBox.Text);
                        break;

                    case 8:
                        listado = SuplidoresBLL.GetList(x => x.Ciudad == CriterioTextBox.Text);
                        break;

                        case 9:
                        listado = SuplidoresBLL.GetList(x => x.Email == CriterioTextBox.Text);
                        break;

                    case 10:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = SuplidoresBLL.GetList(x => x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;

                    case 11:
                        int idU;
                        idU = int.Parse(CriterioTextBox.Text);
                        listado = SuplidoresBLL.GetList(x => x.UsuariosId == idU);
                        break;

                }
            }
            else if (FiltrarComboBox.SelectedIndex == 10)
            {
                listado = SuplidoresBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = SuplidoresBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
