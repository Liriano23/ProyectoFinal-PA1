﻿using System;
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

namespace ProyectoFinal_PA1
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        List<Usuarios> lista = new List<Usuarios>();
        public static int UsuarioId;

        public LogIn()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();

            lista = UsuariosBLL.GetList(p => true);
            bool paso = false;
            foreach (var item in lista)
            {
                if ((item.NombreUsuario == NombreUsuarioTextBox.Text) && (item.Contrasena == ContrasenaTextBox.Text))
                {
                    UsuarioId = item.UsuarioId;
                    main.Show();
                    paso = true;
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Nombre de usuario o Contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreUsuarioTextBox.Text = string.Empty;
                ContrasenaTextBox.Text = string.Empty;
                NombreUsuarioTextBox.Focus();
            }
        }
    }
}
