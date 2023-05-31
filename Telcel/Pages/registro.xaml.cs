using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Vistas.Pages.admin;

namespace Vistas.Pages
{
    public partial class registro : Page
    {
        Sclientes sclientes;
        public registro()
        {
            InitializeComponent();
            sclientes = new Sclientes();
        }
        public void click_image_init(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new init());
        }
        public void add_usuario(object sender, RoutedEventArgs e)
        {
           lbMessage.Visibility=Visibility.Visible;    
           lbMessage.Content=sclientes.add(validaciones());
        }
        public void returnpage(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }
        public persona validaciones()
        {
            bool val=true;
            persona p = new persona();
            try
            {
                p.cedula = int.Parse(txtCedula.Text);
            }
            catch 
            {
                lbCedula.Content = lbCedula.Content + "*";
                lbCedula.Foreground= new SolidColorBrush(Colors.Red);
                val = false;
            }
            if (txtNombre.Text.Length <= 0 || txtNombre.Text.Length > 50 || !txtEmail.Text.All(char.IsLetter))
            {
                lbNombre.Content = lbNombre.Content + "*";
                lbNombre.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
            p.nombre = txtNombre.Text;
            if (password.Password.Length <= 0 )
            {
                lbContrasena.Content = lbContrasena.Content + "*";
                lbContrasena.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
                p.contrasena = password.Password;

            if (txtDirecion.Text.Length <= 0 || txtDirecion.Text.Length > 100)
            {
                lbDirrecion.Content = lbDirrecion.Content + "*";
                lbDirrecion.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else
            p.dirrecion = txtDirecion.Text;
            if (txtEmail.Text.IndexOf("@")<=0 ||!txtEmail.Text.Contains("@")|| txtEmail.Text.Length < 0 || txtEmail.Text.Length > 100)
            {
                lbEmail.Content = lbEmail.Content + "*";
                lbEmail.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }
            else 
            p.email = txtEmail.Text;
            p.rol = new rol() { id = 2 };
            if(txtTelefono.Text.Length<10 || !txtTelefono.Text.All(char.IsDigit) || !txtTelefono.Text.StartsWith("3"))
            {
                lbTelefono.Content = lbTelefono.Content + "*";
                lbTelefono.Foreground = new SolidColorBrush(Colors.Red);
                val = false;
            }else
            p.telefono = txtTelefono.Text;

            if(val)
            return p;
            return null;
        }
      
   
    }
}
