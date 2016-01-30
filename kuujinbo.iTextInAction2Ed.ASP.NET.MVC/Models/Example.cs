using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Models
{
    public class Example
    {
        public string Chapter { get; set; }
        public string Source { get; set; }

        public IEnumerable<Example> GetExamples()
        {
            return new List<Example>()
            {
                new Example { Chapter = "0", Source = "00" },
                new Example { Chapter = "0", Source = "01" },
                new Example { Chapter = "1", Source = "00" },
                new Example { Chapter = "1", Source = "01" },
            };
        }
    }
}