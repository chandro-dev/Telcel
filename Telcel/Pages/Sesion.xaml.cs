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
#pragma warning disable CS8981 // El nombre de tipo solo contiene caracteres ASCII en minúsculas. Estos nombres pueden reservarse para el idioma.
public partial class page : Page
#pragma warning restore CS8981 // El nombre de tipo solo contiene caracteres ASCII en minúsculas. Estos nombres pueden reservarse para el idioma.

    {
        public page()
        {
            InitializeComponent();
        }
        public void clickImagen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal());
        }
        public void initSesion(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new admin.MenuAdmin()); 
        }

    }
}
