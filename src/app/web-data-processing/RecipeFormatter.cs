using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CoreHtmlToImage;

namespace RecipeApp
{
    /// <summary>
    /// Handles formatting of a website's data for presentation
    /// </summary>
    public class RecipeFormatter
    {
        private HtmlConverter _converter;

        public RecipeFormatter(HtmlConverter converter)
        {
            _converter = converter;
        }

        public BitmapImage HtmlToImage(string html)
        {
            var imageArray = HtmlToByteArray(html);
            var image = LoadImage(imageArray);
            ArgumentNullException.ThrowIfNull(image);
            return image;
        }

        public byte[] HtmlToByteArray(string html)
        {
            return _converter.FromHtmlString(html);
        }

        public BitmapImage? ByteArrayToImage(byte[] imageData)
        {
            return LoadImage(imageData);
        }

        private BitmapImage? LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
