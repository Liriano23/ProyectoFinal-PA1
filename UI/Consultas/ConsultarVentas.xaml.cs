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
    public partial class ConsultarVentas : Window
    {
        public ConsultarVentas()
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

                }
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
