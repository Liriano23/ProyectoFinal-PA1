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
    public partial class ConsultarCompra : Window
    {
        public ConsultarCompra()
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
                        int empleadoId;
                        empleadoId = int.Parse(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(o => o.EmpleadoId == empleadoId);
                        break;
                    
                }
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
