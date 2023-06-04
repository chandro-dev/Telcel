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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private void ClickbtnCrear(object sender,RoutedEventArgs e) {

            if (validaciones())
            {
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
                    if (rbtnAdmin.IsChecked == true)
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
                            id = 2,
                            Rol = "cliente"
                        };
                    }

                    lbmessage.Content = Scliente.add(p);
                }
                catch
                {
                    lbmessage.Content= "No se creo exitosamente";
                }
                refresh();
            }
            else
            {
                lbmessage.Content = "No se creo exitosamente";
            }
        }

        private void btnDevolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }  
        private void clickBtnActualizar(object sender, RoutedEventArgs e) {
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
                if (rbtnAdmin.IsChecked == true)
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
                        id = 2,
                        Rol = "cliente"
                    };
                }

                lbmessage.Content = Scliente.update(p);

                refresh();
            }
            else
            {
                lbmessage.Content = "No se actualizo exitosamente";
            }
        }
        private void refresh()
        {
            DGpersonas.ItemsSource = null;
            DGpersonas.ItemsSource = Scliente.GetPersonas();
        }

        private void DGpersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DGpersonas.SelectedItem != null)
            {
                txtCedula.Text = ((persona)DGpersonas.SelectedItem).cedula.ToString();
                txtNombre.Text = ((persona)DGpersonas.SelectedItem).nombre;
                txtCedula.IsEnabled=false;
                Pcontrasena.Password = ((persona)DGpersonas.SelectedItem).contrasena;
                txtDirrecion.Text = ((persona)DGpersonas.SelectedItem).dirrecion;
                txtEmail.Text = ((persona)DGpersonas.SelectedItem).email;
                txtTelefono.Text = ((persona)DGpersonas.SelectedItem).telefono;
                rbtnAdmin.IsChecked = ((persona)DGpersonas.SelectedItem).rol.id == 1 ? true : false;
                btnActualizar.Visibility = Visibility.Visible;
                btnEliminar.Visibility = Visibility.Visible;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DGpersonas.SelectedItem != null)
            {
                lbmessage.Content= Scliente.remove((persona)DGpersonas.SelectedItem);
                refresh();
                btnActualizar.Visibility=Visibility.Collapsed;
                btnEliminar.Visibility=Visibility.Collapsed;
                txtCedula.IsEnabled = true;

            }
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

    }
}
