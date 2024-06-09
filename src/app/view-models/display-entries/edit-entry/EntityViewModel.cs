using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;

namespace RecipeApp
{
    public class EntityViewModel : BaseViewModel
    {
        public override string Name => "View";
        public override string ID => nameof(EntityViewModel);
        public RecipeData? Data { get; private set; }
        public event EventHandler? EntityLoaded;
        public string? Url
        {
            get => _url;
            private set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _url;

        public EntityViewModel(RecipeData data)
        {
            Data = data;
        }

        private void ReceiveData(object? message)
        {
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            if (message is not RecipeData)
            {
                throw new ArgumentException($"Parameter {message} not of the correct type.");
            }

            var data = (RecipeData)message;
            Url = data.WebsiteUrl!;
            OnEntityLoaded();
        }

        private void OnEntityLoaded()
        {
            EntityLoaded?.Invoke(this, new EventArgs());
        }
    }
}
