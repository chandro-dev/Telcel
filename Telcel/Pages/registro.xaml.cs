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
    /// <summary>
    /// Lógica de interacción para registro.xaml
    /// </summary>
    public partial class registro : Page
    {
        Sclientes registroSclientes= new Sclientes();
        public registro()
        {
            InitializeComponent();
        }
        public void btnProducto(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal());
        }
        public void addUsuario(object sender, RoutedEventArgs e)
        {
            if (registroSclientes.Add_Cliente(
                new Entidades.cliente()
                {
                    nombre = txtNombre.Text,
                    id = int.Parse(txtCedula.Text),
                    dirrecion = txtDirecion.Text,
                    email = txtEmail.Text,
                    contrasena = password.Password,
                    telefono = txtTelefono.Text
                }
                ))
            {
                MessageBox.Show("Guardado con exito");
            }; 
        }

    }
}
