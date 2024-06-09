using System.Security.RightsManagement;

namespace RecipeApp
{
    public interface INavigationService
    {
        public Dictionary<string, IPageViewModel> PageViewModelDictionary { get; }
        public void NavigateTo(IPageViewModel control);
        public IPageViewModel? CurrentPageViewModel { get; }
    }
}
