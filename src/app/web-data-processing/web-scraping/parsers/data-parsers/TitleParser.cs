using HtmlAgilityPack;

namespace RecipeApp
{
    public class TitleParser : IMetadataParser
    {
        public void ParseMetadata(HtmlDocument document, RecipeMetadata obj)
        {
            obj.Title = document.DocumentNode.SelectSingleNode("//head/title[1]").InnerText;
        }
    }
}
