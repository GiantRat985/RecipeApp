using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RecipeApp
{
    public class ImportViewModel : BaseViewModel
    {
        public override string ID { get; } = nameof(ImportViewModel);
        public override string Name { get; } = "Import";
        public ICommand ImportCommand { get; }

        private bool _commandBusy;
        private readonly WebProcessor _webProcessor;
        private string _mainUrl = "";
        public string MainUrl
        {
            get => _mainUrl;
            set
            {
                if (value != _mainUrl)
                {
                    _mainUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public ImportViewModel(WebProcessor webProcessor)
        {
            _webProcessor = webProcessor;

            // Initialize commands
            ImportCommand = new RelayCommandAsync(ExecuteImport, CanExecuteImport);
        }

        private bool CanExecuteImport(object? obj)
        {
            // Cannot execute if the main url field is empty.
            return !string.IsNullOrWhiteSpace(MainUrl) && _commandBusy == false;
        }

        private async Task ExecuteImport(object? obj)
        {
            try
            {
                _commandBusy = true;
                await _webProcessor.Process(MainUrl);
                MessageBox.Show("Successfully imported recipe.");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to import recipe.");
            }
            finally
            {
                _commandBusy = false;
            }
        }
    }
}
