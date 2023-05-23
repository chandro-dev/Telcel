using Entidades;
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
        public Muser(persona p)
        {
            if (p == null)
            {
                NavigationService.GoBack();
            }
            else
            {
                InitializeComponent();
            }
        }

        public void btnvolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
