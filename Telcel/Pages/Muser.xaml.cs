using Entidades;
using iTextSharp.xmp.impl;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.Pages
{
    public partial class Muser : Page
    {
        Sfacturas servicio_facturas = new Sfacturas();
        Sclientes Scliente = new Sclientes();
        public Muser(persona p)
        {
            if (p == null)
            {
                NavigationService.GoBack();
                }
            else
            {
                InitializeComponent();
                 lst_compras.ItemsSource = servicio_facturas.GetHisto(p).ToList();
                txtCedula.Text = p.cedula.ToString();
                txtNombre.Text = p.nombre;
                txtCedula.IsEnabled = false;
                Pcontrasena.Password = p.contrasena;
                txtDirrecion.Text = p.dirrecion;
                txtEmail.Text = p.email;
                txtTelefono.Text = p.telefono;
            }
        }

        private void btnvolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void ClickBtnActualizar(object sender,RoutedEventArgs e)
        {
            if (validaciones())
            {
                persona p = new persona()
                {
                    cedula = int.Parse(txtCedula.Text),
                    nombre = txtNombre.Text,
                    contrasena = Pcontrasena.Password,
                    dirrecion = txtDirrecion.Text,
                    email = txtEmail.Text,
                    telefono = txtTelefono.Text

                };
                    p.rol = new rol()
                    {
                        id = 2,
                        Rol = "cliente"
                    };

                lbmessage.Content = Scliente.update(p);

            }
            else
            {
                lbmessage.Content = "No se actualizo exitosamente";
            }
        }
        public void change_text(object sender,TextChangedEventArgs e)
        {
            btnActualizar.Visibility = Visibility.Visible;

        }
        public bool validaciones()
        {
            bool val = true;
            persona p = new persona();
            try
            {
                p.cedula = int.Parse(txtCedula.Text);
            }
            catch
            {
                lbCedula.Content = lbCedula.Content + "*";
                lbCedula.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            if (txtNombre.Text.Length <= 0 || txtNombre.Text.Length > 50)
            {
                lbNombre.Content = lbNombre.Content + "*";
                lbNombre.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.nombre = txtNombre.Text;
            if (Pcontrasena.Password.Length <= 0)
            {
                lbContrasena.Content = lbContrasena.Content + "*";
                lbContrasena.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.contrasena = Pcontrasena.Password;

            if (txtDirrecion.Text.Length <= 0 || txtDirrecion.Text.Length > 100)
            {
                lbDirrecion.Content = lbDirrecion.Content + "*";
                lbDirrecion.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.dirrecion = txtDirrecion.Text;
            if (txtEmail.Text.IndexOf("@") <= 0 || !txtEmail.Text.Contains("@") || txtEmail.Text.Length < 0 || txtEmail.Text.Length > 100)
            {
                lbEmail.Content = lbEmail.Content + "*";
                lbEmail.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.email = txtEmail.Text;
            p.rol = new rol() { id = 2 };
            if (txtTelefono.Text.Length < 10 || !txtTelefono.Text.All(char.IsDigit) || !txtTelefono.Text.StartsWith("3"))
            {
                lbTelefono.Content = lbTelefono.Content + "*";
                lbTelefono.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.telefono = txtTelefono.Text;
            return val;
        }

        private void lst_compras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lst_compras.SelectedItem != null)
            {
                NavigationService.Navigate(new Vistas.Pages.admin.factura ((factura)lst_compras.SelectedItem));
            }
        }
    }
}
