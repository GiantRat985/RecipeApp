using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RecipeApp
{
    public class DisplayAllViewModel : BaseViewModel
    {
        public override string Name => "View All";
        public override string ID => nameof(DisplayAllViewModel);
        public ObservableCollection<RecipeData>? RecipeDataList { get => _recipeDataList; set => _recipeDataList = value; }
        public ICommand OpenEntityCommand { get; }
        public ICommand DeleteCommand { get; }
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

        private readonly RecipeFormatter _formatter;
        private readonly RecipeRepository _recipeRepository;
        private BaseViewModel? _selectedEntity;
        private ObservableCollection<RecipeData>? _recipeDataList;

        public DisplayAllViewModel(RecipeRepository repository, RecipeFormatter formatter)
        {
            _recipeRepository = repository;
            _formatter = formatter;

            OpenEntityCommand = new RelayCommand(ExecuteOpenSelected, p => true);
            DeleteCommand = new RelayCommandAsync(ExecuteDeleteCommand, p => true);
        }

        public override async Task InitializeAsync()
        {
            var databaseData = await _recipeRepository.GetAllAsync();
            SelectedEntity = this;
            RecipeDataList = new ObservableCollection<RecipeData>(databaseData);
        }

        private void ExecuteOpenSelected(object? arg)
        {
            ArgumentNullException.ThrowIfNull(arg, nameof(arg));
            SelectedEntity = new EntityViewModel((RecipeData)arg, _formatter);
            try
            {
                SelectedEntity.InitializeAsync();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Unable to load {ex.ParamName}. {ex.Message}");
            }
        }

        private async Task ExecuteDeleteCommand(object? parameter)
        {
            ArgumentNullException.ThrowIfNull(parameter, nameof(parameter));
            if (parameter is not RecipeData)
            {
                throw new ArgumentException($"Object of type {nameof(RecipeData)} expected. Parameter '{nameof(parameter)}' not valid.");
            }
            RecipeData data = (RecipeData)parameter;
            await _recipeRepository.DeleteAsync(data.ID);
            RecipeDataList!.Remove(data);
        }
    }
}
