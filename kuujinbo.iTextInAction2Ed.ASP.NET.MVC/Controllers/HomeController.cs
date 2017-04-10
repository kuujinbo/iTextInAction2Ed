using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Helpers;
using kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GetExampleList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string ChapterList)
        {
            GetExampleList();
            var args = GetParams(ChapterList);
            Chapter c = new Chapter()
            {
                ChapterName = args[0], ExampleName = args[1]
            };
            if (c.IsValidChapterExample && (c.IsPdfResult || c.IsZipResult))
            {
                ViewBag.HasResults = true;
            }
            ViewBag.ShowResultLink = args;

            return View(model: GetSourceText(ChapterList));
        }

        public ActionResult SendResults(string chapter, string example)
        {
            Chapter c = new Chapter() {
                ChapterName = chapter, ExampleName = example
            };
            if (c.IsValidChapterExample && c.HasResult) {
                c.SendOutput();
                if (c.IsPdfResult) 
                {
                    return new PdfResult(c.GetResultName);
                }
                else 
                {
                    return new ZipResult(c.GetResultName);
                }
            }

            return RedirectToAction("Index");
        }
/*
    * ######################################################################
    * setting up the view
    * ######################################################################
*/
        const string CHAPTER = "ChapterName";
        const string EXAMPLE = "ExampleName";
        static string[] CHAPTERS = 
        {
            "Web Project Helper Classes (NOT part of book examples)", 
            "Filmfestival POJOs/Database Access", 
            "Introduction", 
            "Composing a document using iText's Basic Building Blocks",
            "Adding content at absolute positions",
            "Organizing content in tables",
            "Completing your layout using page and table events",
            "Working with existing PDFs",
            "Making documents interactive",
            "Filling out forms",
            "Integrate iText in your web applications",
            "Brighten up your PDF with images and color",
            "Choose the right font",
            "Protect your PDF",
            "PDF files inside-out",
            "The imaging model",
            "Marked content and parsing PDF",
            "PDF streams"
        };

        private static readonly List<SelectListItem> _chapters;
        private static readonly List<object> _disabled = new List<object>();

        // init <optgroup>. typical M$ - jump through rings of fire to do 
        // something as simple as creating <optgroup>
        static HomeController()
        {
            _chapters = new List<SelectListItem>();
            int index = 0;
            foreach (string chapter in Chapter.Examples.Keys)
            {
                foreach (string example in Chapter.Examples[chapter].Keys)
                {
                    var disabled = Chapter.Examples[chapter][example].Equals(
                        Chapter.OutputType.not_implemented
                    );
                    var text = example;
                    var value = string.Format("{0}-{1}", chapter, example);
                    if (disabled)
                    {
                        text = string.Format("{0} [not implemented]", example);
                        _disabled.Add(value);
                    }
                    _chapters.Add(new SelectListItem()
                    {
                        // Disabled = true, // typical M$ - this DOES NOT WORK
                        Group = new SelectListGroup()
                        {
                            Name = string.Format("{0}: {1}", chapter, CHAPTERS[index])
                        },
                        Text = text, Value = value
                    });
                }
                ++index;
            }
        }

        // set ViewBag for @Html.DropDownList
        private void GetExampleList()
        {
            ViewBag.ChapterList = new SelectList(
                _chapters, "Value", "Text", "Group.Name", null, _disabled
                //               WTF?!?! => ^^^^^^^^^^^^ 
            );
        }

        // get example source code file
        private string GetSourceText(string param)
        {
            var chapterExample = GetParams(param);
            return System.IO.File.ReadAllText(
                Path.Combine(
                    Server.MapPath("~/Services"), 
                    chapterExample[0],
                    string.Format("{0}.cs", chapterExample[1])
                )
            );
        }

        // sanity check chapter and example names
        private string[] GetParams(string dashString)
        {
            dashString = Regex.Replace(dashString, @"[^-\w]", "");
            return dashString.Split(new char[] {'-'}, 2);
        }
    }
}