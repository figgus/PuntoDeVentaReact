
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.Models.ModelsDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReactjsHasar2.Clases
{
    public class DTEXML
    {
       // public Encabezado encabezado;
       // public Emisor emisor;
       // public Receptor receptor;
       // public List<Detalle> listaDetalles;
       //// public DescRecargos descRecargos;
       // public Referencia referencia;
       // public Subtotal subtotal;
       // public IdDoc idDoc;
       // public Totales totales;

       // public DTEXML()
       // {

       // }

       // //public XElement ToExelement<T>()
       // //{
       // //    XElement res = new XElement(typeof(T).Name);


       // //    return res;
       // //}

       // public XElement EmisorToXelem(Emisor emisor)
       // {
       //     XElement res = new XElement("Emisor", new XElement("RUTEmisor", emisor.RUTEmisor), new XElement("RznSoc", emisor.RznSoc),
       //         new XElement("GiroEmis", emisor.GiroEmis), new XElement("Acteco", emisor.Acteco),
       //         new XElement("CdgSIISucur", emisor.CdgSIISucur),
       //         new XElement("DirOrigen", emisor.DirOrigen),
       //         new XElement("CmnaOrigen", emisor.CmnaOrigen), new XElement("CiudadOrigen", emisor.CiudadOrigen));
       //     return res;

       // }

       // public XElement ReceptorToXelem(Receptor receptor)
       // {
       //     XElement res = new XElement("Receptor", new XElement("RUTRecep", receptor.RUTRecep), new XElement("RznSocRecep", receptor.RznSocRecep),
       //         new XElement("GiroRecep", receptor.GiroRecep), new XElement("DirRecep", receptor.DirRecep),
       //         new XElement("CmnaRecep", receptor.CmnaRecep),
       //         new XElement("CiudadRecep", receptor.CiudadRecep));
       //     return res;

       // }

       // public XElement DetallesToXElem(List<Detalle> detalles)
       // {
       //     XElement res = new XElement("");
       //     foreach (Detalle det in detalles)
       //     {
       //         res.AddAfterSelf(new XElement("Detalle", new XElement("NroLinDet", det.numeroLinea), new XElement("CdgItem", det.CodigoItem),
       //             new XElement("NmbItem", "no especificado"), new XElement("DirRecep", "no especificado"),
       //             new XElement("DscItem", det.DescripcionItem),
       //             new XElement("QtyItem", det.Cantidad),
       //             new XElement("PrcItem", det.MontoSinIva),
       //             new XElement("MontoItem", det.MontoConIva))
       //         );
       //     }

       //     return res;
       // }

       // public XElement DescRecargosToXelem(DescRecargos descRecargos)
       // {
       //     var res = new XElement("DscRcgGlobal");

       //     if (descRecargos.NroLinDR != 0)
       //     {
       //         res.Add(new XElement("NroLinDR", descRecargos.NroLinDR));
       //     }
       //     if (descRecargos.TpoMov != null)
       //     {
       //         res.Add(new XElement("TpoMov", descRecargos.TpoMov));
       //     }
       //     if (descRecargos.GlosaDR != null)
       //     {
       //         res.Add(new XElement("GlosaDR", descRecargos.GlosaDR));
       //     }
       //     if (descRecargos.TpoValor != null)
       //     {
       //         res.Add(new XElement("TpoValor", descRecargos.TpoMov));
       //     }
       //     if (descRecargos.ValorDR != 0)
       //     {
       //         res.Add(new XElement("ValorDR", descRecargos.ValorDR));
       //     }
       //     if (descRecargos.ValorDROtrMnda != 0)
       //     {
       //         res.Add(new XElement("ValorDROtrMnda", descRecargos.ValorDROtrMnda));
       //     }
       //     if (descRecargos.IndExeDR != 0)
       //     {
       //         res.Add(new XElement("IndExeDR", descRecargos.IndExeDR));
       //     }


       //     if (!res.HasElements)
       //     {
       //         return null;
       //     }
       //     return res;

       // }

       // public XElement ReferenciaToXelem(Referencia referencia)
       // {
       //     var res = new XElement("Referencia");

       //     if (referencia.NroLinRef != 0)
       //     {
       //         res.Add(new XElement("NroLinRef", referencia.NroLinRef));
       //     }
       //     if (referencia.TpoDocRef != null)
       //     {
       //         res.Add(new XElement("TpoDocRef", referencia.TpoDocRef));
       //     }
       //     if (referencia.IndGlobal != 0)
       //     {
       //         res.Add(new XElement("IndGlobal", referencia.IndGlobal));
       //     }
       //     if (referencia.FolioRef != null)
       //     {
       //         res.Add(new XElement("FolioRef", referencia.FolioRef));
       //     }
       //     if (referencia.RUTOtr != null)
       //     {
       //         res.Add(new XElement("RUTOtr", referencia.RUTOtr));
       //     }
       //     if (referencia.IdAdicOtr != null)
       //     {
       //         res.Add(new XElement("IdAdicOtr", referencia.IdAdicOtr));
       //     }
       //     if (referencia.FchRef != null)
       //     {
       //         res.Add(new XElement("FchRef", referencia.FchRef));
       //     }
       //     if (referencia.CodRef != 0)
       //     {
       //         res.Add(new XElement("CodRef", referencia.CodRef));
       //     }
       //     if (referencia.RazonRef != null)
       //     {
       //         res.Add(new XElement("RazonRef", referencia.RazonRef));
       //     }


       //     if (!res.HasElements)
       //     {
       //         return null;
       //     }
       //     return res;

       // }

       // public XElement SubtotalToXelem(Subtotal subtotal)
       // {
       //     var res = new XElement("SubTotal");
       //     if (subtotal.NroSTI != 0)
       //     {
       //         res.Add(new XElement("NroSTI", subtotal.NroSTI));
       //     }
       //     if (subtotal.GlosaSTI != null)
       //     {
       //         res.Add(new XElement("GlosaSTI", subtotal.GlosaSTI));
       //     }
       //     if (subtotal.SubTotNetoSTI != 0)
       //     {
       //         res.Add(new XElement("SubTotNetoSTI", subtotal.SubTotNetoSTI));
       //     }
       //     if (subtotal.SubTotIVASTI != 0)
       //     {
       //         res.Add(new XElement("SubTotIVASTI", subtotal.SubTotIVASTI));
       //     }
       //     if (subtotal.SubTotAdicSTI != 0)
       //     {
       //         res.Add(new XElement("SubTotAdicSTI", subtotal.SubTotAdicSTI));
       //     }
       //     if (subtotal.SubTotExeSTI != 0)
       //     {
       //         res.Add(new XElement("SubTotExeSTI", subtotal.SubTotExeSTI));
       //     }
       //     if (subtotal.ValSubtotSTI != 0)
       //     {
       //         res.Add(new XElement("ValSubtotSTI", subtotal.ValSubtotSTI));
       //     }
       //     if (subtotal.LineasDeta != 0)
       //     {
       //         res.Add(new XElement("LineasDeta", subtotal.LineasDeta));
       //     }

       //     if (!res.HasElements)
       //     {
       //         return null;
       //     }
       //     return res;

       // }

       // public XElement IdDocToXelem(IdDoc iddoc)
       // {
       //     var res = new XElement("IdDoc");
       //     if (iddoc.TipoDTE != 0)
       //     {
       //         res.Add(new XElement("TipoDTE", iddoc.TipoDTE));
       //     }
       //     if (iddoc.Folio != 0)
       //     {
       //         res.Add(new XElement("Folio", iddoc.Folio));
       //     }
       //     if (iddoc.FchEmis != null)
       //     {
       //         res.Add(new XElement("FchEmis", iddoc.FchEmis));
       //     }
       //     if (!res.HasElements)
       //     {
       //         return null;
       //     }
       //     return res;

       // }

       // //public string GenerarFirmaDigital(string RutaArchivo)
       // //{
       // //    string res = "";
       // //    var cert = X509Certificate.CreateFromSignedFile(RutaArchivo);
       // //    return res;
       // //}

       // public XElement TotalesToXelem(Totales totales)
       // {
       //     var res = new XElement("Totales");
       //     if (totales.MntNeto != null)
       //     {
       //         res.Add(new XElement("MntNeto", totales.MntNeto));
       //     }
       //     if (totales.TasaIVA != 0)
       //     {
       //         res.Add(new XElement("TasaIVA", totales.TasaIVA));
       //     }
       //     if (totales.IVA != 0)
       //     {
       //         res.Add(new XElement("IVA", totales.IVA));
       //     }
       //     if (totales.MntTotal != 0)
       //     {
       //         res.Add(new XElement("MntTotal", totales.MntTotal));
       //     }

       //     if (!res.HasElements)
       //     {
       //         return null;
       //     }
       //     return res;

       // }

       // public XDocument GetDTE()
       // {
       //     XDocument miXML = new XDocument(
       //         new XDeclaration("1.0", "utf-8", "yes"),
       //         new XElement("EnvioDTE",
       //         new XElement("SetDTE",
       //          new XElement("Caratula",
       //             new XElement("RutEmisor",
       //             encabezado.RUTEmisor),
       //             new XElement("RutEnvia"),
       //             new XElement("RutReceptor"),
       //             new XElement("FchResol", DateTime.Now),
       //             new XElement("NroResol"),
       //             new XElement("TmstFirmaEnv", DateTime.Now),
       //             new XElement("SubTotDTE",
       //                 new XElement("TpoDTE"),
       //                 new XElement("NroDTE")), new XAttribute("version", "1.0")),
       //          new XElement("DTE",
       //          new XElement("Documento",

       //                   new XElement("Encabezado",
       //                   idDoc,
       //                   new XElement(EmisorToXelem(emisor)),
       //                   new XElement(ReceptorToXelem(receptor)),
       //                   new XElement("Trasnporte", encabezado.Trasnporte),
       //                   TotalesToXelem(totales),
       //                   new XElement("VersionDTE", encabezado.VersionDTE))
       //              ,
       //               new XElement("Detalles", DetallesToXElem(listaDetalles)
       //                ), new XElement(SubtotalToXelem(subtotal)),
       //                     DescRecargosToXelem(new DescRecargos()),
       //                     ReferenciaToXelem(referencia),
       //                     new XElement("TED",
       //                         new XElement("DD",
       //                             new XElement("RE"),
       //                             new XElement("TD"),
       //                             new XElement("F"),
       //                             new XElement("FE"),
       //                             new XElement("RR"),
       //                             new XElement("RSR"),
       //                             new XElement("MNT"),
       //                             new XElement("ITE"),
       //                             new XElement("CAF", new XElement("DA",
       //                                 new XElement("RE"),
       //                                 new XElement("RS"),
       //                                 new XElement("TD"),
       //                                 new XElement("RNG", new XElement("H"), new XElement("D")),
       //                                 new XElement("FA"),
       //                                 new XElement("RSAPK", new XElement("M"), new XElement("E")),
       //                                 new XElement("IDK"))),
       //                             new XElement("TSTED"),
       //                             new XElement("FRMT", "carateres random", new XAttribute("algoritmo", "SHA1withRSA"))
       //                             )),
       //                     new XElement("TmstFirma", DateTime.Now), new XAttribute("version", "1.0")
       //                 )),
       //                 new XElement("Signature", new XElement("SignedInfo",
       //                     new XElement("CanonicalizationMethod", "", new XAttribute("Algorithm", "http://www.w3.org/TR/2001/REC-xml-c14n-20010315")),
       //                     new XElement("SignatureMethod", "", new XAttribute("Algorithm", "http://www.w3.org/2000/09/xmldsig#rsa-sha1")),
       //                     new XElement("Reference", ""),
       //                     new XElement("SignatureValue", "AxNuhGppcs1mTd6sXYGwy+etbKBlOqb")
       //                     ))

       //         ),//new XAttribute("xmlns", XNamespace.Get("http://www.sii.cl/SiiDte")),
       //             new XAttribute(XNamespace.Xmlns + "xsi", XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance")),
       //             new XAttribute(XNamespace.Xmlns + "schemaLocation", XNamespace.Get("http://www.sii.cl/SiiDte/EnvioDTE_v10.xsd")),
       //             new XAttribute("version", "1.0"))
       //     );

       //     return miXML;
       // }
    }
}
