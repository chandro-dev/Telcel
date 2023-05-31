using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;



namespace Servicios
{
    public class Spagos
    {

        public string generar_factura(persona _persona,List<producto> productos)
        {
            
            string path = "E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\factura.pdf";
            //File.Create(path);
           
            PdfDocument pdf = new PdfDocument(new PdfWriter(path));
          
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            // Crear un párrafo
            Paragraph paragraph = new Paragraph("¡Hola, mundo!");

            // Agregar el párrafo al documento
            document.Add(paragraph);
            // Cerrar el documento
            document.Close();
            return path;
        }
    }
}
