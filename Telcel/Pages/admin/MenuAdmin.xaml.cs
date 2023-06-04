using Entidades;
using iTextSharp.tool.xml.html.head;
using LiveCharts;
using LiveCharts.Wpf;
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
        persona _admin;
        public MenuAdmin(persona admin)
        {
            _admin = admin;
            InitializeComponent();
            lbAdmin.Content = lbAdmin.Content + _admin.nombre;

        }
        private void btnAsesorios(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Masesorios());
        }
        private void btnCelulares(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Mcelulares());

        }
        private void btnComputadores(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mproductos.Mcomputadores());

        }
        private void btnSesion(Object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnPersonas(Object sender ,RoutedEventArgs e)
        {
            NavigationService.Navigate( new Mpersonas());
        }
   
    }
}
