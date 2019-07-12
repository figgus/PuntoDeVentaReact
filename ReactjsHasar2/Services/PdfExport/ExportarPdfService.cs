using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReactjsHasar2.Services.PdfExport
{
    public class ExportarPdfService : IExportarPdfService
    {
        public void DteToPdf(XmlDocument xmlDte)
        {
            XmlDocument xml = xmlDte;
            //xml.LoadXml(xmlDte);


            //-----EXTRAER DATOS XML

            XmlNodeList RazonSocialEmisor = xml.GetElementsByTagName("RznSoc");
            string razonSocial = string.Empty;
            razonSocial = RazonSocialEmisor[0].InnerXml.ToString();


            XmlNodeList GiroEmi = xml.GetElementsByTagName("GiroEmis");
            string GiroEmisor = string.Empty;
            GiroEmisor = GiroEmi[0].InnerXml.ToString();

            XmlNodeList DirOrigen = xml.GetElementsByTagName("DirOrigen");
            XmlNodeList CmnaOrigen = xml.GetElementsByTagName("CmnaOrigen");
            XmlNodeList CiudadOrigen = xml.GetElementsByTagName("CiudadOrigen");
            string direccion = string.Empty;
            direccion = "Casa matriz: " + DirOrigen[0].InnerXml.ToString() + ", Ciudad " + CiudadOrigen[0].InnerXml.ToString() + " Comuna " + CmnaOrigen[0].InnerXml.ToString();

            XmlNodeList GiroRece = xml.GetElementsByTagName("GiroRecep");
            string GiroRecep = string.Empty;
            GiroRecep = GiroRece[0].InnerXml.ToString();

            XmlNodeList RznSocRece = xml.GetElementsByTagName("RznSocRecep");
            string RznSocRecep = string.Empty;
            RznSocRecep = RznSocRece[0].InnerXml.ToString();

            XmlNodeList DirRece = xml.GetElementsByTagName("DirRecep");
            string DirRecep = string.Empty;
            DirRecep = DirRece[0].InnerXml.ToString();

            XmlNodeList RUTRece = xml.GetElementsByTagName("RUTRecep");
            string RUTRecep = string.Empty;
            RUTRecep = RUTRece[0].InnerXml.ToString();


            XmlNodeList CmnaRece = xml.GetElementsByTagName("CmnaRecep");
            string CmnaRecep = string.Empty;
            CmnaRecep = CmnaRece[0].InnerXml;

            XmlNodeList CiudadRece = xml.GetElementsByTagName("CiudadRecep");
            string CiudadRecep = string.Empty;
            CiudadRecep = CiudadRece[0].InnerXml.ToString();

            XmlNodeList Foli = xml.GetElementsByTagName("Folio");
            string Folio = string.Empty;
            Folio = Foli[0].InnerXml.ToString();

            XmlNodeList FchEmi = xml.GetElementsByTagName("FchEmis");
            string FchEmis = string.Empty;
            FchEmis = FchEmi[0].InnerXml.ToString();

            XmlNodeList TipoDT = xml.GetElementsByTagName("TipoDTE");
            string TipoDTE = string.Empty;
            TipoDTE = TipoDT[0].InnerXml.ToString();

            XmlNodeList RutEmiso = xml.GetElementsByTagName("RutEmisor");
            string RutEmisor = string.Empty;
            RutEmisor = RutEmiso[0].InnerXml.ToString();

            XmlNodeList D = xml.GetElementsByTagName("DD");
            string DD = string.Empty;
            DD = D[0].OuterXml.ToString();
            CrearPDF417(DD);

            XmlNodeList tipoCodigo = xml.GetElementsByTagName("TpoCodigo");
            string TpoCodigo = string.Empty;
            DD = D[0].OuterXml.ToString();

            XmlNodeList VlrCodigoo = xml.GetElementsByTagName("VlrCodigo");
            string VlrCodigo = string.Empty;
            DD = D[0].OuterXml.ToString();

            XmlNodeList FchVenc = xml.GetElementsByTagName("FchVenc");
            string fechaVencimiento = string.Empty;
            if (FchVenc.Count > 0)
            {
                fechaVencimiento = FchVenc[0].OuterXml.ToString();
            }


            //----------FIN EXTRAER DATOS XML

            //-----------CREAR DOCUMENTO

            var tiempo = DateTime.Now.ToString("ddMMyyyyhhmmss");

            Document doc = new Document();
            doc.SetMargins(-5, 3, 7, 7);
            var ruta = @"C:\Users\Desarrollo 02\Desktop\prueba.pdf";
            FileStream fs = new FileStream(ruta, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);


            Font fuente = new Font();
            fuente.Size = 12;


            doc.Open();


            float[] columnasEncabezaado = new float[2];
            columnasEncabezaado[0] = 150f;
            columnasEncabezaado[1] = 100f;

            //PdfPTable tablaRedonda = new PdfPTable(2);
            //tablaRedonda.DefaultCell.Border = PdfPCell.NO_BORDER;
            //tablaRedonda.DefaultCell.CellEvent = new RoundedBorder();
            //var celda = tablaRedonda.DefaultCell;
            ////celda.Phrase = new Phrase("asdasdsa");
            //celda.AddElement(new Phrase("asdasdsa"));
            //tablaRedonda.AddCell(new PdfPCell(new Phrase("hyhyhy")));


            //doc.Add(tablaRedonda);

            PdfPTable encabezado = new PdfPTable(2);
            encabezado.DefaultCell.Border = Rectangle.NO_BORDER;
            encabezado.HorizontalAlignment = Element.ALIGN_CENTER;
            encabezado.SetWidths(columnasEncabezaado);

            PdfPTable prueba = new PdfPTable(1);


            PdfPCell cuadro = new PdfPCell();
            cuadro.BorderColor = BaseColor.RED;
            cuadro.BorderWidth = 2.5f;
            cuadro.PaddingBottom = 5;


            Paragraph parrafo = new Paragraph();
            parrafo.Clear();
            parrafo.Alignment = Element.ALIGN_CENTER;
            parrafo.Font = new Font(FontFactory.GetFont("sans-serif", 13, Font.BOLD, BaseColor.RED));
            parrafo.Add("R.U.T: " + RutEmisor);
            cuadro.AddElement(parrafo);

            parrafo.Clear();
            parrafo.Alignment = Element.ALIGN_CENTER;
            parrafo.Font = new Font(FontFactory.GetFont("sans-serif", 13, Font.BOLD, BaseColor.RED));
            parrafo.Add("FACTURA ELECTRONICA");

            cuadro.AddElement(parrafo);

            parrafo.Clear();
            parrafo.Alignment = Element.ALIGN_CENTER;
            parrafo.Font = new Font(FontFactory.GetFont("sans-serif", 13, Font.BOLD, BaseColor.RED));
            parrafo.Add("N° 0000000" + Folio);
            cuadro.AddElement(parrafo);

            PdfPCell celdaPrueba = new PdfPCell();
            celdaPrueba.BorderWidth = 0;



            celdaPrueba.AddElement(new Paragraph(razonSocial, fuente));

            fuente.Size = 8;

            celdaPrueba.AddElement(new Paragraph(GiroEmisor, fuente));

            fuente.Size = 5;
            celdaPrueba.AddElement(new Paragraph(direccion, fuente));
            prueba.AddCell(celdaPrueba);




            encabezado.AddCell(prueba);
            encabezado.AddCell(cuadro);



            doc.Add(encabezado);

            doc.Add(new Paragraph(" "));


            PdfPTable principal = new PdfPTable(2);
            //principal.HorizontalAlignment = Element.ALIGN_CENTER;


            PdfPTable table = new PdfPTable(2);

            PdfPCell cell = new PdfPCell();
            cell.BorderWidth = 0;
            cell.HorizontalAlignment = 0;
            cell.Colspan = 2;
            fuente.Size = 6;

            PdfPTable tablaInfo = new PdfPTable(4);
            tablaInfo.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaInfo.WidthPercentage = 100;


            var chunka = new Chunk("SEÑORES: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));

            var chunkb = new Chunk(RznSocRecep, fuente);

            var cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);

            cell.AddElement(tablaInfo);


            chunka = new Chunk("DIRECCION: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(DirRecep, fuente);
            cellInfo = new PdfPCell(new Paragraph(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Paragraph(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;


            chunka = new Chunk("COMUNA: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(CmnaRecep, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);

            chunka = new Chunk("R.U.T: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(RUTRecep, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;

            chunka = new Chunk("GIRO: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(GiroRecep, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);

            chunka = new Chunk("CODIGO: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(GiroRecep, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo).HorizontalAlignment = Element.ALIGN_RIGHT;

            chunka = new Chunk("CIUDAD: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(GiroRecep, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            tablaInfo.AddCell(cellInfo);

            table.AddCell(cell);




            PdfPTable table2 = new PdfPTable(new float[] { 80f, 120f });
            table2.HorizontalAlignment = Element.ALIGN_RIGHT;
            table2.WidthPercentage = 30;

            PdfPCell cell2 = new PdfPCell();
            cell2.Colspan = 2;
            cell2.BorderWidth = 0;

            chunka = new Chunk("FECHA EMISION: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(FchEmis, fuente);
            //paratesta = new Paragraph();
            //paratesta.Add(chunka);
            //paratesta.Add(chunkb);

            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);
            table.AddCell(table2);

            chunka = new Chunk("FECHA VENCIMIENTO: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk(fechaVencimiento, fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);

            chunka = new Chunk("FORMA DE PAGO: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk("", fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);

            chunka = new Chunk("COD. VENDEDOR: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunkb = new Chunk("", fuente);
            cellInfo = new PdfPCell(new Phrase(chunka));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);
            cellInfo.BorderWidth = 0;
            cellInfo = new PdfPCell(new Phrase(chunkb));
            cellInfo.BorderWidth = 0;
            table2.AddCell(cellInfo);

            table2.AddCell(cell2);



            principal.AddCell(table);
            principal.AddCell(table2);
            doc.Add(principal);



            doc.Add(new Paragraph(Chunk.NEWLINE) { SpacingAfter = 0.5f });

            PdfPTable principal2 = new PdfPTable(new float[] { 40, 60 });
            principal2.HorizontalAlignment = Element.ALIGN_CENTER;




            PdfPTable table3 = new PdfPTable(3);
            table3.HorizontalAlignment = Element.ALIGN_CENTER;
            table3.WidthPercentage = 30;


            PdfPCell cell3 = new PdfPCell(new Phrase(new Chunk("Tipo de documento", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)))));
            cell3.BorderWidth = 0;

            table3.AddCell(cell3);

            cell3 = new PdfPCell(new Phrase(new Chunk("Folio", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)))));
            cell3.BorderWidth = 0;
            table3.AddCell(cell3);

            cell3 = new PdfPCell(new Phrase(new Chunk("Fecha", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)))));
            cell3.BorderWidth = 0;
            table3.AddCell(cell3);



            PdfPCell valores = new PdfPCell(new Paragraph("Factura Electronica", fuente));
            valores.BorderWidth = 0;
            table3.AddCell(valores);

            valores = new PdfPCell(new Paragraph(Folio, fuente));
            valores.BorderWidth = 0;
            table3.AddCell(valores);

            valores = new PdfPCell(new Paragraph(FchEmis, fuente));
            valores.BorderWidth = 0;
            table3.AddCell(valores);
            principal2.AddCell(table3);


            //doc.Add(table3);

            PdfPTable table4 = new PdfPTable(2);
            table4.HorizontalAlignment = 0;
            PdfPCell cell4 = new PdfPCell();
            cell4.BorderWidth = 0;
            cell4.Colspan = 2;

            PdfPTable tabla2InfoDir = new PdfPTable(new float[] { 40, 60 });
            tabla2InfoDir.HorizontalAlignment = Element.ALIGN_LEFT;

            var chunk1 = new Chunk("Direccion de Origen: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            var chunk2 = new Chunk(direccion, new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk1)) { BorderWidth = 0 });
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk2)) { BorderWidth = 0 });



            chunk1 = new Chunk("Comuna: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunk2 = new Chunk(CmnaOrigen[0].InnerXml.ToString(), new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk1)) { BorderWidth = 0 });
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk2)) { BorderWidth = 0 });


            chunk1 = new Chunk("Direccion de Destino: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunk2 = new Chunk(DirRecep.ToString(), new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk1)) { BorderWidth = 0 });
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk2)) { BorderWidth = 0 });



            chunk1 = new Chunk("Comuna: ", new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            chunk2 = new Chunk(CmnaRecep.ToString(), new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk1)) { BorderWidth = 0 });
            tabla2InfoDir.AddCell(new PdfPCell(new Phrase(chunk2)) { BorderWidth = 0 });

            cell4.AddElement(tabla2InfoDir);



            table4.AddCell(cell4);
            principal2.AddCell(table4);
            doc.Add(principal2);

            


            PdfPTable tablaDetalles = new PdfPTable(new float[] { 7, 40, 8, 8, 8, 9, 10, 10 });
            tablaDetalles.HorizontalAlignment = Element.ALIGN_CENTER;

            doc.Add(new Paragraph(Chunk.NEWLINE) { SpacingAfter = 0.5f });

            Rectangle rec = new Rectangle(1, 1);

            var fuenteEncabezados = new Font(new Font(FontFactory.GetFont("Arial", 6, Font.BOLD)));
            PdfPCell cellDetalle = new PdfPCell(new Paragraph(new Chunk("Codigo", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;

            tablaDetalles.AddCell(cellDetalle);

            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Detalle", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);

            cellDetalle = new PdfPCell(new Paragraph(new Chunk("UNID", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);

            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Cantidad", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);


            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Precio Unitario", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);


            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Desc %", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);

            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Desc $", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);
            //tablaDescuento.AddCell(new PdfPCell(new Paragraph("%", fuenteEncabezados)) { HorizontalAlignment=Element.ALIGN_CENTER,BorderWidthBottom=0,BorderWidthLeft=0, BorderWidthTop = 0 ,PaddingBottom=0});
            //tablaDescuento.AddCell(new PdfPCell(new Paragraph("$", fuenteEncabezados)) { HorizontalAlignment = Element.ALIGN_CENTER,BorderWidthRight=0,BorderWidthTop=0, BorderWidthBottom = 0, PaddingBottom = 0 });

            //cellDetalle = new PdfPCell(new Paragraph(new Chunk("Descuento", fuenteEncabezados)));
            //cellDetalle.BorderWidthLeft = 0.5f;
            //cellDetalle.AddElement(tablaDescuento);
            //tablaDetalles.AddCell(cellDetalle);

            cellDetalle = new PdfPCell(new Paragraph(new Chunk("Precio Item", fuenteEncabezados)));
            cellDetalle.BorderWidthLeft = 0.5f;
            tablaDetalles.AddCell(cellDetalle);

            var seed = Environment.TickCount;

            XmlNodeList Detalle = xml.GetElementsByTagName("Detalle");

            var random = new Random(seed);
            int montoTotal = 0;
            var fuenteDetalle = new iTextSharp.text.Font(new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            for (int i = 0; i < Detalle.Count; i++)
            {
                //int cantidad = random.Next(1, 5);
                XmlDocument xmlDetalles = new XmlDocument();
                xmlDetalles.LoadXml(Detalle[i].OuterXml);

                XmlNodeList arti = xmlDetalles.GetElementsByTagName("NmbItem");
                string articulo = string.Empty;
                articulo = arti[0].InnerXml.ToString();

                XmlNodeList montoArti = xmlDetalles.GetElementsByTagName("MontoItem");
                string montoArticulo = string.Empty;
                montoArticulo = montoArti[0].InnerXml.ToString();
                //-- CODIGO
                XmlNodeList tpoCod = xmlDetalles.GetElementsByTagName("TpoCodigo");
                string cod1 = string.Empty;
                if (tpoCod.Count > 0)
                {

                    cod1 = tpoCod[0].InnerXml.ToString();
                }

                XmlNodeList vlrCod = xmlDetalles.GetElementsByTagName("VlrCodigo");
                string cod2 = string.Empty;
                if (vlrCod.Count > 0)
                {
                    cod2 = vlrCod[0].InnerXml.ToString();
                }


                PdfPCell valoresDetalles = new PdfPCell(new Paragraph(new Chunk(cod1 + "-" + cod2, fuenteDetalle)));
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                valoresDetalles.BorderWidthLeft = 0.5f;

                tablaDetalles.AddCell(valoresDetalles);
                //-- fIN codigo
                //--DETALLE
                valoresDetalles = new PdfPCell(new Paragraph(new Chunk(articulo, fuenteDetalle)));//----
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                    //valoresDetalles.BorderWidthBottom = 0.5f;
                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                //valoresDetalles.BorderWidthTop = 0;
                valoresDetalles.BorderWidthLeft = 0.5f;
                tablaDetalles.AddCell(valoresDetalles);
                //--FIN DETALLE

                //--UNID
                valoresDetalles = new PdfPCell(new Paragraph(new Chunk("", fuenteDetalle)));
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                    //valoresDetalles.BorderWidthBottom = 0.5f;
                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                valoresDetalles.BorderWidthLeft = 0.5f;
                tablaDetalles.AddCell(valoresDetalles);

                //FIN UNID


                //--CANTIDAD
                XmlNodeList QtyItem = xmlDetalles.GetElementsByTagName("QtyItem");
                int cantidad = 0;
                if (QtyItem.Count > 0)
                {
                    int.TryParse(QtyItem[0].InnerXml.ToString(), out cantidad);
                }
                valoresDetalles = new PdfPCell(new Paragraph(new Chunk(cantidad.ToString(), fuenteDetalle)));
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                valoresDetalles.BorderWidthTop = 0;
                valoresDetalles.BorderWidthLeft = 0.5f;
                tablaDetalles.AddCell(valoresDetalles);
                //--FIN CANTIDAD


                //--PRECIO UNITARIO
                valoresDetalles = new PdfPCell(new Paragraph(new Chunk(montoArticulo, fuenteDetalle)));
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                valoresDetalles.BorderWidthLeft = 0.5f;
                tablaDetalles.AddCell(valoresDetalles);
                //FIN PRECIO UNITARIO
                //--Descuento %
                using (XmlNodeList DescuentoPct = xmlDetalles.GetElementsByTagName("DescuentoPct"))
                {
                    int descuento = 0;
                    bool HayDescuentos = DescuentoPct.Count > 0;
                    if (HayDescuentos)
                    {
                        int.TryParse(DescuentoPct[0].InnerXml.ToString(), out descuento);
                    }
                    valoresDetalles = new PdfPCell(new Paragraph(new Chunk(descuento.ToString(), fuenteDetalle)));
                    if (i == Detalle.Count - 1)
                    {
                        valoresDetalles.BorderWidth = 0;
                    }
                    else
                    {
                        valoresDetalles.BorderWidth = 0;
                    }
                    valoresDetalles.BorderWidthLeft = 0.5f;
                    tablaDetalles.AddCell(valoresDetalles);
                }



                //FIN DESCUENTO

                //--Descuento $
                using (XmlNodeList DescuentoMonto = xmlDetalles.GetElementsByTagName("DescuentoMonto"))
                {
                    int descuento = 0;
                    bool HayDescuentosMonto = DescuentoMonto.Count > 0;
                    if (HayDescuentosMonto)
                    {
                        int.TryParse(DescuentoMonto[0].InnerXml.ToString(), out descuento);
                    }
                    valoresDetalles = new PdfPCell(new Paragraph(new Chunk(descuento.ToString(), fuenteDetalle)));
                    if (i == Detalle.Count - 1)
                    {
                        valoresDetalles.BorderWidth = 0;
                    }
                    else
                    {
                        valoresDetalles.BorderWidth = 0;
                    }
                    valoresDetalles.BorderWidthLeft = 0.5f;
                    tablaDetalles.AddCell(valoresDetalles);
                }



                //FIN DESCUENTO $


                //PRECIO ITEM
                valoresDetalles = new PdfPCell(new Paragraph(new Chunk((Convert.ToInt32(montoArticulo) * cantidad).ToString(), fuenteDetalle)));
                if (i == Detalle.Count - 1)
                {
                    valoresDetalles.BorderWidth = 0;
                    //valoresDetalles.BorderWidthBottom = 0.5f;

                }
                else
                {
                    valoresDetalles.BorderWidth = 0;
                }
                valoresDetalles.BorderWidthLeft = 0.5f;
                valoresDetalles.BorderWidthRight = 0.5f;
                //FIN PRECIO ITEM
                montoTotal += (Convert.ToInt32(montoArticulo) * cantidad);


                tablaDetalles.AddCell(valoresDetalles);
            }
            tablaDetalles = AgregarFilasVaciasDetalle(176, tablaDetalles);
            doc.Add(tablaDetalles);

            doc.Add(new Paragraph(" "));

            PdfPTable tablaCodigo = new PdfPTable(3);
            tablaCodigo.HorizontalAlignment = Element.ALIGN_CENTER;
            Paragraph parrafoCodigo = new Paragraph();
            PdfPCell cellCodigo = new PdfPCell();
            PdfPCell cellCodigo2 = new PdfPCell();


            Image imagen = Image.GetInstance(@"C:\Users\Desarrollo 02\Desktop\iTextSharp_cs_01.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);


            parrafoCodigo.Font = new Font(FontFactory.GetFont("Arial", 7));
            var fuenteDatos = new Font(FontFactory.GetFont("Arial", 7));
            var tablaDatosPersonales = new PdfPTable(new float[] { 35, 65 });
            tablaDatosPersonales.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("NOMBRE:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("________________:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("RUT:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("________________:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("RECINTO:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("________________:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("FECHA:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("________________:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("FIRMA:", fuenteDatos))) { BorderWidth = 0 });
            tablaDatosPersonales.AddCell(new PdfPCell(new Phrase(new Chunk("________________:", fuenteDatos))) { BorderWidth = 0 });

            parrafoCodigo.Add(tablaDatosPersonales);

            cellCodigo.AddElement(parrafoCodigo);

            tablaCodigo.AddCell(cellCodigo);
            var fuenteLetraChica = new Font(new Font(FontFactory.GetFont("Arial", 6, Font.NORMAL)));
            PdfPTable tablaCodigoBarra = new PdfPTable(1);
            tablaCodigoBarra.AddCell(new PdfPCell(imagen) { BorderWidth = 0 });
            tablaCodigoBarra.AddCell(new PdfPCell(new Paragraph("Tibre Electronico S.I.I", fuenteLetraChica)) { BorderWidth = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            tablaCodigoBarra.AddCell(new PdfPCell(new Paragraph("Res. 45 de 2014 - Verifique documento www.sii.cl", fuenteLetraChica)) { BorderWidth = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            tablaCodigo.AddCell(tablaCodigoBarra);


            var fuenteTotales = new Font(new Font(FontFactory.GetFont("Arial", 7, Font.NORMAL)));
            var fuenteTotalesNegritas = new Font(new Font(FontFactory.GetFont("Arial", 7, Font.BOLD)));
            PdfPTable tablaTotales = new PdfPTable(new float[] { 60, 40 });
            tablaTotales.HorizontalAlignment = Element.ALIGN_CENTER;

            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase("MONTO NETO", fuenteTotales)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(montoTotal.ToString(), fuenteTotalesNegritas)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase("MONTO IVA", fuenteTotales)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase((montoTotal * 0.19).ToString(), fuenteTotalesNegritas)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase("MONTO EXENTO", fuenteTotales)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase("0", fuenteTotalesNegritas)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase(Chunk.NEWLINE)) { BorderWidth = 0 });
            tablaTotales.AddCell(new PdfPCell(new Phrase("MONTO TOTAL", fuenteTotalesNegritas)) { BorderWidth = 0 });


            tablaTotales.AddCell(new PdfPCell(new Phrase((montoTotal + (montoTotal * 0.19)).ToString(), fuenteTotalesNegritas)) { BorderWidth = 0 });
            parrafoCodigo.Clear();



            cellCodigo2.AddElement(tablaTotales);
            //cellCodigo2.AddElement(parrafoCodigo);

            tablaCodigo.AddCell(cellCodigo2);



            doc.Add(tablaCodigo);
            doc.Add(new Paragraph(" "));
            //doc.Add(imagen);


            doc.Close();
            //-----------FIN CREAR DOCUMENTO
        }


        public static void CrearPDF417(string DD)
        {
            BarcodePDF417 pdf417 = new BarcodePDF417();
            pdf417.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            pdf417.ErrorLevel = 8;
            pdf417.Options = BarcodePDF417.PDF417_FORCE_BINARY;

            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            byte[] isoBytes = iso.GetBytes(DD);
            pdf417.Text = isoBytes;

            pdf417.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White).Save(@"C:\Users\Desarrollo 02\Desktop\iTextSharp_cs_01.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static PdfPTable AgregarFilasVaciasDetalle(int num, PdfPTable tabla)
        {
            int indiceLadoDerecho = 7;
            int numCols = 8;
            for (int i = 0; i < num; i++)
            {

                var celda = new PdfPCell(new Paragraph(Chunk.NEWLINE)) { BorderWidth = 0 };
                celda.BorderWidthLeft = 0.5f;
                if (i % indiceLadoDerecho == 0 && i != 0)
                {
                    celda.BorderWidthRight = 0.5f;
                    indiceLadoDerecho += numCols;
                }
                if (i >= (num - numCols))
                {
                    celda.BorderWidthBottom = 0.5f;
                }


                tabla.AddCell(celda);
            }
            return tabla;
        }
    }
}
