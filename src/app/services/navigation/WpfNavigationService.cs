using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeApp
{
    [Obsolete("This class is obsolete. Navigation should be handled in the main view model for now.")]
    public class WpfNavigationService : INavigationService, INotifyPropertyChanged
    {
        private IPageViewModel? _currentPageViewModel;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Dictionary<string, IPageViewModel> PageViewModelDictionary { get; } = [];
        public IPageViewModel? CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (value != _currentPageViewModel)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }

        public WpfNavigationService(IPageViewModel importViewModel)
        {
            RegisterPage(importViewModel);
        }

        public void NavigateTo(IPageViewModel page)
        {
            if (!PageViewModelDictionary.ContainsKey(page.ID))
            {
                throw new NullReferenceException();
            }
            CurrentPageViewModel = PageViewModelDictionary
                .GetValueOrDefault(page.ID)!;
        }

        private void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RegisterPage(IPageViewModel page)
        {
            PageViewModelDictionary.Add(page.ID, page);
        }
    }
}
