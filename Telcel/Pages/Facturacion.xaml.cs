using Entidades;
using iText.Kernel.Pdf;
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

namespace Vistas.Pages
{
    /// <summary>
    /// Lógica de interacción para Facturacion.xaml
    /// </summary>
    public partial class Facturacion : Page
    {
        private static List<producto> carrito;
        private static persona _persona;
        private Sfacturas service;
        public Facturacion(persona p, producto _prod)
        {

            if (p == null)
            {
                NavigationService.GoBack();
            }
            else
            {
                service = new Sfacturas();

                if (_persona != p)
                {
                    _persona = p;
                    carrito = new List<producto>();
                }
                if (carrito == null)
                {
                    carrito = new List<producto>();
                }
                carrito.Add(_prod);
                InitializeComponent();
                lbCarrito.ItemsSource = carrito;
            }
        }

        private void btnanadir(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnpagar(object sender, RoutedEventArgs e)
        {
            factura _factura = new factura();
            _factura.fecha = DateTime.Today;
            _factura.fecha_entrega = DateTime.Today.AddDays(5);
            _factura.tipo_pago = "pasarela de pago";
            _factura.productos=new List<producto>();
            _factura.productos = carrito;
            _factura.cliente = _persona;
            MessageBox.Show( service.add(_factura));
            //var spago = new Spagos();
            //_pdfViewer.Navigate(spago.generar_factura(_persona, carrito));

            carrito = new List<producto>();
        }
        public void Btnreturn(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}
