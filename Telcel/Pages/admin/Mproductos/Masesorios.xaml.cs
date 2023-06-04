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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;

namespace Vistas.Pages.admin.Mproductos
{
    /// <summary>
    /// Lógica de interacción para Masesorios.xaml
    /// </summary>
    public partial class Masesorios : Page
    {
        private string rutaArchivoSeleccionado;
        Sasesorios Sasesorios;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Masesorios()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

            InitializeComponent();

            DGasesorios.IsReadOnly = true;
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
                if (validation())
                {
#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                    asesorio a = new asesorio
                    {
                        nombre = txtNombre.Text,
                        referencia = txtReferencia.Text,
                        cantidad = int.Parse(txtCantidad.Text),
                        descuento = float.Parse(txtDescuento.Text) / 100,
                        envio = rdEnvio.IsChecked.Value,
                        marca = new marca() { nombre_marca = txtMarca.Text },
                        imagen = imagen,
                        precio = int.Parse(txtPrecio.Text)
                    };
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                    lbmessage.Content = Sasesorios.add(a);
                    refresh();
                }
                else
                {
                    lbmessage.Content = "No se puedo subir el asesorio con exito";
                }
            }
            else
            {
                lbImagen.Content = lbImagen.Content + "*";
                lbmessage.Content = "No se puedo subir el asesorio con exito";
            }

        }
        private void btnVolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void refresh()
        {
            DGasesorios.ItemsSource = null;
            DGasesorios.ItemsSource = Sasesorios.GetAsesorios();
        }
        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal amount))
            {
                txtPrecio.Text = amount.ToString("C");
            }
        }


        private void DGasesorios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGasesorios.SelectedItem != null)
            {
                try
                {
                    txtNombre.Text = ((asesorio)DGasesorios.SelectedItem).nombre;
                    txtReferencia.Text = ((asesorio)DGasesorios.SelectedItem).referencia;
                    txtCantidad.Text = ((asesorio)DGasesorios.SelectedItem).cantidad.ToString();
                    txtDescuento.Text = (((asesorio)DGasesorios.SelectedItem).descuento * 100).ToString();
                    rdEnvio.IsChecked = ((asesorio)DGasesorios.SelectedItem).envio;
                    txtMarca.Text = ((asesorio)DGasesorios.SelectedItem).marca.nombre_marca;
                    txtPrecio.Text = ((asesorio)DGasesorios.SelectedItem).precio.ToString();
                }
                catch { }
                btnEliminar.Visibility = Visibility.Visible;
                btnActualizar.Visibility = Visibility.Visible;
                _btnSubir.IsEnabled = false;
            }
        }
        private void ClickBtnEliminar(object sender, RoutedEventArgs e)
        {
            Sasesorios.remove((asesorio)DGasesorios.SelectedItem);
            refresh();
            btnEliminar.Visibility = Visibility.Visible;
            _btnSubir.IsEnabled = true;

        }
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
            if (txtReferencia.Text.Length <= 0)
            {
                lbRerencia.Content = lbRerencia.Content + "*";
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
            if (DGasesorios.SelectedItem != null)
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
                            var _id = (asesorio)DGasesorios.SelectedItem;
#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                            asesorio a = new asesorio
                            {

                                id = _id.id,
                                nombre = txtNombre.Text,
                                referencia = txtReferencia.Text,
                                cantidad = int.Parse(txtCantidad.Text),
                                descuento = float.Parse(txtDescuento.Text) / 100,
                                envio = rdEnvio.IsChecked.Value,
                                marca = new marca() { nombre_marca = txtMarca.Text },
                                imagen = imagen,
                                precio = int.Parse(txtPrecio.Text)
                            };
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                            lbmessage.Content = Sasesorios.update(a);
                            refresh();
                            clear_btn();
                            btnActualizar.Visibility = Visibility.Collapsed;
                            btnEliminar.Visibility = Visibility.Collapsed;
                            _btnSubir.IsEnabled = true;
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
                        var _id = (asesorio)DGasesorios.SelectedItem;

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                        asesorio a = new asesorio
                        {
                            id = _id.id,
                            nombre = txtNombre.Text,
                            referencia = txtReferencia.Text,
                            cantidad = int.Parse(txtCantidad.Text),
                            descuento = float.Parse(txtDescuento.Text) / 100,
                            envio = rdEnvio.IsChecked.Value,
                            marca = new marca() { nombre_marca = txtMarca.Text },
                            imagen = ((asesorio)DGasesorios.SelectedItem).imagen,
                            precio = int.Parse(txtPrecio.Text)
                        };
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                        lbmessage.Content = Sasesorios.update(a);
                        refresh();
                        clear_btn();
                        btnActualizar.Visibility = Visibility.Collapsed;
                        btnEliminar.Visibility=Visibility.Collapsed;
                        _btnSubir.IsEnabled = true;

                    }
                    else
                    {
                        lbmessage.Content = "No se puedo actualizar correctamnte";
                    }
                }
            }
        } 
        private void clear_btn()
        {
            txtNombre.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtCantidad.Text = string.Empty; 
            txtDescuento.Text = string.Empty;
            rdEnvio.IsChecked = false;
            txtMarca.Text = string.Empty;
            txtPrecio.Text = string.Empty; 
        }
    }
}
