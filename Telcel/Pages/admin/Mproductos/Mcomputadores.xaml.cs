using Entidades;
using Microsoft.Win32;
using Oracle.SqlAndPlsqlParser;
using Repositorio;
using Repositorio.Oracle;
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

    public partial class Mcomputadores : Page
    {
        private string rutaArchivoSeleccionado;
        Scomputadores Scomputadores;
        public Mcomputadores()
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
                computador c = new computador
                {
                    nombre = txtNombre.Text,
                    cantidad = int.Parse(txtCantidad.Text),
                    descuento = float.Parse(txtDescuento.Text) / 100,
                    envio =(bool)rdEnvio.IsChecked,
                    marca = new marca() { nombre_marca = txtMarca.Text },
                    imagen = imagen,
                    precio = double.Parse(txtPrecio.Text),
                    almacenamiento = txtAlmacenamiento.Text,
                    procesador = txtProcesador.Text,
                    ram = txtRam.Text,
                    tarjeta_madre = txtTmadre.Text,
                    tarjeta_video = txtTvideo.Text
                };
                lbmessage.Content= Scomputadores.add(c);
                limpiar_campos();
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

        private void DGcomputadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGcomputadores.SelectedItem != null)
            {
                try
                {
                    txtNombre.Text = ((computador)DGcomputadores.SelectedItem).nombre;
                    txtCantidad.Text = ((computador)DGcomputadores.SelectedItem).cantidad.ToString();
                    txtDescuento.Text = (((computador)DGcomputadores.SelectedItem).descuento * 100).ToString();
                    rdEnvio.IsChecked = ((computador)DGcomputadores.SelectedItem).envio;
                    txtMarca.Text = ((computador)DGcomputadores.SelectedItem).marca.nombre_marca;
                    txtPrecio.Text = ((computador)DGcomputadores.SelectedItem).precio.ToString();
                    txtProcesador.Text = ((computador)DGcomputadores.SelectedItem).procesador;
                    txtAlmacenamiento.Text = ((computador)DGcomputadores.SelectedItem).almacenamiento;
                    txtTmadre.Text = ((computador)DGcomputadores.SelectedItem).tarjeta_madre;
                    txtTvideo.Text = ((computador)DGcomputadores.SelectedItem).tarjeta_video;
                    txtRam.Text = ((computador)DGcomputadores.SelectedItem).ram;
                }
                catch { }
                btnEliminar.Visibility = Visibility.Visible;
                btnActualizar.Visibility = Visibility.Visible;
                _btnSubir.IsEnabled = false;
            }
        }
        private void ClickBtnEliminar(object sender, RoutedEventArgs e)
        {
            lbmessage.Content = (Scomputadores.remove((computador)DGcomputadores.SelectedItem));
            refresh();
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
            if (txtAlmacenamiento.Text.Length <= 0)
            {
                lbAlmacenamiento.Content = lbAlmacenamiento.Content + "*";
                stado = false;
            }
            if (txtProcesador.Text.Length <= 0)
            {
                lbProcesador.Content = lbProcesador.Content + "*";
                stado = false;
            }
            if (txtRam.Text.Length <= 0)
            {
                lbRam.Content = lbRam.Content + "*";
                stado = false;
            }
            if (txtTmadre.Text.Length <= 0)
            {
                lbTmadre.Content = lbTmadre.Content + "*";
                stado = false;
            }
            if (txtTvideo.Text.Length <= 0)
            {
                lbTvideo.Content = lbTvideo.Content + "*";
                stado = false;
            }
           
            return stado;
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DGcomputadores.SelectedItem != null)
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
                            var _id = (computador)DGcomputadores.SelectedItem;
                            computador c = new computador
                            {

                                id = _id.id,
                                nombre = txtNombre.Text,
                                procesador =txtProcesador.Text,
                                cantidad = int.Parse(txtCantidad.Text),
                                descuento = float.Parse(txtDescuento.Text) / 100,
                                ram = txtRam.Text,
                                almacenamiento = txtAlmacenamiento.Text,
                                tarjeta_video = txtTvideo.Text,
                                tarjeta_madre=txtTmadre.Text,
                                envio = rdEnvio.IsChecked.Value,
                                marca = new marca() { nombre_marca = txtMarca.Text },
                                imagen = imagen,
                                precio = int.Parse(txtPrecio.Text)
                            };
                            lbmessage.Content = Scomputadores.update(c);
                            refresh();
                            limpiar_campos();
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
                        var _id = (computador)DGcomputadores.SelectedItem;

                        computador c = new computador
                        {
                            id = _id.id,
                            nombre = txtNombre.Text,
                            procesador = txtProcesador.Text,
                            cantidad = int.Parse(txtCantidad.Text),
                            descuento = float.Parse(txtDescuento.Text) / 100,
                            ram = txtRam.Text,
                            almacenamiento = txtAlmacenamiento.Text,
                            tarjeta_video = txtTvideo.Text,
                            tarjeta_madre = txtTmadre.Text,
                            envio = rdEnvio.IsChecked.Value,
                            marca = new marca() { nombre_marca = txtMarca.Text },
                            imagen = ((computador)DGcomputadores.SelectedItem).imagen,
                            precio = int.Parse(txtPrecio.Text),

                        };
                        lbmessage.Content = Scomputadores.update(c);
                        refresh();
                        limpiar_campos();
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
        }
        private void limpiar_campos()
        {
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            rdEnvio.IsChecked = false;
            txtMarca.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtProcesador.Text = string.Empty;
            txtAlmacenamiento.Text = string.Empty;
            txtTmadre.Text = string.Empty;
            txtTvideo.Text = string.Empty;
            txtRam.Text = string.Empty;
        }
    }

}

