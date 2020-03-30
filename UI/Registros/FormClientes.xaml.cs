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
    /// Interaction logic for FormClientes.xaml
    /// </summary>
    public partial class FormClientes : Window
    {
        Clientes cliente = new Clientes();
        public FormClientes()
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
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            SexoComboBox.SelectedItem = "";
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.SelectedDate = DateTime.Now;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = "0";

            Clientes cliente = new Clientes();
            Actualizar();
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
                NombresTextBox.Focus();

            }

            if (string.IsNullOrEmpty(CedulaTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                CedulaTextBox.Focus();
            }

            if(SexoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe completar el campo sexo", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
            }
            if (string.IsNullOrEmpty(TelefonoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Telefono no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(CelularTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Celular no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                CelularTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo email no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(ClienteIdTextBox.Text) || ClienteIdTextBox.Text == "0")
                paso = ClientesBLL.Guardar(cliente);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("No existe el cliente en la base de " +
                        "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
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
    }
}
