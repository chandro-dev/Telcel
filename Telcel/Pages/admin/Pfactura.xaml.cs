using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Diagnostics;

namespace Vistas.Pages.admin
{
  
    public partial class factura : Page
    {
        Entidades.factura _factura;
        Sfacturas sfacturas=new Sfacturas();    
        public factura(Entidades.factura factura)
        {
            _factura = sfacturas.GetProducts(factura);
            InitializeComponent();
            _listaCompras.ItemsSource = _factura.productos;
            lbCedula.Content = _factura.cliente.cedula;
            lbDirrecion.Content=_factura.cliente.dirrecion;
            lbFpago.Content = _factura.tipo_pago;
            lbTelefono.Content = _factura.cliente.telefono;
            lbNombre.Content = _factura.cliente.nombre;
            lb_total.Content = _factura.productos.Sum<producto>(x => x.precio).ToString("C0");

        }
        private void btnvolver(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }
        private void SaveAsPdfButton_Click(object sender, RoutedEventArgs e)
        {
            btnPdf.Visibility=Visibility.Collapsed;
            Document document = new Document(new iTextSharp.text.Rectangle(2860,1720));
            string path = @"E:\C_Sharp\Proyecto_Programacion_Final\New folder\Telcel\recursos\Factura.pdf";
            // Crear un escritor PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Definir la resolución deseada (por ejemplo, 300 DPI)
            float dpiX = 200;
            float dpiY = 200;

            // Calcular el ancho y alto en píxeles según la resolución
            int widthInPixels = (int)(ActualWidth * dpiX / 96);
            int heightInPixels = (int)(ActualHeight * dpiY / 96);

            // Tomar una captura de pantalla con la resolución especificada
            RenderTargetBitmap screenshot = new RenderTargetBitmap(widthInPixels, heightInPixels, dpiX, dpiY, PixelFormats.Pbgra32);
            screenshot.Render(this);

            // Convertir la captura de pantalla en una imagen de iTextSharp
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(screenshot));
            MemoryStream ms = new MemoryStream();
            encoder.Save(ms);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(ms.GetBuffer());

            // Añadir la imagen al documento PDF
            document.Open();
            document.Add(image);
            document.Close();
            btnPdf.Visibility=Visibility.Visible;
            
        }



    }
}
