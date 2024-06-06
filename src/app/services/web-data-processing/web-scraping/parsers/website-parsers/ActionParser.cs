using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    [Obsolete("Use PrintNodeParser instead.")]
    /// <summary>
    /// Parser using print node based searching. Attempts to find the hyperlink in the action attribute of the print button on a web page.
    /// </summary>
    public class ActionParser : PrintNodeParser
    {
        private const string actionNode = "action";

        public override string? Parse(HtmlDocument content)
        {
            // Parses data for a print button.
            var printNodes = FindPrintNodes(content);

            // Parses print button node for the print page link.
            var hyperlink = FindNodeWithAction(printNodes);
            return hyperlink;
        }


        /// <summary>
        /// Attempts to extract the print page hyperlink from the action attribute in the given nodes.
        /// </summary>
        /// <param name="nodes">Collection of nodes to parse</param>
        /// <returns>the recipe's hyperlink <see cref="string"/> or null if parsing is unsuccessful.</returns>
        private string? FindNodeWithAction(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                var action = node.GetAttributeValue(actionNode, null);
                if (!string.IsNullOrEmpty(action))
                {
                    if (ValidateLink(action))
                    {
                        return action;

                    }
                }
            }
            return null;
        }
    }
}
