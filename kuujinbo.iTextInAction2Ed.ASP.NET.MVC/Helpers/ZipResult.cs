using System.Web;
using System.Web.Mvc;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Helpers
{
    public class ZipResult : FileResult
    {
        public ZipResult(string fileDownloadName)
            : base("application/zip")
        {
            this.FileDownloadName = fileDownloadName;
        }

        protected override void WriteFile(HttpResponseBase response) { }
    }
}