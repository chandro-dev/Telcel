using Entidades;
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
    /// <summary>
    /// Lógica de interacción para factura.xaml
    /// </summary>
    public partial class factura : Page
    {
        Entidades.factura _factura;
        Sfacturas sfacturas=new Sfacturas();    
        public factura(Entidades.factura factura)
        {
            _factura = sfacturas.GetProducts(factura);

            InitializeComponent();
            _listaCompras.ItemsSource = _factura.productos;
        }
        private void btnvolver(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }
    }
}
