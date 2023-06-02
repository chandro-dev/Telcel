using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
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
    /// Lógica de interacción para vista_producto.xaml
    /// </summary>
    public partial class vista_producto : Page
    {
        producto _producto;
        persona cliente;
        public vista_producto(producto producto,persona p)
        {
            _producto = producto;
            cliente = p;
            InitializeComponent();

            nombreProducto.Content = producto.nombre;
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(producto.imagen))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }
            imgProducto.Source = bitmapImage;
            lbNombre.Content = lbNombre.Content + _producto.nombre;
            lbMarca.Content = lbMarca.Content + _producto.marca.nombre_marca;
            lbPrecio.Content = lbPrecio.Content + _producto.precio.ToString("C");

        }
        private void clickImagen(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Add_carrito(object sender, RoutedEventArgs e)
        {
            if (cliente != null)
            {
                NavigationService.Navigate(new Facturacion(cliente, _producto));
            }
            else
            {
                btnRegistrarse.Visibility = Visibility.Visible;
                lbAdvertencia.Visibility = Visibility.Visible;
            }

        }
        private void clickRegistrarse(object sender, RoutedEventArgs e) {

            NavigationService.Navigate(new registro());
        }
    }
}
