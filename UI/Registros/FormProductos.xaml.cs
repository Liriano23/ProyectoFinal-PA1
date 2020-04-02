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
    /// Interaction logic for FormProductos.xaml
    /// </summary>
    public partial class FormProductos : Window
    {
        Productos producto = new Productos();
        public FormProductos()
        {
            InitializeComponent();
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());
            ProductoIdTextBox.Text = "0";
            this.DataContext = producto;
        }
        private void Limpiar()
        {

            ProductoIdTextBox.Text = "N/A";
            NombreProductoTextBox.Text = "N/A";
            MarcaProductoTextBox.Text = "N/A";
            InventarioTextBox.Text = "N/A";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            SuplidorIdTextBox.Text = "0";
            CategoriaIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());

            Productos producto = new Productos();
            Actualizar();
        }

        private bool ExisteEnDB()
        {
            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (producto != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = producto;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombreProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreProductoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(MarcaProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo marca producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                MarcaProductoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(InventarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Inventario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                InventarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(FechaIngresoDateTimePicker.Text))
            {
                MessageBox.Show("Debe ingresar la fecha de ingreso", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                FechaIngresoDateTimePicker.Focus();
            }
            if (string.IsNullOrEmpty(SuplidorIdTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Suplidpr Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SuplidorIdTextBox.Focus();
            }

            if (string.IsNullOrEmpty(CategoriaIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Categoria Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                CategoriaIdTextBox.Focus();
            }

            if (string.IsNullOrEmpty(UsuarioIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Usuario Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                UsuarioIdTextBox.Focus();
            }

            return paso;
        }



        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                bool paso = false;

                if (!Validar())
                    return;

                if (String.IsNullOrEmpty(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                    paso = ProductosBLL.Guardar(producto);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el cliente en la base de " +
                            "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = ProductosBLL.Modificar(producto);
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
            catch
            {
                MessageBox.Show(" Usuario Id no valido!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos productos = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));


            if (producto != null)
            {
                producto = productos;
                Actualizar();
            }
            else
            {
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void EliminarButton_Click_1(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            try
            {
                if (ProductosBLL.Eliminar(id))
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

        private void ConsultarSuplidorButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarSuplidor consultarSuplidor = new ConsultarSuplidor();
            consultarSuplidor.Show();
        }

        private void ConsultarCategoriaeButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarCategoria consultarCategoria = new ConsultarCategoria();
            consultarCategoria.Show();
        }

      
    }
}
