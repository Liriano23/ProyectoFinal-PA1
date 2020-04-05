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
       
        public cClientes()
        {
            InitializeComponent();
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
                        listado = ClientesBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;
                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(x => x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
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
