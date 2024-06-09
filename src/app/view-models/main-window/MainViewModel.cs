using System.Security.Permissions;
using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeApp
{
    public class MainViewModel : BaseViewModel
    {

        public override string Name { get; } = "Main";
        public override string ID { get; } = nameof(MainViewModel);
        public ICommand ChangeViewCommand { get; }

        public WpfNavigationService NavigationService { get; }

        public MainViewModel(WpfNavigationService navigationService)
        {
            // Setup navigation command
            ChangeViewCommand = new RelayCommandAsync(ExecuteNavigateCommand, CanExecuteNavigateCommand);
            
            NavigationService = navigationService;
        }

        private async Task ExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            await NavigationService.NavigateTo((string)param);
        }

        private bool CanExecuteNavigateCommand(object? param)
        {
            ArgumentNullException.ThrowIfNull(param);

            // Return true if the intended navigation target is not already the current view
            return (string)param != NavigationService.CurrentPageViewModel!.ID;
        }
    }
}
