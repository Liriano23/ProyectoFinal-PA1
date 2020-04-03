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
using ProyectoFinal_PA1.UI.Consultas;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Interaction logic for FormVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        /// <summary>
        /// </summary>
        //Atributos Auxiliares
        private decimal SubTotal;
        private decimal Total;
        private int Cantidad;
        private decimal Precio;
        private decimal Itbis;
        private decimal Bandera;
        private decimal AplicaPorcentaje;
        private double Porcentaje;
        private decimal Descuento;

        Ventas venta = new Ventas();
        public List<VentasDetalles> Detalle { get; set; }

        public rVentas()
        {
            InitializeComponent();
            
            this.DataContext = venta;

            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            ProductoIdTextBox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            TotalTextBox.Text = "0";

            this.Detalle = new List<VentasDetalles>();

            Cantidad = (Cantidad < 0) ? Cantidad = 0 : Cantidad;
            Precio = (Precio < 0) ? Precio = 0 : Precio;
            Itbis = (Bandera < 0) ? Itbis = 0 : Itbis;
            Bandera = (Bandera < 0) ? Bandera = 0 : Bandera;
            Porcentaje = (Porcentaje < 0) ? Porcentaje = 0 : Porcentaje;
            AplicaPorcentaje = (Total < 0) ? AplicaPorcentaje = 0 : AplicaPorcentaje;
            SubTotal = (SubTotal < 0) ? SubTotal = 0 : SubTotal;
            Total = (Total < 0) ? Total = 0 : Total;
        }

        private void Limpiar()
        {

            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            ProductoIdTextBox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            ITBISTextBox.Text = "18";
            SubTotalTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;
            SubTotal = 0;
            Total = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            AplicaPorcentaje = 0;
            Porcentaje = 0;
            this.Detalle = new List<VentasDetalles>();
            CargarGrid();
            Ventas venta = new Ventas();

            Actualizar();
        }


        private void LlenaCampo(Ventas ventas)
        {
            VentaIdTextBox.Text = Convert.ToString(ventas.VentaId);
            ClienteIdTextbox.Text = Convert.ToString(ventas.ClienteId);
            EmpleadoIdTextbox.Text = Convert.ToString(ventas.EmpleadoId);
            FechaVentaDateTimePicker.SelectedDate = ventas.FechaEmision;
            ITBISTextBox.Text = Convert.ToString(ventas.ITBIS);
            DescuentoTextBox.Text = Convert.ToString(ventas.Descuento);
            
            SubTotal = ventas.SubTotal;
            Total = ventas.Total;
            SubTotalTextBox.Text = Convert.ToString(SubTotal);
            TotalTextBox.Text = Convert.ToString(Total);
            
            this.Detalle = ventas.Detalle;
            CargarGrid();
        }

        private bool ExisteEnDB()
        {
            Ventas ventas = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (ventas != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = venta;
        }

        private void CargarGrid()
        {
            VentaDetalleDataGrid.ItemsSource = null;
            VentaDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(VentaIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Venta Id no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                VentaIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ClienteIdTextbox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Cliente Id no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClienteIdTextbox.Focus();

            }

            if (string.IsNullOrEmpty(EmpleadoIdTextbox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Empleado Id no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmpleadoIdTextbox.Focus();
            }

            if (SubTotalTextBox.Text == "0" || string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                MessageBox.Show("Debe completar el capo SubTotal", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                SubTotalTextBox.Focus();
            }
           
            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Descuento no puede estar vacio o debe ser 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DescuentoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(FechaVentaDateTimePicker.Text))
            {
                paso = false;
                MessageBox.Show("El campo Fecha Venta no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                FechaVentaDateTimePicker.Focus();
            }

            if(string.IsNullOrEmpty(TotalTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Total no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TotalTextBox.Focus();
            }
            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La venta debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(VentaIdTextBox.Text) || VentaIdTextBox.Text == "0")
                paso = VentasBLL.Guardar(venta);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("No existe el cliente en la base de " +
                        "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = VentasBLL.Modificar(venta);
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
            int.TryParse(VentaIdTextBox.Text, out id);

            try
            {
                if (VentasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentaDetalleDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<VentasDetalles>)VentaDetalleDataGrid.ItemsSource;
            }

            this.Detalle.Add(new VentasDetalles
            {
                Id = 0,
                ProductoId = Convert.ToInt32(ProductoIdTextBox.Text),
                Precio = Convert.ToInt32(PrecioTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });

            CargarGrid();
            AumentarSubTotal();
            AumentarTotal();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdTextBox.Text);
            ProductosBLL.DisminuirInventario(id, valor);

            ProductoIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
        }

        private void AumentarSubTotal() //Metodo para aumentar el subTotal
        {
            Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            Porcentaje = Convert.ToDouble(Convert.ToDouble(ITBISTextBox.Text) / 100);
            Itbis = (decimal)Porcentaje;
            Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Bandera = Convert.ToDecimal(Precio * Cantidad);
            AplicaPorcentaje = (Bandera * Itbis);
            SubTotal += (Bandera);
        }

        private void RemoveFromSubTotal() //Metodo para Remover cantidad del Subtotal si se elimina un producto del Grid
        {
            SubTotal -= (Bandera);
        }

        private void RemoveFromTotal() //Metodo para Remover cantidad del Total si se elimina un producto del Grid
        {
            Total = SubTotal;
        }

        private void AumentarTotal()
        {
            Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            Total = (SubTotal + AplicaPorcentaje) - Descuento;
        }
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentaDetalleDataGrid.Items.Count > 0 && VentaDetalleDataGrid.SelectedItem != null)
            {
                Detalle.RemoveAt(VentaDetalleDataGrid.SelectedIndex);
                RemoveFromSubTotal();
                RemoveFromTotal();
                CargarGrid();
            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Ventas sale = new Ventas();
            int.TryParse(VentaIdTextBox.Text, out id);

            sale = VentasBLL.Buscar(id);

            if (sale != null)
            {
                LlenaCampo(sale);
            }
            else
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SubTotalTextBox.Text = Convert.ToString(SubTotal);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ConsualarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            cClientes consultarClientes = new cClientes();
            consultarClientes.Show();
        }

        private void ConsultarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            cEmpleados consultaEmpleado = new cEmpleados();
            consultaEmpleado.Show();
        }
    }
}
