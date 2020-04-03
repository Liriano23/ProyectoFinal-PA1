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
using System.Text.RegularExpressions;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Interaction logic for FormUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;

            UsuarioIdTextBox.Text = "0";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;

            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");
            SexoComboBox.Items.Add("Otro");

            TipoUsuarioComboBox.Items.Add("Empleado");
            TipoUsuarioComboBox.Items.Add("Administrador");
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            CedulaTextBox.Clear();
            SexoComboBox.SelectedItem = "";
            TelefonoTextBox.Clear();
            CelularTextBox.Clear(); ;
            DireccionTextBox.Clear(); ;
            EmailTextBox.Clear(); ;
            TipoUsuarioComboBox.SelectedItem = "";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            NombreUsuarioTextBox.Clear();
            ContrasenaTextBox.Clear();

            Usuarios usuario = new Usuarios();
            Actualizar();
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
            return Regex.Match(telefono, @"^([\+]?1[-]?|[0])?[1-9][0-9]{9}$").Success;
        }
        public static bool CedulaValida(string cedula)
        {
            return Regex.Match(cedula, @"^([\+]?1[-]?|[0])?[1-9][0-9]{10}$").Success;
        }
        //private void Limpiar()
        //{
        //    UsuarioIdTextBox.Text = "0";
        //    NombresTextBox.Text = "N/A";
        //    ApellidosTextBox.Text = "N/A";
        //    CedulaTextBox.Text = "N/A";
        //    SexoComboBox.SelectedItem = "";
        //    TelefonoTextBox.Text = "N/A";
        //    CelularTextBox.Text = "N/A";
        //    DireccionTextBox.Text = "N/A";
        //    EmailTextBox.Text = "N/A";
        //    TipoUsuarioComboBox.SelectedItem = "";
        //    FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
        //    NombreUsuarioTextBox.Text = "N/A";
        //    ContrasenaTextBox.Text = "N/A";

        //    Usuarios usuario = new Usuarios();
        //    Actualizar();
        //}

        private void LlenaCampo(Usuarios usuario)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuario.UsuarioId);
            NombresTextBox.Text = usuario.Nombres;
            ApellidosTextBox.Text = usuario.Apellidos;
            CedulaTextBox.Text = usuario.Cedula;
            SexoComboBox.SelectedItem = usuario.Sexo;
            TelefonoTextBox.Text = usuario.Telefono;
            CelularTextBox.Text = usuario.Celular;
            DireccionTextBox.Text = usuario.Direccion;
            EmailTextBox.Text = usuario.Email;
            TipoUsuarioComboBox.SelectedItem = usuario.TipoUsuario;
            FechaIngresoDateTimePicker.SelectedDate = usuario.FechaIngreso;
            NombreUsuarioTextBox.Text = usuario.NombreUsuario;
            ContrasenaTextBox.Text = usuario.Contrasena;
        }

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

            if (!CedulaValida(CedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }


            if (SexoComboBox.SelectedItem == null)
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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
            try
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
            catch
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                Usuarios usuarios = new Usuarios();
                int.TryParse(UsuarioIdTextBox.Text, out id);

                Limpiar();

                usuarios = UsuariosBLL.Buscar(id);

                if (usuarios != null)
                {
                    LlenaCampo(usuarios);
                }
                else
                {
                    MessageBox.Show("No encontrado!!!", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error en base de datos, intente de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
