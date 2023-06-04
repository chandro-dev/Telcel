using Entidades;
using iTextSharp.tool.xml.html.head;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace Vistas.Pages.admin
{
    public partial class MenuAdmin : Page
    {
        persona _admin;
        Sproducto s= new Sproducto();
        public MenuAdmin(persona admin)
        {
            _admin = admin;
            InitializeComponent();
            List<double> list = new List<double>();
            list = s.get_Esta();
            pedazoComputador.Values = new ChartValues<double> { list[0] };
            pedazoCelular.Values= new ChartValues<double> { list[1] };
            pedazoAseorio.Values = new ChartValues<double> { list[2] };
            Ventas_Totales.Values = new ChartValues<double> (s.get_Tot() );
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
