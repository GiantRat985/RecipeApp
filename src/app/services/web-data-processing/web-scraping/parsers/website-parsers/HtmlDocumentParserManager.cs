using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    [Obsolete("Use PrintNodeParser instead.")]
    public class HtmlDocumentParserManager : IEnumerable<IHtmlDocumentParser>
    {
        public IHtmlDocumentParser[] PrintParsers { get; }

        public HtmlDocumentParserManager()
        {
            PrintParsers =
            [
                new ActionParser(),
                new HrefParser()
            ];
        }

        public IEnumerator<IHtmlDocumentParser> GetEnumerator()
        {
            return (IEnumerator<IHtmlDocumentParser>)PrintParsers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
