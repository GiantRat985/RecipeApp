using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Base class for all parsers
    /// </summary>
    public abstract class HtmlDocumentParserBase : IHtmlDocumentParser
    {
        public abstract string? Parse(HtmlDocument content);

        /// <summary>
        /// Tries to parse an <see cref="HtmlDocument"/>
        /// </summary>
        /// <param name="content"><see cref="HtmlDocument"/> to parse</param>
        /// <param name="parsedData">parsed data as a <see langword="string"/></param>
        /// <returns><see langword="true"/> if parsing was successful</returns>
        public virtual bool TryParse(HtmlDocument content, out string? parsedData)
        {
            parsedData = Parse(content);
            return !string.IsNullOrWhiteSpace(parsedData);
        }
    }
}
