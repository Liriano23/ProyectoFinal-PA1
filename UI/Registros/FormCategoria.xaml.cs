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
    /// Lógica de interacción para FormCategoria.xaml
    /// </summary>
    public partial class FormCategoria : Window
    {
        Categorias categoria = new Categorias();
        public FormCategoria()
        {
            InitializeComponent();
            this.DataContext = categoria;
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());
            CategoriaIdTextBox.Text = "0";

        }

        private bool ExisteEnDB()
        {
            Categorias categoria = CategoriasBLL.Buscar(Convert.ToInt32(CategoriaIdTextBox.Text));
            return (categoria != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = categoria;
        }

        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            NombreCategoriaTextBox.Clear();
            UsuarioIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString());

            Categorias categoria = new Categorias();
            Actualizar();
        }


        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombreCategoriaTextBox.Text))
            {
                paso = false;
                NombreCategoriaTextBox.Focus();

            }
            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Categorias categorias = CategoriasBLL.Buscar(Convert.ToInt32(CategoriaIdTextBox.Text));

            if (categorias != null)
            {
                categoria = categorias;
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

                if (String.IsNullOrEmpty(CategoriaIdTextBox.Text) || CategoriaIdTextBox.Text == "0")
                    paso = CategoriasBLL.Guardar(categoria);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el Empleado en la base de " +
                            "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = CategoriasBLL.Modificar(categoria);
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
            int.TryParse(CategoriaIdTextBox.Text, out id);

            try
            {
                if (CategoriasBLL.Eliminar(id))
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
