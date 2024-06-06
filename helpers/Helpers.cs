using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public static class Helpers
    {
        public static HtmlDocument LoadHtml(string content)
        {
            var document = new HtmlDocument();
            document.LoadHtml(content);
            return document;
        }
    }
}
