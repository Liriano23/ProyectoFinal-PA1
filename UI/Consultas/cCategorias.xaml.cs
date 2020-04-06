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
    /// Lógica de interacción para ConsultarCategoria.xaml
    /// </summary>
    public partial class cCategorias : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cCategorias(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UserActive.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Categorias>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = CategoriasBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = CategoriasBLL.GetList(x => x.CategoriaId == id);
                        break;

                    case 2:
                        listado = CategoriasBLL.GetList(x => x.NombreCategoria == CriterioTextBox.Text);
                        break;
                    case 3:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = CategoriasBLL.GetList(x => x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;

                    case 4:
                        int idU;
                        idU = int.Parse(CriterioTextBox.Text);
                        listado = CategoriasBLL.GetList(x => x.UsuariosId == idU);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 3)
            {
                listado = CategoriasBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = CategoriasBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
