using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Globalization;
using System.IO;
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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        Scelulares Scelulares;
        persona sesion;
        public Principal(persona p)
        {
            InitializeComponent();
            if(p != null)
            {
                sesion = p;
                _sesion();
            }
            Scelulares= new Scelulares();
            lbxProductos.ItemsSource = Scelulares.GetCelulares();
        }
       
        public void btnRegistrar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new registro());
        }
        public void btnIniciarS(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.page());
        }
    

        //Metodo correspondiente a la gestion de los inicios de sesion.
         public void _sesion()
        {
            lbUser.Content = sesion.nombre; lbUser.Visibility=Visibility.Visible;
        }

        private void lbUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }



    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            byte[] data = value as byte[];
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            if (data == null)
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                return null;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo

            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(data))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
