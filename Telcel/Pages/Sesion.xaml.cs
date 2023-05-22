﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
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
using Vistas.Pages.admin;

namespace Vistas.Pages
{
public partial class page : Page

    {
        Ssesiones sesiones;
        public page()
        {
            sesiones = new Ssesiones(); 
            InitializeComponent();
        }
        public void clickImagen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Principal(null));

        }
        public void initSesion(object sender, RoutedEventArgs e) {
            persona usuario = sesiones.validation(Contrasena.Password, txtUsuario.Text);
            if (usuario != null)
            {
                if (usuario.rol.id == 1)
                {
                    NavigationService.Navigate(new MenuAdmin());
                }
                else
                {
                    NavigationService.Navigate(new Principal(usuario));
                
                }

            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
            }
        }

    }
}
