using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ReactjsHasar2.Services.PdfExport
{
    public interface IExportarPdfService
    {
        void DteToPdf(XmlDocument xmlDte);
    }
}
