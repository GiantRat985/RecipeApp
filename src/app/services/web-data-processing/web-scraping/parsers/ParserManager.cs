using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class ParserManager : IEnumerable<IParser>
    {
        public List<IParser> Parsers { get; }

        public ParserManager()
        {
            Parsers = new List<IParser>
            {
                new ParserAction(),
                new ParserHref()
            };
        }

        public IEnumerator<IParser> GetEnumerator()
        {
            return Parsers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
