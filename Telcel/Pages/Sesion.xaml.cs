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
#pragma warning disable CS8981 // El nombre de tipo solo contiene caracteres ASCII en minúsculas. Estos nombres pueden reservarse para el idioma.
public partial class page : Page
#pragma warning restore CS8981 // El nombre de tipo solo contiene caracteres ASCII en minúsculas. Estos nombres pueden reservarse para el idioma.

    {
        Ssesiones sesiones;
        public page()
        {
            sesiones = new Ssesiones(); 
            InitializeComponent();
        }
        public void clickImagen(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            persona p = null;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
            NavigationService.Navigate(new init());

        }
        public void initSesion(object sender, RoutedEventArgs e) {
            persona usuario = sesiones.validation(Contrasena.Password, txtUsuario.Text);
            if (usuario != null)
            {
                if (usuario.rol.id == 1)
                {
                    NavigationService.Navigate(new MenuAdmin(usuario));
                }
                else
                {
                    NavigationService.Navigate(new Principal(usuario));
                }
            }
            else
            {
                lbMessage.Visibility= Visibility.Visible;
               lbMessage.Content="Usuario incorrecto";
            }
        }
        public void clickRegistrarse(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new registro());

        }
            public void Key_downPassword(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) {
                persona usuario = sesiones.validation(Contrasena.Password, txtUsuario.Text);
                if (usuario != null)
                {
                    if (usuario.rol.id == 1)
                    {
                        NavigationService.Navigate(new MenuAdmin(usuario));
                    }
                    else
                    {
                        NavigationService.Navigate(new Principal(usuario));
                    }
                }
                else
                {
                    lbMessage.Visibility = Visibility.Visible;
                    lbMessage.Content = "Usuario incorrecto";
                }
            }
        }
    }
}
