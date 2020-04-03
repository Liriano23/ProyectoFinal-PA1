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
using System.Text.RegularExpressions;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Interaction logic for FormClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {

        Clientes cliente = new Clientes();
        public rClientes()
        {
            InitializeComponent();
            this.DataContext = cliente;

            ClienteIdTextBox.Text = "0";
            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");
            SexoComboBox.Items.Add("Otro");
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
        }
        private void Limpiar()
        {
            ClienteIdTextBox.Text = "0";
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            CedulaTextBox.Clear();
            SexoComboBox.SelectedItem = "";
            DireccionTextBox.Clear();
            TelefonoTextBox.Clear();
            CelularTextBox.Clear();
            EmailTextBox.Clear();
            FechaNacimientoDateTimePicker.SelectedDate = DateTime.Now;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = "0";

            Clientes cliente = new Clientes();
            Actualizar();
        }

        private Boolean EmailValido(String email) //Metodo que valida los Emails
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

        private void LlenaCampo(Clientes clientes)
        {
            ClienteIdTextBox.Text = Convert.ToString(clientes.ClienteId);
            NombresTextBox.Text = clientes.Nombres;
            ApellidosTextBox.Text = clientes.Apellidos;
            CedulaTextBox.Text = clientes.Cedula;
            SexoComboBox.SelectedItem = clientes.Sexo;
            DireccionTextBox.Text = clientes.Direccion;
            TelefonoTextBox.Text = clientes.Telefono;
            CelularTextBox.Text = clientes.Celular;
            EmailTextBox.Text = clientes.Email;
            FechaNacimientoDateTimePicker.SelectedDate = clientes.FechaNacimiento;
            FechaIngresoDateTimePicker.SelectedDate = clientes.FechaIngreso;
            UsuarioIdTextBox.Text = Convert.ToString(clientes.UsuariosId);
        }

        private bool ExisteEnDB()
        {
            Clientes cliente = ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));
            return (cliente != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = cliente;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ApellidosTextBox.Focus();

            }

            if (!CedulaValida(CedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }

            if (SexoComboBox.SelectedItem == null)
            {
                paso = false;
                MessageBox.Show("Debe completar el campo sexo", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
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
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
            }

            if (!EmailValido(EmailTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Email No Valido !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            if (string.IsNullOrEmpty(FechaIngresoDateTimePicker.Text))
            {
                paso = false;
                MessageBox.Show("El campo Fecha Ingreso no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                FechaIngresoDateTimePicker.Focus();
            }

            if (string.IsNullOrEmpty(FechaNacimientoDateTimePicker.Text))
            {
                paso = false;
                MessageBox.Show("El campo fecha nacimiento no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                FechaNacimientoDateTimePicker.Focus();
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

                if (String.IsNullOrEmpty(ClienteIdTextBox.Text) || ClienteIdTextBox.Text == "0")
                    paso = ClientesBLL.Guardar(cliente);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el cliente en la base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = ClientesBLL.Modificar(cliente);
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
                MessageBox.Show("Ingrese un usuarioId valido");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int id;
                int.TryParse(ClienteIdTextBox.Text, out id);
                if (ClientesBLL.Eliminar(id))
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
                MessageBox.Show(" Error en base de datos, Intentelo de nuevo", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                Clientes client = new Clientes();
                int.TryParse(ClienteIdTextBox.Text, out id);
                Limpiar();
                client = ClientesBLL.Buscar(id);

                if (client != null)
                {
                    LlenaCampo(client);
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
    }
}
