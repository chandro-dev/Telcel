using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using Entidades;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Drawing;
using iTextSharp.text.html;

namespace Servicios
{
    public class Spagos
    {

        public string generar_factura(persona _persona, List<producto> productos)
        {

            string path = "E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\factura.pdf";
            string htmlFilePath = "E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\index.html";
            // Creamos un documento PDF
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Abrimos el documento
            document.Open();

            // Leemos el contenido HTML desde el archivo
            string htmlContent = File.ReadAllText(htmlFilePath);

            // Creamos un objeto HTMLWorker para procesar el HTML
            HTMLWorker htmlWorker = new HTMLWorker(document);
            htmlWorker.Parse(new StringReader(htmlContent));

            // Cerramos el documento
            document.Close();
            /*iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // Abrimos el documento
            document.Open();

            // Leemos el contenido HTML desde el archivo
            string htmlContent = File.ReadAllText(htmlFilePath);

            // Creamos un objeto HTMLWorker para procesar el HTML
            HTMLWorker htmlWorker = new HTMLWorker(document);
            htmlWorker.Parse(new StringReader(htmlContent));

            // Cerramos el documento
            document.Close();
            */
            return path;

        }


    }

}
