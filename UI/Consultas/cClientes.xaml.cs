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
    /// Interaction logic for ConsultarClientes.xaml
    /// </summary>
    public partial class cClientes : Window
    {

        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cClientes(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UserActive.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ClientesBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(x => x.ClienteId == id);
                        break;

                    case 2:
                        listado = ClientesBLL.GetList(x => x.Nombres == CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = ClientesBLL.GetList(x => x.Apellidos == CriterioTextBox.Text);
                        break;

                    case 4:
                        listado = ClientesBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;

                    case 5:
                        listado = ClientesBLL.GetList(x => x.Sexo == CriterioTextBox.Text);
                        break;

                    case 6:
                        listado = ClientesBLL.GetList(x => x.Direccion == CriterioTextBox.Text);
                        break;

                    case 7:
                        listado = ClientesBLL.GetList(x => x.Telefono == CriterioTextBox.Text);
                        break;

                    case 8:
                        listado = ClientesBLL.GetList(x => x.Celular == CriterioTextBox.Text);
                        break;

                    case 9:
                        listado = ClientesBLL.GetList(x => x.Email == CriterioTextBox.Text);
                        break;

                    case 10:
                        DateTime fechaN = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(x => x.FechaNacimiento.Date >= fechaN.Date && x.FechaIngreso.Date <= fechaN.Date);
                        break;

                    case 11:
                        DateTime fechaI = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(x => x.FechaIngreso.Date >= fechaI.Date && x.FechaIngreso.Date <= fechaI.Date);
                        break;

                    case 12:
                        int idU;
                        idU = int.Parse(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(x => x.UsuariosId == idU);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 10)
            {
                listado = ClientesBLL.GetList(x => x.FechaNacimiento.Date >= DesdeDateTimePicker.SelectedDate && x.FechaNacimiento.Date <= HastaDateTimePicker.SelectedDate);
            }
            else if (FiltrarComboBox.SelectedIndex == 11)
            {
                listado = ClientesBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = ClientesBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }

    }
}
