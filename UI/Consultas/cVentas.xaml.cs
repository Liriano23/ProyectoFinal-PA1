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
    /// Interaction logic for ConsultarVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = VentasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.VentaId == id);
                        break;

                    case 2:
                        int clienteId;
                        clienteId = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.ClienteId == clienteId);
                        break;

                    case 3:
                        decimal total;
                        total = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.Total == total);
                        break;

                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(x => x.FechaEmision.Date >= fecha.Date && x.FechaEmision.Date <= fecha.Date);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
            {
                listado = VentasBLL.GetList(x => x.FechaEmision.Date >= DesdeDateTimePicker.SelectedDate && x.FechaEmision.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = VentasBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
