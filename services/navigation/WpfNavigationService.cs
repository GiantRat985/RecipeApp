using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace RecipeApp
{
    public class WpfNavigationService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Dictionary of all navigable pages from the main view
        /// </summary>
        public Dictionary<string, IPageViewModel> Pages { get; } = [];
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

        private IPageViewModel? _currentPageViewModel;
        private PageMediator _pageMediator;

        public WpfNavigationService(HomeViewModel homeViewModel, ImportViewModel importViewModel, 
            DisplayAllViewModel viewViewModel, EntityViewModel entityViewModel, 
            PageMediator pageMediator)
        {
            // Setup pages
            RegisterPage(homeViewModel);
            RegisterPage(importViewModel);
            RegisterPage(viewViewModel);
            RegisterPage(entityViewModel);
            // Open home page
            CurrentPageViewModel = homeViewModel;

            _pageMediator = pageMediator;
            _pageMediator.SubscribeAsync(MessageType.Navigation, ReceiveNavigationTarget);
        }

        public async Task NavigateTo(string pageID)
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

        private void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RegisterPage(IPageViewModel page)
        {
            Pages.Add(page.ID, page);
        }

        private async Task ReceiveNavigationTarget(object? message)
        {
            ArgumentNullException.ThrowIfNull(message);
            var ID = (string)message;
            if (!Pages.ContainsKey(ID))
            {
                throw new ArgumentException($"Page {message} does not exist.", nameof(message));
            }

            await NavigateTo(ID);
        }
    }
}
