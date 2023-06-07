using Entidades;
using Microsoft.Win32;
using Repositorio;
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
        private Scelulares Scelulares= new Scelulares();
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
            var openFileDialog = new OpenFileDialog();openFileDialog.Filter= "Archivos PNG (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                rutaArchivoSeleccionado = openFileDialog.FileName;
                txtNarchivo.Text = System.IO.Path.GetFileName(rutaArchivoSeleccionado);
            }
        }
        public void btnSubirClick(object sender, RoutedEventArgs e)
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
                        celular c = new celular
                        {
                            
                            nombre = txtNombre.Text,
                            cantidad = int.Parse(txtCantidad.Text),
                            descuento = float.Parse(txtDescuento.Text)/100,
                            envio = (bool)rdEnvio.IsChecked.Value,
                            marca = new marca() { nombre_marca = txtMarca.Text },
                            imagen = imagen,
                            precio = int.Parse(txtPrecio.Text),
                            almacenamiento = txtAlmacenamiento.Text,
                            camara = txtCamara.Text,
                            ram = txtRam.Text,
                            descripcion=txtDescripcion.Text

                        };
                    
                        lbmessage.Content=(Scelulares.add(c));
                limpiar_campos();

                refresh();
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
    private void ClickBtnEliminar(object sender, RoutedEventArgs e)
    {

            lbmessage.Content= Scelulares.remove((celular)DGcelulares.SelectedItem);
            
            refresh();

            btnEliminar.Visibility = Visibility.Visible;
            _btnSubir.IsEnabled = true;
        }

        private void DGcelulares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGcelulares.SelectedItem != null)
            {
                try
                {
                    txtNombre.Text = ((celular)DGcelulares.SelectedItem).nombre;
                    txtCantidad.Text = ((celular)DGcelulares.SelectedItem).cantidad.ToString();
                    txtDescuento.Text = (((celular)DGcelulares.SelectedItem).descuento * 100).ToString();
                    rdEnvio.IsChecked = (bool)((celular)DGcelulares.SelectedItem).envio;
                    txtMarca.Text = ((celular)DGcelulares.SelectedItem).marca.nombre_marca;
                    txtPrecio.Text = ((celular)DGcelulares.SelectedItem).precio.ToString();
                    txtDescripcion.Text = ((celular)DGcelulares.SelectedItem).descripcion;
                    txtAlmacenamiento.Text = ((celular)DGcelulares.SelectedItem).almacenamiento;
                    txtCamara.Text = ((celular)DGcelulares.SelectedItem).camara;
                    txtRam.Text = ((celular)DGcelulares.SelectedItem).ram;

                }
                catch { }
                btnEliminar.Visibility = Visibility.Visible;
                btnActualizar.Visibility = Visibility.Visible;
                _btnSubir.IsEnabled = false;
            } }
        private bool validation()
        {
            bool stado = true;


            if (txtDescuento.Text.ToString() == string.Empty || !txtDescuento.Text.All(char.IsDigit))
            {
                lbDescuento.Content = lbDescuento.Content + "*";
                stado = false;
            }
            if (txtCantidad.Text.ToString() == string.Empty || !txtCantidad.Text.All(char.IsDigit))
            {
                lbCantidad.Content = lbCantidad.Content + "*";
                stado = false;
            }
            if (txtPrecio.Text.ToString() == string.Empty || !txtPrecio.Text.All(char.IsDigit))
            {
                lbPrecio.Content = lbPrecio.Content + "*";
                stado = false;
            }
            if (txtNombre.Text.Length <= 0)
            {
                lbNombre.Content = lbNombre.Content + "*";
                stado = false;
            }
            if (txtAlmacenamiento.Text.Length <= 0)
            {
                lbAlmacenamiento.Content = lbAlmacenamiento.Content + "*";
                stado = false;
            }
            if (txtDescripcion.Text.Length <= 0)
            {
                lbDescripcion.Content = lbDescripcion.Content + "*";
                stado = false;
            }
            if (txtRam.Text.Length <= 0)
            {
                lbRam.Content = lbRam.Content + "*";
                stado = false;
            }
            if (txtMarca.Text.Length <= 0)
            {
                lbMarca.Content = lbMarca.Content + "*";
                stado = false;
            }
            return stado;
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
            {
                if (DGcelulares.SelectedItem != null)
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
                            if (validation())
                            {
                                var _id = (celular)DGcelulares.SelectedItem;
                                celular c = new celular
                                {

                                    id = _id.id,
                                    nombre = txtNombre.Text,
                                    descripcion = txtDescripcion.Text,
                                    cantidad = int.Parse(txtCantidad.Text),
                                    descuento = float.Parse(txtDescuento.Text) / 100,
                                    ram=txtRam.Text,
                                    almacenamiento=txtAlmacenamiento.Text,
                                    camara=txtCamara.Text,
                                    envio = (bool)rdEnvio.IsChecked,
                                    marca = new marca() { nombre_marca = txtMarca.Text },
                                    imagen = imagen,
                                    precio = int.Parse(txtPrecio.Text)
                                };
                                lbmessage.Content = Scelulares.update(c);
                                refresh();
                                btnActualizar.Visibility = Visibility.Collapsed;
                                btnEliminar.Visibility = Visibility.Collapsed;
                                _btnSubir.IsEnabled = true;
                            limpiar_campos();

                        }
                        else
                            {
                                lbmessage.Content = "No se puedo actualizar correctamnte";
                            }
                        }
                    }
                    else
                    {
                        if (validation())
                        {
                            var _id = (celular)DGcelulares.SelectedItem;

                        celular c = new celular
                            {
                                id = _id.id,
                                nombre = txtNombre.Text,
                                cantidad = int.Parse(txtCantidad.Text),
                                descuento = float.Parse(txtDescuento.Text) / 100,
                                envio = (bool)rdEnvio.IsChecked,
                                marca = new marca() { nombre_marca = txtMarca.Text },
                                imagen = ((celular)DGcelulares.SelectedItem).imagen,
                                precio = int.Parse(txtPrecio.Text),
                                ram = txtRam.Text,
                                descripcion=txtDescripcion.Text,
                                almacenamiento = txtAlmacenamiento.Text,
                                camara = txtCamara.Text
                            };
                            lbmessage.Content = Scelulares.update(c);
                            refresh();
                            btnActualizar.Visibility = Visibility.Collapsed;
                            btnEliminar.Visibility = Visibility.Collapsed;
                            _btnSubir.IsEnabled = true;
                        limpiar_campos();
                        refresh();
                    }
                    else
                        {
                            lbmessage.Content = "No se puedo actualizar correctamnte";
                        }
                    }
                }
            refresh();
        }
        private void limpiar_campos()
        {
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            rdEnvio.IsChecked = false; 
            txtMarca.Text = string.Empty; ;
            txtPrecio.Text = string.Empty; ;
            txtDescripcion.Text = string.Empty; ;
            txtAlmacenamiento.Text = string.Empty; ;
            txtCamara.Text = string.Empty ;
            txtRam.Text = string.Empty; ;
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
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
