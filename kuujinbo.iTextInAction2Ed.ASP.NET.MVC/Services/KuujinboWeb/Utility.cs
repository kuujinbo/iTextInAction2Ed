/*
 * This class is __NOT__ part of the book "iText in Action - 2nd Edition".
 */
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services
{
    public static class Utility
    {
        public static readonly string BaseDirectory;
        public static readonly string ResourceDirectory;

        // resource files
        public static string ResourceCalendar
        {
            get { return Path.Combine(ResourceDirectory, "calendar"); }
        }
        public static string ResourceEncryption
        {
            get { return Path.Combine(ResourceDirectory, "encryption"); }
        }
        public static string ResourceFonts
        {
            get { return Path.Combine(ResourceDirectory, "fonts"); }
        }
        public static string ResourceHtml
        {
            get { return Path.Combine(ResourceDirectory, "html"); }
        }
        public static string ResourceImage
        {
            get { return Path.Combine(ResourceDirectory, "img"); }
        }
        public static string ResourceJavaScript
        {
            get { return Path.Combine(ResourceDirectory, "js"); }
        }
        public static string ResourcePdf
        {
            get { return Path.Combine(ResourceDirectory, "pdf"); }
        }
        public static string ResourcePosters
        {
            get { return Path.Combine(ResourceDirectory, "posters"); }
        }
        public static string ResourceSwf
        {
            get { return Path.Combine(ResourceDirectory, "swf"); }
        }
        public static string ResourceText
        {
            get { return Path.Combine(ResourceDirectory, "txt"); }
        }
        public static string ResourceXml
        {
            get { return Path.Combine(ResourceDirectory, "xml"); }
        }

        //  initialize static member(s)
        static Utility()
        {
            HttpContext hc = HttpContext.Current;
            BaseDirectory = hc.Server.MapPath("~/");
            ResourceDirectory = Path.Combine(BaseDirectory, "resources");
                //StreamUtil.AddToResourceSearch(Path.Combine(
                //  BaseDirectory, "iTextAsian.dll"
                //));
        }

        /* ---------------------------------------------------------------------------
         * output files prefixed w/example chapter name dot class name:
         * ChapterXX.CLASSNAME
        */
        public static string ResultFileName(string fileName)
        {
            return Regex.Replace(
                fileName,
                // remove common namespace string
                typeof(Utility).Namespace,
                ""
            ) // remove leading dot
            .Substring(1);
        }

        public static byte[] PdfBytes(IWriter w)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                w.Write(ms);
                return ms.ToArray();
            }
        }

        public static bool IsHttpPost()
        {
            return HttpContext.Current.Request.HttpMethod == "POST";
        }

        public static string GetServerBaseUrl()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        }

        // get milliseconds for stringified time => 'hh:mm:ss'
        public static long GetMilliseconds(string hhmmss)
        {
            return (long)(
              DateTime.Parse("1970-01-01 " + hhmmss)
                //DateTime.Parse("1970-01-01 09:30:00")
              - DateTime.Parse("1970-01-01")
            ).TotalMilliseconds;
        }
    }
}