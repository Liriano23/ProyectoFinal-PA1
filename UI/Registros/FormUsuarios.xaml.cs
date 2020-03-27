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
using ProyectoFinal_PA1.Entidades;
using ProyectoFinal_PA1.BLL;
namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Interaction logic for FormUsuarios.xaml
    /// </summary>
    public partial class FormUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public FormUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;
            UsuarioIdTextBox.Text = "0";

            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");
            SexoComboBox.Items.Add("Otro");

            TipoUsuarioComboBox.Items.Add("Empleado");
            TipoUsuarioComboBox.Items.Add("Administrador");
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            SexoComboBox.SelectedItem = "";
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TipoUsuarioComboBox.SelectedItem = "";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            NombreUsuarioTextBox.Text = string.Empty;
            ContrasenaTextBox.Text = string.Empty;

            Usuarios usuario = new Usuarios();
            Actualizar();
        }

        //private void LlenaCampo(Usuarios usuario)
        //{
        //    UsuarioIdTextBox.Text = Convert.ToString(usuario.UsuarioId);
        //    NombresTextBox.Text = usuario.Nombres;
        //    ApellidosTextBox.Text = usuario.Apellidos;
        //    CedulaTextBox.Text = usuario.Cedula;
        //    SexoComboBox.SelectedIndex = Convert.ToString(usuario.Sexo);
        //    TelefonoTextBox.Text = usuario.Telefono;
        //    CelularTextBox.Text = usuario.Celular;
        //    DireccionTextBox.Text = usuario.Direccion;
        //    EmailTextBox.Text = usuario.Email;
        //    FechaIngresoDateTimePicker.SelectedDate = usuario.FechaIngreso;
        //    NombreUsuarioTextBox.Text = usuario.NombreUsuario;
        //    ContrasenaTextBox.Text = usuario.Contrasena;
        //}

        private bool ExisteEnDB()
        {
            Usuarios usuario = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (usuario != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
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
            }

            if (string.IsNullOrEmpty(TelefonoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Telefono no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (string.IsNullOrEmpty(CelularTextBox.Text.Replace("-","")))
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

            if (string.IsNullOrEmpty(NombreUsuarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreUsuarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ContrasenaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo contraseña Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreUsuarioTextBox.Focus();
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

            if (String.IsNullOrEmpty(UsuarioIdTextBox.Text) || UsuarioIdTextBox.Text == "0")
                paso = UsuariosBLL.Guardar(usuario);
            else
            {
                if (!ExisteEnDB())
                {
                    MessageBox.Show("No existe el cliente en la base de " +
                        "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = UsuariosBLL.Modificar(usuario);
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
            int.TryParse(UsuarioIdTextBox.Text, out id);

            if (UsuariosBLL.Eliminar(id))
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
            Usuarios FindUser = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (FindUser != null)
            {
                usuario = FindUser;
                Actualizar();
            }
            else
            {
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
