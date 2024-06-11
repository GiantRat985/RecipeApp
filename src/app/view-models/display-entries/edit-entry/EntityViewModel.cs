using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Web.WebView2.Wpf;

namespace RecipeApp
{
    public class EntityViewModel : BaseViewModel
    {
        public override string Name => "View";
        public override string ID => nameof(EntityViewModel);
        public event EventHandler? EntityLoaded;

        public BitmapImage? RecipeImage
        {
            get => _recipeImage;
            set
            {
                if (value != _recipeImage)
                {
                    _recipeImage = value;
                    OnPropertyChanged();
                }
            }
        }

        private RecipeData? _data;
        private BitmapImage? _recipeImage;
        private RecipeFormatter _recipeFormatter;

        public EntityViewModel(RecipeData data, RecipeFormatter recipeFormatter)
        {
            _data = data;
            _recipeFormatter = recipeFormatter;
        }

        public override Task InitializeAsync()
        {
            ArgumentNullException.ThrowIfNull(_data, nameof(_data));
            ArgumentNullException.ThrowIfNull(_data.RecipeImage, nameof(_data));

            RecipeImage = _recipeFormatter.ByteArrayToImage(_data.RecipeImage);
            return Task.CompletedTask;
        }
    }
}
