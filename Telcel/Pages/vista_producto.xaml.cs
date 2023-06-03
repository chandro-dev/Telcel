using Entidades;
using Org.BouncyCastle.Asn1.X509.Qualified;
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
            cliente = p;
            InitializeComponent();
            identificar_producto(producto);

            if (p !=null)
            lbNombre.Content = lbNombre.Content + cliente.nombre;


        }
        private void clickImagen(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void identificar_producto(producto p)
        {
            MessageBox.Show(p.GetType().ToString());
            switch (p.GetType().ToString())
            {
                case "Entidades.celular":
                    celular _p = (celular)p;
                    add_prodcuto(_p);
                    lbDescripcion.Visibility = Visibility.Visible;
                    lbCamara.Visibility = Visibility.Visible;
                    lbRam.Visibility = Visibility.Visible;
                    lbAlmacenamiento.Visibility = Visibility.Visible;

                    lbAlmacenamiento.Content = lbAlmacenamiento.Content + _p.almacenamiento.ToString();
                    lbCamara.Content = lbCamara.Content + _p.camara.ToString();
                    lbDescripcion.Content = lbDescripcion.Content + _p.descripcion.ToString();
                    lbRam.Content = lbRam.Content + _p.ram.ToString();
                    break;
                case "Entidades.computador":
                    computador c = (computador)p;
                    add_prodcuto(c);
                    lbAlmacenamiento.Visibility = Visibility.Visible;
                    lbDescripcion.Visibility = Visibility.Visible;
                    lbTarjetaMadre.Visibility = Visibility.Visible;
                    lbTarjetaVideo.Visibility = Visibility.Visible;
                    lbProcesador.Visibility = Visibility.Visible;
                    lbRam.Visibility = Visibility.Visible;
                    lbAlmacenamiento.Content = lbAlmacenamiento.Content + c.almacenamiento.ToString();
                    lbProcesador.Content = lbProcesador.Content + c.procesador.ToString();
                    lbTarjetaVideo.Content = lbTarjetaVideo.Content + c.tarjeta_video.ToString();
                    lbTarjetaMadre.Content = lbTarjetaMadre.Content + c.tarjeta_madre.ToString();
                    lbRam.Content = lbRam.Content + c.ram.ToString();
                    break;
                case "Entidades.asesorio":
                    asesorio a = (asesorio)p;
                    add_prodcuto(a);
                    lbReferencia.Visibility = Visibility.Visible;
                    lbReferencia.Content = lbReferencia.Content + a.referencia.ToString();
                    break;
                default:
                    add_prodcuto(p);
                    break;

            }
        }
        private void add_prodcuto(producto _p)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(_p.imagen))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }
            imgProducto.Source = bitmapImage;

            nombreProducto.Content = _p.nombre;
            lbNombre.Content = lbNombre.Content + _p.nombre.ToString();
            lbMarca.Content = lbMarca.Content + _p.marca.nombre_marca;
            lbPrecio.Content = lbPrecio.Content + _p.precio.ToString("C");
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
