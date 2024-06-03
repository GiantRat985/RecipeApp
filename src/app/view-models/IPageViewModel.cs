using System.Runtime.CompilerServices;

namespace RecipeApp
{
    public interface IPageViewModel
    {
        /// <summary>
        /// Name of the view model, used for display in UI
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// ID of the view model, uesd for lookup in dictionary
        /// </summary>
        public string ID { get; }
        /// <summary>
        /// Initializes the viewmodel as an asynchronous operation
        /// </summary>
        public Task InitializeAsync();
    }
}
