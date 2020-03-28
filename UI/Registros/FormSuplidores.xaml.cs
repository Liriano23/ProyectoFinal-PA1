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
using ProyectoFinal_PA1.DAL;
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para FormSuplidores.xaml
    /// </summary>
    public partial class FormSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        public FormSuplidores()
        {
            InitializeComponent();
            this.DataContext = suplidor;
            SuplidorIdTextBox.Text = "0";
        }
        private bool ExisteEnDB()
        {
            Suplidores suplidor = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));
            return (suplidor != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
        }

        private void Limpiar()
        {
            SuplidorIdTextBox.Text = "0";
            NombreSuplidorTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            NombreCompaniaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            CiudadTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = "0";

            Usuarios usuario = new Usuarios();
            Actualizar();
        }

        private bool Validar()
        {
            bool paso = true;

            

            if (string.IsNullOrEmpty(CiudadTextBox.Text.Replace("-", "")))
            {
                paso = false;
                CiudadTextBox.Focus();
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                paso = false;
                EmailTextBox.Focus();
            }

            if (string.IsNullOrEmpty(CelularTextBox.Text.Replace("-", "")))
            {
                paso = false;
                CelularTextBox.Focus();
            }

            if (string.IsNullOrEmpty(TelefonoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                DireccionTextBox.Focus();
            }

            if (string.IsNullOrEmpty(NombreCompaniaTextBox.Text.Replace("-", "")))
            {
                paso = false;
                NombreCompaniaTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                ApellidosTextBox.Focus();

            }

            if (string.IsNullOrEmpty(NombreSuplidorTextBox.Text))
            {
                paso = false;
                NombreSuplidorTextBox.Focus();

            }
            return paso;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Suplidores suplidores = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));

            if (suplidores != null)
            {
                suplidor = suplidores;
                Actualizar();
            }
            else
            {
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
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

            if (String.IsNullOrEmpty(SuplidorIdTextBox.Text) || SuplidorIdTextBox.Text == "0")
                paso = SuplidoresBLL.Guardar(suplidor);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("No existe el Empleado en la base de " +
                        "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = SuplidoresBLL.Modificar(suplidor);
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(SuplidorIdTextBox.Text, out id);

            if (EmpleadosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
