using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());
            EmpleadoIdTextBox.Text = "0";
        }
        private bool ExisteEnDB()
        {
            Empleados empleado = EmpleadosBLL.Buscar(Convert.ToInt32(EmpleadoIdTextBox.Text));
            return (empleado != null);
        }
        private Boolean EmailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool NumeroValido(string telefono)
        {
            return Regex.Match(telefono,
                @"^([\+]?1[-]?|[0])?[1-9][0-9]{9}$").Success;
        }
        public static bool CedulaValida(string cedula)
        {
            return Regex.Match(cedula,
                @"^([\+]?1[-]?|[0])?[1-9][0-9]{10}$").Success;
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = empleado;
        }

        private void Limpiar()
        {
            EmpleadoIdTextBox.Text = "0";
            NombresTextBox.Text = "N/A";
            ApellidosTextBox.Text = "N/A";
            CedulaTextBox.Text = "N/A";
            DireccionTextBox.Text = "N/A";
            TelefonoTextBox.Text = "N/A";
            CelularTextBox.Text = "N/A";
            EmailTextBox.Text = "N/A";
            CargoTextBox.Text = "N/A";
            SueldoTextBox.Text = "0";
            FechaNacimientoDateTimePicker.SelectedDate = DateTime.Now;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());

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

            if (!EmailValido(EmailTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Email No Valido !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            if (!NumeroValido(CelularTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Celular No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
            }

            if (!NumeroValido(TelefonoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Teléfono No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                DireccionTextBox.Focus();
            }

            if (!CedulaValida(CedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            try
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
            catch
            {
                MessageBox.Show(" Usuario Id no valido!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EmpleadoIdTextBox.Text, out id);

            try
            {
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
            catch
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
    }
}
