using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Vistas.Pages
{
    /// <summary>
    /// Lógica de interacción para init.xaml
    /// </summary>
    public partial class init : Page
    {
        List<banner> bannerList=new List<banner>() { 

            new banner()
            {
                lb_content="¡Los mejores descuentos!",
                img_source="E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\bannerDescuentos.png",
                border_bg= new SolidColorBrush(Colors.Gold)

            },

            new banner(){
            lb_content="Grandes marcas",
            img_source="E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\bannerMarcas.png",
            border_bg= new SolidColorBrush(Colors.Gray)

            },            new banner(){
            lb_content="¡Los mejores precios!",
            img_source="E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\mainImage.png",
            border_bg= new SolidColorBrush(Color.FromRgb(128,122,238))

            }
        };
        int cont = 0;

        public init()
        {
            InitializeComponent();
            Timer timer = new Timer(change_banner, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        }
        public void btnRegistrar(object sender,RoutedEventArgs e)
        {
            NavigationService.Navigate(new registro());
        }
        public void btnIniciarS(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page());
        }
        public void Cat_Computadores(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal("Computadores"));
        }
        public void Cat_Asesorios(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal("Asesorios"));
        }
        public void change_image_btnR(object sender, RoutedEventArgs e)
        {
          
                if (cont > 2 || cont < 0)
                {
                    cont = 0;
                }
                lbBanner.Content = bannerList[cont].lb_content;
                myImage.Source = new BitmapImage(new Uri(bannerList[cont].img_source, UriKind.RelativeOrAbsolute));
                bBanner.Background = bannerList[cont].border_bg;
                cont++;
        }
        private void change_banner(object state)
           {
            while (true)
            {
                // Método que se llamará cada 5 segundos
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {

                    if (cont > 2 || cont < 0)
                    {
                        cont = 0;
                    }
                    lbBanner.Content = bannerList[cont].lb_content;
                    myImage.Source = new BitmapImage(new Uri(bannerList[cont].img_source, UriKind.RelativeOrAbsolute));
                    bBanner.Background = bannerList[cont].border_bg;
                    cont++;
                }), DispatcherPriority.Normal);

                // Pausar el bucle durante 5 segundos
                Thread.Sleep(TimeSpan.FromSeconds(6));
            }

        }
        public void change_image_btnL(object sender, RoutedEventArgs e)
        {
            if (cont < 0 || cont>2)
            {
                cont = 2;
            }
            lbBanner.Content = bannerList[cont].lb_content;
            myImage.Source = new BitmapImage(new Uri(bannerList[cont].img_source, UriKind.RelativeOrAbsolute));
            bBanner.Background = bannerList[cont].border_bg;
            cont--;
        }
        public void Cat_Celulares(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal("Celulares"));
        }
    }
    public class banner
    {
        public string lb_content { get; set; }

        public string img_source { get; set; }
        public Brush border_bg
        {
            get;set;
        }
    }
}
