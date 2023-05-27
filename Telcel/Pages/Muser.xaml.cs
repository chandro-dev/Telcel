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

namespace Vistas.Pages
{
    public partial class Muser : Page
    {
        Sfacturas servicio_facturas = new Sfacturas();
        public Muser(persona p)
        {
            if (p == null)
            {
                NavigationService.GoBack();
                }
            else
            {
                InitializeComponent();
                    lst_compras.ItemsSource = servicio_facturas.GetHisto(p).ToList();
                
            }
        }

        public void btnvolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
