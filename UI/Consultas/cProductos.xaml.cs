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
    /// Interaction logic for ConsultarProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cProductos(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UserActive.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductosBLL.GetList(x => true);
                        break;

                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.ProductoId == id);
                        break;

                    case 2:
                        listado = ProductosBLL.GetList(x => x.NombreProducto == CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = ProductosBLL.GetList(x => x.MarcaProducto == CriterioTextBox.Text);
                        break;

                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;

                    case 5:
                        int idC;
                        idC = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.CategoriaId == idC);
                        break;

                    case 6:
                        int idS;
                        idS = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.SuplidorId == idS);
                        break;

                    case 7:
                        int idU;
                        idU = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.UsuariosId == idU);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
            {
                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = ProductosBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }

        private void ConsultarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
