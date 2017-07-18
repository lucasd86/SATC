using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Lppa.Entities
{
    public class TarjetaPDF
    {

        public void TarjetaVisa(TarjetaImpresion tarjeta)
        {

            iTextSharp.text.pdf.BaseFont fuente;


            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;


            //Creamos un tipo de archivo que solo se cargará en la memoria principal
            Document documento = new Document();
            //Creamos la instancia para generar el archivo PDF
            //Le pasamos el documento creado arriba y con capacidad para abrir o Crear y de nombre Mi_Primer_PDF
            PdfWriter pdfwrite = PdfWriter.GetInstance(documento, new FileStream("VISA.PDF", FileMode.OpenOrCreate));

            PdfContentByte cb;

            //Abrimos el documento
            documento.Open();

            //Le agregamos un párrafo
            cb = pdfwrite.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(fuente, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE);          //Defino color de la fuente  
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,Convert.ToString( tarjeta.Numero), 50, 782, 0); //Posicionamiento del numero de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,Convert.ToString( tarjeta.FechaDesde), 75, 770, 0);//Posicionamiento de la fecha de inicio

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString( tarjeta.FechaVenc), 25, 770, 0);//Posicionamiento de la fecha de vencimiento

            cb.SetFontAndSize(fuente, 7);//Fuente mas pequeña para el nombre de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tarjeta._cliente.Nombre, 50, 760, 0);//Posicionamiento del nombre de la tarjeta

            //Reverso de la tarjeta
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.CodigoSeguridad), 120, 695, 0);//Posicionamiento del codigo de seguridad

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("visafrente.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            imagen.SetAbsolutePosition(0, 750);


            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("visareverso.jpg");
            imagen2.BorderWidth = 0;
            imagen2.Alignment = Element.ALIGN_LEFT;
            float percentage2 = 0.0f;
            percentage2 = 150 / imagen2.Width;
            imagen2.ScalePercent(percentage2 * 100);
            imagen2.SetAbsolutePosition(0, 650);




            // Insertamos las imagen de tarjetas en el documento
            documento.Add(imagen);
            documento.Add(imagen2);

            var parrafo = new Paragraph("");
            parrafo.Alignment = Element.ALIGN_LEFT;
            documento.Add(parrafo);

            cb.EndText();

            //Cerramos el documento
            documento.Close();

            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo.FileName = "VISA.PDF";
            proceso.Start();
            proceso.Close();
        }
        public void TarjetaMaster(TarjetaImpresion tarjeta)
        {



            iTextSharp.text.pdf.BaseFont fuente;


            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;


            //Creamos un tipo de archivo que solo se cargará en la memoria principal
            Document documento = new Document();
            //Creamos la instancia para generar el archivo PDF
            //Le pasamos el documento creado arriba y con capacidad para abrir o Crear y de nombre Mi_Primer_PDF
            PdfWriter pdfwrite = PdfWriter.GetInstance(documento, new FileStream("MASTER.pdf", FileMode.OpenOrCreate));

            PdfContentByte cb;

            //Abrimos el documento
            documento.Open();

            //Le agregamos un párrafo


            cb = pdfwrite.DirectContent;


            cb.BeginText();

            cb.SetFontAndSize(fuente, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE);          //Defino color de la fuente  

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.Numero), 50, 782, 0); //Posicionamiento del numero de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.FechaDesde), 75, 770, 0);//Posicionamiento de la fecha de inicio

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.FechaVenc), 25, 770, 0);//Posicionamiento de la fecha de vencimiento

            cb.SetFontAndSize(fuente, 7);//Fuente mas pequeña para el nombre de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tarjeta._cliente.Nombre, 50, 760, 0);//Posicionamiento del nombre de la tarjeta

            //Reverso de la tarjeta
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,Convert.ToString(tarjeta.CodigoSeguridad), 120, 695, 0);//Posicionamiento del codigo de seguridad

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("masterfrente.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            imagen.SetAbsolutePosition(0, 750);


            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("masterreverso.jpg");
            imagen2.BorderWidth = 0;
            imagen2.Alignment = Element.ALIGN_LEFT;
            float percentage2 = 0.0f;
            percentage2 = 150 / imagen2.Width;
            imagen2.ScalePercent(percentage2 * 100);
            imagen2.SetAbsolutePosition(0, 650);




            // Insertamos las imagen de tarjetas en el documento
            documento.Add(imagen);
            documento.Add(imagen2);

            var parrafo = new Paragraph("");
            parrafo.Alignment = Element.ALIGN_LEFT;
            documento.Add(parrafo);

            cb.EndText();

            //Cerramos el documento
            documento.Close();

            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo.FileName = "MASTER.pdf";
            proceso.Start();
            proceso.Close();
        }
        public void TarjetaAmerican(TarjetaImpresion tarjeta)
        {



            iTextSharp.text.pdf.BaseFont fuente;


            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;


            //Creamos un tipo de archivo que solo se cargará en la memoria principal
            Document documento = new Document();
            //Creamos la instancia para generar el archivo PDF
            //Le pasamos el documento creado arriba y con capacidad para abrir o Crear y de nombre Mi_Primer_PDF
            PdfWriter pdfwrite = PdfWriter.GetInstance(documento, new FileStream("AMERICAN.pdf", FileMode.OpenOrCreate));

            PdfContentByte cb;

            //Abrimos el documento
            documento.Open();

            //Le agregamos un párrafo


            cb = pdfwrite.DirectContent;


            cb.BeginText();

            cb.SetFontAndSize(fuente, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);          //Defino color de la fuente  

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.Numero), 50, 782, 0); //Posicionamiento del numero de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToString(tarjeta.FechaVenc), 80, 768, 0);//Posicionamiento de la fecha de vencimiento
            cb.SetFontAndSize(fuente, 7);//Fuente mas pequeña para el nombre de la tarjeta

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tarjeta._cliente.Nombre, 50, 760, 0);//Posicionamiento del nombre de la tarjeta

            //Reverso de la tarjeta
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,Convert.ToString( tarjeta.CodigoSeguridad), 120, 790, 0);//Posicionamiento del codigo de seguridad

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("americanfrente.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            imagen.SetAbsolutePosition(0, 750);


            //iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("masterreverso.jpg");
            //imagen2.BorderWidth = 0;
            //imagen2.Alignment = Element.ALIGN_LEFT;
            //float percentage2 = 0.0f;
            //percentage2 = 150 / imagen2.Width;
            //imagen2.ScalePercent(percentage2 * 100);
            //imagen2.SetAbsolutePosition(0, 650);




            // Insertamos las imagen de tarjetas en el documento
            documento.Add(imagen);
            //documento.Add(imagen2);

            var parrafo = new Paragraph("");
            parrafo.Alignment = Element.ALIGN_LEFT;
            documento.Add(parrafo);

            cb.EndText();

            //Cerramos el documento
            documento.Close();

            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo.FileName = "AMERICAN.pdf";
            proceso.Start();
            proceso.Close();
        }
    }
}
