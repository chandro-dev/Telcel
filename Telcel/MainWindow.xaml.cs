using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Telcel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Sclientes sclientes = new Sclientes();
            sclientes.Add_Cliente(new Entidades.cliente()
            {
                
                nombre="Luis",
                telefono="3108167406",contrasena ="masda",
                dirrecion=" ",
                email="@",
                id=2
            }) ;
                InitializeComponent();
            

        }
    }
}
