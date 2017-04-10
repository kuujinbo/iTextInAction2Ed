/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System.IO;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter06
{
    public class DataSheets2 : DataSheets1
    {
        public new const string RESULT = "datasheets2.pdf";

        public override void Write(Stream stream)
        {
            using (ZipFile zip = new ZipFile())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document document = new Document())
                    {
                        using (PdfSmartCopy copy = new PdfSmartCopy(document, ms))
                        {
                            document.Open();
                            AddDataSheets(copy);
                        }
                    }
                    zip.AddEntry(RESULT, ms.ToArray());
                }
                zip.AddFile(DATASHEET_PATH, "");
                zip.Save(stream);
            }
        }
    }
}