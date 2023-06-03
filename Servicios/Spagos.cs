using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using Entidades;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;
using System.Security.Permissions;
using Org.BouncyCastle.Math.EC.Multiplier;
using System.Runtime.Intrinsics.Arm;

namespace Servicios
{
    public class Spagos
    {

        public string generar_factura(persona _persona, List<producto> productos)
        {

            string pdfFilePath = @"E:\C_Sharp\Proyecto_Programacion_Final\New folder\Telcel\recursos\factura.pdf";
            string htmlFilePath = @"E:\C_Sharp\Proyecto_Programacion_Final\New folder\Telcel\recursos\index.html";

            Document document = new Document(PageSize.LETTER);
            if (document== null)
            {
                document = new Document();
            }
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
            document.Open();
            // Creamos un objeto XMLWorker para procesar el HTML
            XMLWorkerHelper worker = XMLWorkerHelper.GetInstance();
            using (var stringReader = new StringReader(File.ReadAllText(htmlFilePath)))
            {
                worker.ParseXHtml(writer, document, stringReader);
            }
         // Creamos un objeto Image con la ruta de la imagen
            Image image = Image.GetInstance("E:\\C_Sharp\\Proyecto_Programacion_Final\\New folder\\Telcel\\recursos\\logo.png");
            // Establecemos la posición y tamaño de la imagen en el documento
            image.SetAbsolutePosition(0, 650); // Cambia las coordenadas según tus necesidades
            image.ScaleToFit(100, 100); // Cambia el tamaño según tus necesidades

            // Agregamos la imagen al documento
            document.Add(image);
         
            document.Close();
            return pdfFilePath;
        }


    }

}
