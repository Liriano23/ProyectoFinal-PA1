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
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            CedulaTextBox.Clear();
            DireccionTextBox.Clear();
            TelefonoTextBox.Clear();
            CelularTextBox.Clear();
            EmailTextBox.Clear();
            CargoTextBox.Clear();
            SueldoTextBox.Text = "0";
            FechaNacimientoDateTimePicker.SelectedDate = DateTime.Now;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());

            Empleados empleado = new Empleados();
            Actualizar();
        }
        private void LlenaCampo(Empleados empleados)
        {
            EmpleadoIdTextBox.Text = Convert.ToString(empleados.EmpleadoId);
            NombresTextBox.Text = empleados.Nombres;
            ApellidosTextBox.Text = empleados.Apellidos;
            CedulaTextBox.Text = empleados.Cedula;
            DireccionTextBox.Text = empleados.Direccion;
            TelefonoTextBox.Text = empleados.Telefono;
            CelularTextBox.Text = empleados.Celular;
            EmailTextBox.Text = empleados.Email;
            CargoTextBox.Text = empleados.Cargo;
            SueldoTextBox.Text = Convert.ToString(empleados.Sueldo);
            FechaNacimientoDateTimePicker.SelectedDate = empleados.FechaNacimiento;
            FechaIngresoDateTimePicker.SelectedDate = empleados.FechaIngreso;
            UsuarioIdTextBox.Text = Convert.ToString(empleados.UsuariosId);
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
            try
            {
                int id;
                Empleados empleados = new Empleados();
                int.TryParse(EmpleadoIdTextBox.Text, out id);

                Limpiar();
                empleados = EmpleadosBLL.Buscar(id);

                if (empleados != null)
                {
                    LlenaCampo(empleados);
                }
                else
                {
                    MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en base de datos intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            try
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
            catch
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
