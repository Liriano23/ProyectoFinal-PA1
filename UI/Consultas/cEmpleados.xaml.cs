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
    /// Lógica de interacción para ConsultaEmpleado.xaml
    /// </summary>
    public partial class cEmpleados : Window
    {
        public cEmpleados()
        {
            InitializeComponent();
        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Empleados>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = EmpleadosBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = EmpleadosBLL.GetList(x => x.EmpleadoId == id);
                        break;

                    case 2:
                        listado = EmpleadosBLL.GetList(x => x.Nombres == CriterioTextBox.Text);
                        break;
                    case 3:
                        listado = EmpleadosBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                listado = EmpleadosBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
