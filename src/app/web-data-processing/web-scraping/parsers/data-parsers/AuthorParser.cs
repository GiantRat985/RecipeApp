using HtmlAgilityPack;

namespace RecipeApp
{
    public class AuthorParser : IMetadataParser
    {
        public void ParseMetadata(HtmlDocument document, RecipeMetadata obj)
        {
            var authorNode = document.DocumentNode.SelectSingleNode("//head/meta[@name='author']");
            obj.Author = authorNode.GetAttributeValue("content", null);
        }
    }
}
