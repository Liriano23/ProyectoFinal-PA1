﻿using System;
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
using ProyectoFinal_PA1.Entidades;

namespace ProyectoFinal_PA1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para FormSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        public rSuplidores()
        {
            InitializeComponent();
            this.DataContext = suplidor;
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());
            SuplidorIdTextBox.Text = "0";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
        }
        private bool ExisteEnDB()
        {
            Suplidores suplidores = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));
            return (suplidores != null);
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

        private void LlenaCampo(Suplidores suplidores)
        {
            SuplidorIdTextBox.Text = Convert.ToString(suplidores.SuplidorId);
            NombreSuplidorTextBox.Text = suplidores.NombreSuplidor;
            ApellidosTextBox.Text = suplidores.Apellidos;
            NombreCompaniaTextBox.Text = suplidores.NombreCompania;
            DireccionTextBox.Text = suplidores.Direccion;
            TelefonoTextBox.Text = suplidores.Telefono;
            CelularTextBox.Text = suplidores.Celular;
            EmailTextBox.Text = suplidores.Email;
            CiudadTextBox.Text = suplidores.Ciudad;
            FechaIngresoDateTimePicker.SelectedDate = suplidores.FechaIngreso;
            UsuarioIdTextBox.Text = Convert.ToString(suplidores.UsuariosId);
        }
        public static bool CedulaValida(string cedula)
        {
            return Regex.Match(cedula,
                @"^([\+]?1[-]?|[0])?[1-9][0-9]{10}$").Success;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
        }

        private void Limpiar()
        {
            SuplidorIdTextBox.Text = "0";
            NombreSuplidorTextBox.Clear();
            ApellidosTextBox.Clear();
            NombreCompaniaTextBox.Clear();
            DireccionTextBox.Clear();
            TelefonoTextBox.Clear();
            CelularTextBox.Clear();
            EmailTextBox.Clear();
            CiudadTextBox.Clear();
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());

            Suplidores suplidor = new Suplidores();
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

            if (string.IsNullOrEmpty(CiudadTextBox.Text))
            {
                paso = false;
                CiudadTextBox.Focus();
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
            try
            {
                int id;
                Suplidores supplier = new Suplidores();
                int.TryParse(SuplidorIdTextBox.Text, out id);
                Limpiar();
                supplier = SuplidoresBLL.Buscar(id);

                if (supplier != null)
                {
                    LlenaCampo(supplier);
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

                if (String.IsNullOrEmpty(SuplidorIdTextBox.Text) || SuplidorIdTextBox.Text == "0")
                    paso = SuplidoresBLL.Guardar(suplidor);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el Empleado en la base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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
                int.TryParse(SuplidorIdTextBox.Text, out id);

                if (SuplidoresBLL.Eliminar(id))
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
