using Entidades;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Servicios;
namespace Vistas.Pages.admin.Mproductos
{
    /// <summary>
    /// Lógica de interacción para Masesorios.xaml
    /// </summary>
    public partial class Masesorios : Page
    {
        private string rutaArchivoSeleccionado;
        Sasesorios Sasesorios;
        public Masesorios()
        {
            InitializeComponent();
            Sasesorios = new Sasesorios();
            if (Sasesorios.GetAsesorios().Count > 0)
            {
                DGasesorios.ItemsSource = Sasesorios.GetAsesorios();
            }

        }
        public void btnSelecionar(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog(); openFileDialog.Filter = "Archivos PNG (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                rutaArchivoSeleccionado = openFileDialog.FileName;
                txtNarchivo.Text = System.IO.Path.GetFileName(rutaArchivoSeleccionado);
            }
        }
        public void btnSubir(object sender, RoutedEventArgs e)
        {

            byte[] imagen;
            if (rutaArchivoSeleccionado != null)
            {
                using (var fileStream = new FileStream(rutaArchivoSeleccionado, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        imagen = ms.ToArray();
                    }

                }
                asesorio a = new asesorio
                {
                    nombre = txtNombre.Text,
                    referencia = "23",
                    cantidad = int.Parse(txtCantidad.Text),
                    descuento = 0,
                    Envio = true,
                    id = 23,
                    marca = new marca() { id = 1, nombre_marca = txtMarca.Text },
                    imagen = imagen,
                    precio = int.Parse(txtPrecio.Text)
                };
                Sasesorios.add(a);
                refresh();
            }
        }
        public void btnVolver(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void refresh()
        {
            DGasesorios.ItemsSource = null;
            DGasesorios.ItemsSource = Sasesorios.GetAsesorios();
        }
        
    }
}
