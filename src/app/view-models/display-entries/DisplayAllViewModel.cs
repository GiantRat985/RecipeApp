using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeApp
{
    public class DisplayAllViewModel : BaseViewModel
    {
        public override string Name => "View All";
        public override string ID => nameof(DisplayAllViewModel);
        public IEnumerable<RecipeData> RecipeDataList { get; set; } = [];
        public ICommand OpenEntityCommand { get; }

        private readonly PageMediator _mediator;
        private readonly RecipeRepository _recipeRepository;

        public DisplayAllViewModel(RecipeRepository repository, PageMediator mediator)
        {
            _recipeRepository = repository;
            _mediator = mediator;

            OpenEntityCommand = new RelayCommandAsync(ExecuteOpenSelected, CanExecuteOpenSelected);
        }

        public override async Task InitializeAsync()
        {
            var databaseData = await _recipeRepository.GetAllAsync();
            RecipeDataList = databaseData;
        }

        public void SendSelectedRecipe(RecipeData data)
        {
            _mediator.Publish(MessageType.Data, data);
        }

        private async Task ExecuteOpenSelected(object? arg)
        {
            // Sends the selected item to open in the new page
            _mediator.Publish(MessageType.Data, arg);
            // Sends message to navigate to the "view" page
            await _mediator.PublishAsync(MessageType.Navigation, "EntityViewModel");
        }

        private bool CanExecuteOpenSelected(object? arg)
        {
            return true;
        }
    }
}
