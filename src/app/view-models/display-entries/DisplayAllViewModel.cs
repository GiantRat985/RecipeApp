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
        public BaseViewModel? SelectedEntity { get => _selectedEntity;
            set
            {
                if (_selectedEntity != value)
                {
                    _selectedEntity = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly RecipeRepository _recipeRepository;
        private BaseViewModel? _selectedEntity;

        public DisplayAllViewModel(RecipeRepository repository, PageMediator mediator)
        {
            _recipeRepository = repository;
            SelectedEntity = this;

            OpenEntityCommand = new RelayCommand(ExecuteOpenSelected, p => true);
        }

        public override async Task InitializeAsync()
        {
            var databaseData = await _recipeRepository.GetAllAsync();
            RecipeDataList = databaseData;
        }

        private void ExecuteOpenSelected(object? arg)
        {
            ArgumentNullException.ThrowIfNull(arg, nameof(arg));
            SelectedEntity = new EntityViewModel((RecipeData)arg);
        }
    }
}
