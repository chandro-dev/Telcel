using Entidades;
using Microsoft.Win32;
using Servicios;
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

namespace Vistas.Pages.admin.Mproductos
{
    /// <summary>
    /// Lógica de interacción para Mcelulares.xaml
    /// </summary>
    public partial class Mcelulares : Page
    {
        private string rutaArchivoSeleccionado;
        Scelulares Scelulares;
        public Mcelulares()
        {
            InitializeComponent();
            Scelulares = new Scelulares();
            if (Scelulares.GetCelulares() != null && Scelulares.GetCelulares().Count >0)
            {
                refresh();
            }

        }
        public void btnSelecionar(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
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
                    camara= txtCamara.Text,
                    ram = txtRam.Text
                    
                };
                Scelulares.add(c);
                refresh();
                MessageBox.Show("Guardado exitosamente");
            }
        }
        private void btnVolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void refresh()
        {
            DGcelulares.ItemsSource = null;
            DGcelulares.ItemsSource = Scelulares.GetCelulares();
        }
    }
}
