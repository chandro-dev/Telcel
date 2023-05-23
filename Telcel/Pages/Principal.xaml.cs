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
        Sproducto sproducto;
       persona sesion;
        public Principal(persona p)
        {
            sproducto = new Sproducto();
            InitializeComponent();
            if (p != null)
            {
                sesion = p;
                _sesion();

            }
            else
            {
                lbUser.Visibility = Visibility.Hidden;
                lbFsesion.Visibility = Visibility.Hidden;
            }
            lbxProductos.ItemsSource = sproducto.GetProductos();
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
            lbUser.Visibility = Visibility.Visible;
            lbFsesion.Visibility = Visibility.Visible;
            lbUser.Content = sesion.nombre;
            lbRegistrarse.Visibility = Visibility.Hidden;
            lbISesion.Visibility = Visibility.Hidden;
        }

        private void lbUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Muser(sesion));
        }
        private void lbUser_FinalDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Principal(null));
        }

        private void lbxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sesion != null)
            {
                NavigationService.Navigate(new Facturacion(sesion, (producto)lbxProductos.SelectedItem));
            }
            
        }
    }



    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] data = value as byte[];
            if (data == null)
                return null;
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
