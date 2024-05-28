using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeApp
{
    public class ImportViewModel : BaseViewModel
    {
        public override string ID { get; } = nameof(ImportViewModel);
        public override string Name { get; } = "Import";
        public ICommand ImportCommand { get; }
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

        private readonly IScraper _scraper;

        public ImportViewModel(IScraper scraper)
        {
            _scraper = scraper;

            // Initialize commands
            ImportCommand = new RelayCommandAsync(ExecuteImport, CanExecuteImport);
        }

        private bool CanExecuteImport(object? obj)
        {
            // Cannot execute if the main url field is empty.
            return !string.IsNullOrWhiteSpace(MainUrl);
        }

        private async Task ExecuteImport(object? obj)
        {
            await _scraper.ScrapeWebPageAsync(MainUrl);
        }
    }
}
