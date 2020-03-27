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
    /// Interaction logic for FormVentas.xaml
    /// </summary>
    public partial class FormVentas : Window
    {
        Ventas venta = new Ventas();
        public List<VentasDetalles> Detalle { get; set; }

        public FormVentas()
        {
            InitializeComponent();


            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            ProductoIdTexBox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            ITBISTextBox.Text = "0.18";


            this.DataContext = venta;
            this.Detalle = new List<VentasDetalles>();
        }

        private void Limpiar()
        {

            VentaIdTextBox.Text = "0";
            ClienteIdTextbox.Text = "0";
            ProductoIdTexBox.Text = "0";
            EmpleadoIdTextbox.Text = "0";
            ITBISTextBox.Text = "0.18";
            SubTotalTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;

            this.Detalle = new List<VentasDetalles>();
            Ventas venta = new Ventas();
            Actualizar();
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

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(VentaIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Venta Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                VentaIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ClienteIdTextbox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Cliente Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ClienteIdTextbox.Focus();

            }

            if (string.IsNullOrEmpty(EmpleadoIdTextbox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Empleado Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                EmpleadoIdTextbox.Focus();
            }

            if (SubTotalTextBox.Text == "0" || string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                MessageBox.Show("Debe completar el capo SubTotal", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SubTotalTextBox.Focus();
            }
           
            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Descuento no puede estar vacio o debe ser 0", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DescuentoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ProductoIdTexBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Producto Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductoIdTexBox.Focus();
            }

            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Precio no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                PrecioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(FechaVentaDateTimePicker.Text))
            {
                paso = false;
                MessageBox.Show("El campo Fecha Venta no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                FechaVentaDateTimePicker.Focus();
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

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventas = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));

            if (ventas != null)
            {
                venta = ventas;
                Actualizar();
            }
            else
            {
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
