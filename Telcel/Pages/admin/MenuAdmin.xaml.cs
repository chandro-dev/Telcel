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

namespace Vistas.Pages.admin
{
    public partial class MenuAdmin : Page
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }
        public void btnAsesorios(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Masesorios());
        }
        public void btnCelulares(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Mcelulares());

        }
        public void btnComputadores(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Mcomputadores());

        }
        public void btnSesion(Object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public void btnPersonas(Object sender ,RoutedEventArgs e)
        {
            NavigationService.Navigate( new Mpersonas());
        }
    }
}
