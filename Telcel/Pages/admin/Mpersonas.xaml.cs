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
    /// Lógica de interacción para Mpersonas.xaml
    /// </summary>
    public partial class Mpersonas : Page
    {
        Sclientes Scliente;
        public Mpersonas()
        {
            Scliente=new Sclientes();
            InitializeComponent();
            
            get_personas();
        }
        private void get_personas()
        {
            DGpersonas.ItemsSource = Scliente.GetClientes();
        }
    }
}
