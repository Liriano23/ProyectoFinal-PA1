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
    /// Lógica de interacción para FormEmpleados.xaml
    /// </summary>
    public partial class FormEmpleados : Window
    {
        Empleados empleado = new Empleados();
        public FormEmpleados()
        {
            InitializeComponent();
            this.DataContext = empleado;
            EmpleadoIdTextBox.Text = "0";
        }
        private bool ExisteEnDB()
        {
            Empleados empleado = EmpleadosBLL.Buscar(Convert.ToInt32(EmpleadoIdTextBox.Text));
            return (empleado != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = empleado;
        }

        private void Limpiar()
        {
            EmpleadoIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            CargoTextBox.Text = string.Empty;
            SueldoTextBox.Text = "0";
            FechaNacimientoDateTimePicker.SelectedDate = DateTime.Now;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = "0";

            Empleados empleados= new Empleados();
            Actualizar();
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(FechaIngresoDateTimePicker.Text))
            {
                paso = false;
                FechaIngresoDateTimePicker.Focus();
            }

            if (string.IsNullOrEmpty(FechaNacimientoDateTimePicker.Text))
            {
                paso = false;
                FechaNacimientoDateTimePicker.Focus();
            }

            if (string.IsNullOrEmpty(SueldoTextBox.Text))
            {
                paso = false;
                SueldoTextBox.Focus();
            }


            if (string.IsNullOrEmpty(CargoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                CargoTextBox.Focus();
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

            if (string.IsNullOrEmpty(CedulaTextBox.Text.Replace("-", "")))
            {
                paso = false;
                CedulaTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                ApellidosTextBox.Focus();

            }

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                paso = false;
                NombresTextBox.Focus();

            }
            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Empleados empleados = EmpleadosBLL.Buscar(Convert.ToInt32(EmpleadoIdTextBox.Text));

            if (empleados != null)
            {
                empleado = empleados;
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

            if (String.IsNullOrEmpty(EmpleadoIdTextBox.Text) || EmpleadoIdTextBox.Text == "0")
                paso = EmpleadosBLL.Guardar(empleado);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("No existe el Empleado en la base de " +
                        "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = EmpleadosBLL.Modificar(empleado);
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
            int.TryParse(EmpleadoIdTextBox.Text, out id);

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
