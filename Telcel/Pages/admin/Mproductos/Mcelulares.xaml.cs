using Entidades;
using Microsoft.Win32;
using Servicios;
using System;
using System.Collections.Generic;
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

namespace Vistas.Pages.admin.Mproductos { 

    public partial class Mcelulares : Page
    {
        Scelulares Scelulares= new Scelulares();
        private string rutaArchivoSeleccionado;
        public Mcelulares()
        {

            InitializeComponent();

            if (Scelulares.GetCelulares() != null && Scelulares.GetCelulares().Count > 0)
            {
                refresh();
            }

        }
        public void btnSelecionarClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                rutaArchivoSeleccionado = openFileDialog.FileName;
                txtNarchivo.Text = System.IO.Path.GetFileName(rutaArchivoSeleccionado);
            }
        }
        public void btnSubirClick(object sender, RoutedEventArgs e)
        {
            switch (btnSubir.Content)
            {
                case "Subir Celular":
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
                        celular c = new celular
                        {
                            nombre = txtNombre.Text,
                            cantidad = int.Parse(txtCantidad.Text),
                            descuento = 0,
                            Envio = true,
                            id = 23,
                            marca = new marca() { id = 1, nombre_marca = txtMarca.Text },
                            imagen = imagen,
                            precio = int.Parse(txtPrecio.Text),
                            almacenamiento = txtAlmacenamiento.Text,
                            camara = txtCamara.Text,
                            ram = txtRam.Text

                        };
                        Scelulares.add(c);
                        refresh();
                        MessageBox.Show("Guardado exitosamente");
                        }
                    break;
                case "Eliminar":
                    try
                    {
                        Scelulares.remove((celular)DGcelulares.SelectedItem);
                    }
                    catch
                    {

                    }
                    btnSubir.Content = "Subir Celular";
                    refresh();
                    break;
            }
        }
        private void btnVolverClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void refresh()
        {
            DGcelulares.ItemsSource = null;
            DGcelulares.ItemsSource = Scelulares.GetCelulares();
        }

        private void DGcelulares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           btnSubir.Content = "Eliminar";
        }
    }

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
