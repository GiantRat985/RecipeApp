using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeApp
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IPageViewModel
    {
        /// <summary>
        /// Name of the view model, used for display in UI
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// ID of the view model, uesd for lookup in dictionary
        /// </summary>
        public abstract string ID { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
