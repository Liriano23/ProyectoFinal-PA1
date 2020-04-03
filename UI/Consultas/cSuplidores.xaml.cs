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
        public cSuplidores()
        {
            InitializeComponent();
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
                        listado = SuplidoresBLL.GetList(x => x.NombreCompania == CriterioTextBox.Text);
                        break;
                }
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
