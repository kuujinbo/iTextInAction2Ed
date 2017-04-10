/*
 * This class is __NOT__ part of the book "iText in Action - 2nd Edition".
*/
using System.IO;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services
{
    public interface IWriter
    {
        void Write(Stream stream);
    }
}