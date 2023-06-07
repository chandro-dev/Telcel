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
using System;

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
            //Rellenar los objetos con la informacion necesaria 
            var fecha = DateTime.Today;
            lbFecha.Content = "Fecha de Factura: " + fecha.ToString("d");
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
            string path = @"C:\Users\alejandro\OneDrive\Desktop\Tlecel\New folder\Telcel\recursos\Factura.pdf";
            // Crear un escritor PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Definir la resolución deseada 
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
            try
            {
                Process.Start(path);
            }
            catch
            {
                MessageBox.Show("No se pudo abrir el pdf que se encuentra en la ruta: "+path );
            }
            btnPdf.Visibility=Visibility.Visible;

        }



    }
}
