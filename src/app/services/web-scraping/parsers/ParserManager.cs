using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class ParserManager : IEnumerable<IParserAsync>
    {
        public List<IParserAsync> Parsers { get; }

        public ParserManager(IDataFetcher dataFetcher)
        {
            Parsers = new List<IParserAsync>
            {
                new ActionParser(dataFetcher),
                new HrefParser(dataFetcher)
            };
        }

        public IEnumerator<IParserAsync> GetEnumerator()
        {
            return Parsers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
