using System.Web;
using System.Web.Mvc;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Helpers
{
    public class PdfResult : FileResult
    {
        public PdfResult(string fileDownloadName)
            : base("application/pdf")
        {
            this.FileDownloadName = fileDownloadName;
        }

        protected override void WriteFile(HttpResponseBase response) { }
    }
}