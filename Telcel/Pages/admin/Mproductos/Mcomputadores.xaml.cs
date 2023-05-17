using Entidades;
using Microsoft.Win32;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Vistas.Pages.admin.Mproductos
{
    /// <summary>
    /// Lógica de interacción para Mcomputadores.xaml
    /// </summary>
    public partial class Mcomputadores : Page
    {
        private string rutaArchivoSeleccionado;
        Scomputadores Scomputadores;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Mcomputadores()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            InitializeComponent();
            Scomputadores = new Scomputadores();
            if (Scomputadores.GetComputadors().Count > 0)
            {
                DGcomputadores.ItemsSource = Scomputadores.GetComputadors();
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
                computador c = new computador
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
                    procesador = txtProcesador.Text,
                    ram = txtRam.Text,
                    tarjeta_madre = txtTmadre.Text,
                    tarjeta_video = txtTvideo.Text
                };
                Scomputadores.add(c);
                refresh();
            }
        }
        public void btnVolver(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void refresh()
        {
            DGcomputadores.ItemsSource = null;
            DGcomputadores.ItemsSource = Scomputadores.GetComputadors();
        }

    }

}
