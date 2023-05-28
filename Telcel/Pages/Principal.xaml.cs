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
        List<producto> productos;
        List<marca> marcas;
        public Principal(string cat)
        {
            sproducto = new Sproducto();
            InitializeComponent();
            productos = sproducto.GetProductos();
            marcas = sproducto.GetMarcas();
            lbxProductos.ItemsSource = productos;
            lstCategorias.ItemsSource = marcas;
            cmbCat.ItemsSource = new List<string>()
            {

                "Computadores",
                "Celulares",
                "Asesorios",
            "Todos"
            };
            lbUser.Visibility = Visibility.Hidden;
            lbFsesion.Visibility = Visibility.Hidden;
            cmbCat.SelectedItem = cat;
        }
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
            productos = sproducto.GetProductos();
            marcas = sproducto.GetMarcas();
            lbxProductos.ItemsSource = productos;
            lstCategorias.ItemsSource= marcas;
            cmbCat.ItemsSource = new List<string>()
            {

                "Computadores",
                "Celulares",
                "Asesorios",
                "Todos"
            };
        }

        public void Click_Init(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new init());
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
            persona p = null;
            NavigationService.Navigate(new init());
        }

        private void lbxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sesion != null)
            {
                NavigationService.Navigate(new Facturacion(sesion, (producto)lbxProductos.SelectedItem));
            }
            
        }

        private void cmbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lsxMarca = new List<marca>();
            lbxProductos.ItemsSource = sproducto.GetProductos(cmbCat.SelectedItem.ToString());
            lstCategorias.ItemsSource=null;
            foreach (producto p in lbxProductos.ItemsSource.Cast<producto>().ToList<producto>())
            {
                if( lsxMarca.Exists(x => x.id == p.marca.id))
                {
                }
                else
                {
                    lsxMarca.Add(p.marca);
                }

            };
            lstCategorias.ItemsSource = lsxMarca;

        }
    }


    /*
     * Pasar un Objeto byte array a una imagen
     * 
     */
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
