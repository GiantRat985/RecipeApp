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

        public MainViewModel(HomeViewModel homeViewModel, ImportViewModel importViewModel, ViewAllViewModel viewViewModel)
        {
            // Setup navigation command
            ChangeViewCommand = new RelayCommandAsync(ExecuteNavigateCommand, CanExecuteNavigateCommand);

            // Setup pages
            RegisterPage(homeViewModel);
            RegisterPage(importViewModel);
            RegisterPage(viewViewModel);

            // Open home page
            CurrentPageViewModel = homeViewModel;
        }

        private void RegisterPage(IPageViewModel page)
        {
            Pages.Add(page.ID, page);
        }

        private async Task NavigateTo(string pageID)
        {
            if (!Pages.ContainsKey(pageID))
            {
                throw new NullReferenceException();
            }
            var currentPage = Pages
                .GetValueOrDefault(pageID)!;

            CurrentPageViewModel = currentPage;
            await currentPage.InitializeAsync();
        }

        private async Task ExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            await NavigateTo((string)param);
        }

        private bool CanExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            // Return true if the intended navigation target is not already the current view
            return param != CurrentPageViewModel;
        }
    }
}
