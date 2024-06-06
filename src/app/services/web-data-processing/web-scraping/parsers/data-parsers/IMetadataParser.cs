using HtmlAgilityPack;

namespace RecipeApp
{
    public interface IMetadataParser
    {
        public void ParseMetadata(HtmlDocument document, RecipeMetadata obj);
    }
}