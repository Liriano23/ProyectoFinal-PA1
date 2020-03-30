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
using ProyectoFinal_PA1.BLL;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para FormCompras.xaml
    /// </summary>
    public partial class FormCompras : Window
    {
        Compras compra = new Compras();
        public List<ComprasDetalle> Detalle { get; set; }
        public FormCompras()
        {
            
            InitializeComponent();

            CompraIDTextBox.Text = "0";
            SuplidorIdTextbox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            ProductoIdTexBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";

            this.DataContext = compra;
            this.Detalle = new List<ComprasDetalle>();

            CargarGrid();
        }
        private void Limpiar()
        {
            CompraIDTextBox.Text = "0";
            SuplidorIdTextbox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            ProductoIdTexBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaDeCompraTimePicker.SelectedDate = DateTime.Now;

            Compras compra = new Compras();
            this.Detalle = new List<ComprasDetalle>();
            CargarGrid();
            Actualizar();
        }
        
        private bool ExisteEnDB()
        {
            Compras compra = ComprasBLL.Buscar(Convert.ToInt32(CompraIDTextBox.Text));
            return (compra != null);
        }

        private void CargarGrid()
        {
            CompraDetalleDataGrid.ItemsSource = null;
            CompraDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private Compras LlenaClase()
        {
            Compras compras = new Compras();
            compras.CompraId = int.Parse(CompraIDTextBox.Text);
            compras.SuplidorId = int.Parse(SuplidorIdTextbox.Text);
            compras.FechaDeCompra = (DateTime)FechaDeCompraTimePicker.SelectedDate;
            compras.SubTotal = decimal.Parse(SubTotalTextBox.Text);
            compras.ITBIS = double.Parse(ITBISTextBox.Text);
            compras.Descuento = decimal.Parse(DescuentoTextBox.Text);
            compras.Total = decimal.Parse(TotalTextBox.Text); 
            compras.Detalle = this.Detalle;

            return compras;
        }

        private void LlenaCampo(Compras compra)
        {
            CompraIDTextBox.Text = Convert.ToString(compra.CompraId);
            SuplidorIdTextbox.Text = Convert.ToString(compra.SuplidorId);
            FechaDeCompraTimePicker.SelectedDate = compra.FechaDeCompra;
            SubTotalTextBox.Text = Convert.ToString(compra.SubTotal);
            ITBISTextBox.Text = Convert.ToString(compra.ITBIS);
            DescuentoTextBox.Text = Convert.ToString(compra.Descuento);
            TotalTextBox.Text = Convert.ToString(compra.Total);

            this.Detalle = compra.Detalle;
            CargarGrid();

        }


        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = compra;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                paso = false;
                TotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }


            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                paso = false;
                DescuentoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ITBISTextBox.Text))
            {
                paso = false;
                ITBISTextBox.Focus();

            }

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(FechaDeCompraTimePicker.Text))
            {
                paso = false;
                FechaDeCompraTimePicker.Focus();

            }


            if (string.IsNullOrEmpty(SuplidorIdTextbox.Text))
            {
                paso = false;
                SuplidorIdTextbox.Focus();

            }

            if (string.IsNullOrEmpty(CompraIDTextBox.Text))
            {
                paso = false;
                CompraIDTextBox.Focus();

            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La Compra debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CompraDetalleDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<ComprasDetalle>)CompraDetalleDataGrid.ItemsSource;
            }

            this.Detalle.Add(new ComprasDetalle
            {
                Id = 0,
                ProductoId = Convert.ToInt32(ProductoIdTexBox.Text),
                Precio = Convert.ToInt32(PrecioTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });

            CargarGrid();
            ProductoIdTexBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
           
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (CompraDetalleDataGrid.Items.Count > 0 && CompraDetalleDataGrid.SelectedItem != null)
            {
                Detalle.RemoveAt(CompraDetalleDataGrid.SelectedIndex);
                CargarGrid();
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Compras compra;

            if (!Validar())
                return;

            compra = LlenaClase();

            if (string.IsNullOrEmpty(CompraIDTextBox.Text) || CompraIDTextBox.Text == "0")
                paso = ComprasBLL.Guardar(compra);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("Persona No Encontrada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = ComprasBLL.Modificar(compra);
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void ElimnarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(CompraIDTextBox.Text, out id);

            if (ComprasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Compras compra = new Compras();
            int.TryParse(CompraIDTextBox.Text, out id);

            compra = ComprasBLL.Buscar(id);

            if (compra != null)
            {
                LlenaCampo(compra);
            }
            else
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
