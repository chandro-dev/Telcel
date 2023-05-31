using Entidades;
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
using Vistas.Pages.admin;

namespace Vistas.Pages
{
  public partial class registro : Page
        {
        Sclientes sclientes;
        public registro()
        {
            InitializeComponent();
            sclientes =new Sclientes();
        }
        public void add_usuario(object sender,RoutedEventArgs e)
        {
                persona p = new persona()
                {
                    cedula = int.Parse(txtCedula.Text),
                    nombre = txtNombre.Text,
                    contrasena = password.Password,
                    dirrecion = txtDirecion.Text,
                    email = txtEmail.Text,
                    rol = new rol() { id = 2, Rol = "cliente" },
                    telefono = txtTelefono.Text

                };
            MessageBox.Show(sclientes.add(p));
        }
        public void returnpage(object sender,RoutedEventArgs e) {
            NavigationService.GoBack();
        }
    }
}
