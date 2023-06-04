﻿using Entidades;
using iTextSharp.text.pdf;
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

namespace Vistas.Pages
{
    /// <summary>
    /// Lógica de interacción para Facturacion.xaml
    /// </summary>
    public partial class Facturacion : Page
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private static List<producto> carrito;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private static persona _persona;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private Sfacturas service;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Facturacion(persona p, producto _prod)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

            if (p == null)
            {
                NavigationService.GoBack();
            }
            else
            {
                service = new Sfacturas();

                if (_persona != p)
                {
                    _persona = p;
                    carrito = new List<producto>();
                }
                if (carrito == null)
                {
                    carrito = new List<producto>();
                }
                carrito.Add(_prod);
                InitializeComponent();
                lbCarrito.ItemsSource = carrito;
                _listaCompras.ItemsSource = carrito;
                lbUser.Content = _persona.nombre;
                lb_total.Content = carrito.Sum<producto>(x => x.precio).ToString("C0");
            }
        }
        private void btnanadir(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Principal(_persona));
        }
        private void lbUser_FinalDoubleClick(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            persona p = null;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            NavigationService.Navigate(new Principal(p));
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }
        private void lbUser_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Muser(_persona));
        }
        private void btnpagar(object sender, RoutedEventArgs e)
        {
            factura _factura = new factura();
            _factura.fecha = DateTime.Today;
            _factura.fecha_entrega = DateTime.Today.AddDays(5);
            _factura.tipo_pago = "pasarela de pago";
            _factura.productos=new List<producto>();
            _factura.productos = carrito;
            _factura.cliente = _persona;
            MessageBox.Show( service.add(_factura));
            var spago = new Spagos();
            MessageBox.Show(spago.generar_factura(_persona, carrito));
            carrito = new List<producto>();
        }
        private void Btnreturn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal(_persona));
        }

        private void lbCarrito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.Visibility = Visibility.Visible;

        }
        private void CLickbtnEliminar(object sender, RoutedEventArgs e)
        {
            if (carrito.Remove((producto)lbCarrito.SelectedItem))
            {
                lbCarrito.ItemsSource = null;
                _listaCompras.ItemsSource = null;
                lbCarrito.ItemsSource = carrito;
                _listaCompras.ItemsSource = carrito;
                btnEliminar.Visibility = Visibility.Collapsed;
                lb_total.Content = carrito.Sum<producto>(x => x.precio).ToString("C0");

            }
        }
    }
}
