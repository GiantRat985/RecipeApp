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
        /// <summary>
        /// Event member for the <see cref="INotifyPropertyChanged"/> interface
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Handles async initialization details
        /// Called each time the page is loaded
        /// </summary>
        /// <returns></returns>
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Event invocation for the <see cref="INotifyPropertyChanged"/> interface
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
