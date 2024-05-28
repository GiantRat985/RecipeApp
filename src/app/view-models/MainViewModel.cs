using System.Security.Permissions;
using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeApp
{
    public class MainViewModel : BaseViewModel
    {
        private IPageViewModel? _currentPageViewModel;

        public override string Name { get; } = "Main";
        public override string ID { get; } = nameof(MainViewModel);
        /// <summary>
        /// Dictionary of all navigable pages from the main view
        /// </summary>
        public Dictionary<string, IPageViewModel> Pages { get; } = [];

        public ICommand ChangeViewCommand { get; }

        public IPageViewModel? CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                }
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public MainViewModel(HomeViewModel homeViewModel, ImportViewModel importViewModel)
        {
            // Setup navigation command
            ChangeViewCommand = new RelayCommand(ExecuteNavigateCommand, CanExecuteNavigateCommand);

            // Setup pages
            RegisterPage(homeViewModel);
            RegisterPage(importViewModel);

            // Open home page
            NavigateTo(homeViewModel.ID);
        }

        private void RegisterPage(IPageViewModel page)
        {
            Pages.Add(page.ID, page);
        }

        private void NavigateTo(string pageID)
        {
            if (!Pages.ContainsKey(pageID))
            {
                throw new NullReferenceException();
            }
            CurrentPageViewModel = Pages
                .GetValueOrDefault(pageID)!;
        }

        private void ExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            NavigateTo((string)param);
        }

        private bool CanExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            // Return true if the intended navigation target is not already the current view
            return param != CurrentPageViewModel;
        }
    }
}
