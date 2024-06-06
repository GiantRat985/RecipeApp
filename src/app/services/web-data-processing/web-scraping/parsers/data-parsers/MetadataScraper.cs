using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class MetadataScraper
    {
        private readonly IMetadataParser[] _metadataParsers;
        public MetadataScraper()
        {
            _metadataParsers = [new TitleParser(), new AuthorParser()];
        }

        public RecipeMetadata ParseMetadata(HtmlDocument document)
        {
            var metadata = new RecipeMetadata();
            foreach (var parser in _metadataParsers)
            {
                parser.ParseMetadata(document, metadata);
            }
            return metadata;
        }
    }
}
