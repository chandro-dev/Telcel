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

namespace Vistas.Pages.admin
{

    public partial class Mpersonas : Page
    {
        Sclientes Scliente;
        public Mpersonas()
        {
            Scliente=new Sclientes();
            InitializeComponent();
            
            get_personas();
        }
        private void get_personas()
        {
            if(Scliente.GetPersonas().Count > 0)
            {
                refresh();
            }
        }
        private void btnCrear(object sender,RoutedEventArgs e) {
            try
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
                if (rbtnAdmin.IsChecked ==true)
                {
                    p.rol = new rol()
                    {
                        id = 1,
                        Rol = "admin"
                    };
                }
                else
                {
                    p.rol = new rol()
                    {
                        id = 1,
                        Rol = "cliente"
                    };
                }

                Scliente.add(p);
                MessageBox.Show("Creado exitosamente");
                refresh();
            }
            catch
            {

            }
        }

        private void btnDevolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }  
        private void refresh()
        {
            DGpersonas.ItemsSource = null;
            DGpersonas.ItemsSource = Scliente.GetPersonas();
        }
    }
}
