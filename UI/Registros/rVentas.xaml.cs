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
    /// Lógica de interacción para FormCompras.xaml
    /// </summary>
    public partial class rVentas : Window
    {

        // Variables Auxiliares
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
        List<Productos> lista = new List<Productos>();
        public List<VentasDetalles> Detalle { get; set; }
        List<Clientes> listaCliente = new List<Clientes>();
        List<Empleados> listaEmpleados = new List<Empleados>();

        public rVentas()
        {

            InitializeComponent();

            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;

            this.DataContext = venta;
            this.Detalle = new List<VentasDetalles>();
            CargarGrid();

            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            Porcentaje = 0;
            AplicaPorcentaje = 0;
            SubTotal = 0;
            Total = 0;
        }
        
        private bool ValidarProductosId(int id)
        {
            lista = ProductosBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in lista)
            {
                if (item.ProductoId == id)
                {
                    return paso = true;
                }
            }
            return paso;
        }
        private bool ValidarClienteId(int id)
        {
            listaCliente = ClientesBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in listaCliente)
            {
                if (item.ClienteId == id)
                {
                    return paso = true;
                }
            }

            return paso;
        }
        private bool ValidarEmpleadoId(int id)
        {
            listaEmpleados = EmpleadosBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in listaEmpleados)
            {
                if (item.EmpleadoId == id)
                {
                    return paso = true;
                }
            }

            return paso;
        }
        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
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

            Ventas venta = new Ventas();
            this.Detalle = new List<VentasDetalles>();
            CargarGrid();
            Actualizar();
        }

        private bool ExisteEnDB()
        {
            Ventas venta = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (venta != null);
        }

        private void CargarGrid()
        {
            VentaDetalleDataGrid.ItemsSource = null;
            VentaDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private Ventas LlenaClase()
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = int.Parse(VentaIdTextBox.Text);
            ventas.ClienteId = int.Parse(ClienteIdTextbox.Text);
            ventas.EmpleadoId = int.Parse(EmpleadoIdTextbox.Text);
            ventas.FechaEmision = (DateTime)FechaVentaDateTimePicker.SelectedDate;
            ventas.SubTotal = decimal.Parse(SubTotalTextBox.Text);
            ventas.ITBIS = double.Parse(ITBISTextBox.Text);
            ventas.Descuento = decimal.Parse(DescuentoTextBox.Text);
            ventas.Total = decimal.Parse(TotalTextBox.Text);
            ventas.Detalle = this.Detalle;

            return ventas;
        }

        private void LlenaCampo(Ventas venta)
        {
            VentaIdTextBox.Text = Convert.ToString(venta.VentaId);
            ClienteIdTextbox.Text = Convert.ToString(venta.ClienteId);
            EmpleadoIdTextbox.Text = Convert.ToString(venta.EmpleadoId);
            FechaVentaDateTimePicker.SelectedDate = venta.FechaEmision;
            ITBISTextBox.Text = Convert.ToString(venta.ITBIS);
            DescuentoTextBox.Text = Convert.ToString(venta.Descuento);

            SubTotal = venta.SubTotal;
            Total = venta.Total;
            SubTotalTextBox.Text = Convert.ToString(venta.SubTotal);
            TotalTextBox.Text = Convert.ToString(venta.Total);

            this.Detalle = venta.Detalle;
            CargarGrid();

        }


        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = venta;
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

            if (string.IsNullOrEmpty(FechaVentaDateTimePicker.Text))
            {
                paso = false;
                FechaVentaDateTimePicker.Focus();

            }


            if (string.IsNullOrEmpty(ClienteIdTextbox.Text))
            {
                paso = false;
                ClienteIdTextbox.Focus();

            }

            if (string.IsNullOrEmpty(EmpleadoIdTextbox.Text))
            {
                paso = false;
                EmpleadoIdTextbox.Focus();

            }
            if (string.IsNullOrEmpty(VentaIdTextBox.Text))
            {
                paso = false;
                VentaIdTextBox.Focus();
            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La venta debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentaDetalleDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<VentasDetalles>)VentaDetalleDataGrid.ItemsSource;
            }

            if (!ValidarProductosId(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                MessageBox.Show("Producto Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
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
            ProductosBLL.AumentarInventario(id, valor);

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

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Ventas venta;

            if (!ValidarClienteId(Convert.ToInt32(ClienteIdTextbox.Text)))
            {
                MessageBox.Show("Cliente Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!ValidarEmpleadoId(Convert.ToInt32(EmpleadoIdTextbox.Text)))
            {
                MessageBox.Show("Empleado Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Validar())
                return;

            venta = LlenaClase();

            if (string.IsNullOrEmpty(VentaIdTextBox.Text) || VentaIdTextBox.Text == "0")
                paso = VentasBLL.Guardar(venta);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("Persona No Encontrada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Ventas venta = new Ventas();
            int.TryParse(VentaIdTextBox.Text, out id);

            venta = VentasBLL.Buscar(id);

            if (venta != null)
            {
                LlenaCampo(venta);
            }
            else
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void ConsultarSuplidorButton_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores consultarSuplidor = new cSuplidores();
            consultarSuplidor.Show();
        }


        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SubTotalTextBox.Text = Convert.ToString(SubTotal);
                venta.SubTotal = SubTotal;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
                venta.Total = Total;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ConsultarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();
        }

        private void ConsultarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            cEmpleados cEmpleado = new cEmpleados();
            cEmpleado.Show();
        }

        private void ConsultarProductosButton_Click(object sender, RoutedEventArgs e)
        {
            cProductos cProducto = new cProductos();
            cProducto.Show();
        }
    }
}
