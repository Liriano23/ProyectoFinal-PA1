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
    /// Lógica de interacción para ConsultarCompra.xaml
    /// </summary>
    public partial class cCompras : Window
    {
        public cCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Compras>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ComprasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(o => o.CompraId == id);
                        break;
                    case 2:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(x => x.FechaDeCompra.Date >= fecha.Date && x.FechaDeCompra.Date <= fecha.Date);
                        break;
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 2)
            {
                listado = ComprasBLL.GetList(x => x.FechaDeCompra.Date >= DesdeDateTimePicker.SelectedDate && x.FechaDeCompra.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = ComprasBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
