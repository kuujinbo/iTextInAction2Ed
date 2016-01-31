/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System.IO;
/*
 * since the project can run under a web context __AND__ command line,
 * I chose to skip this. exercise for the end-user...
 */
namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter06
{
    public class MemoryInfo : IWriter
    {
        // ===========================================================================
        public void Write(Stream stream)
        {
            // TODO: implement stub
        }
        // ===========================================================================
    }
}