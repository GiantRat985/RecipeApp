using System.Windows;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using RecipeApp.src;

namespace RecipeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// <remarks>
    /// TODO: Need to change the db context to use the new recipe models
    /// </remarks>
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup config
            AppConfig.LoadCongifuration("appsettings.json");

            SetupServiceProvider();

            CreateDbContexts();

            var mainWindow = _serviceProvider!.GetService<MainWindow>();
            mainWindow!.Show();
        }

        private void SetupServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<MainWindow>()

                // Setup view models
                .AddScoped<MainViewModel>()
                .AddScoped<HomeViewModel>()
                .AddScoped<ImportViewModel>()
                
                // Setup dbcontext
                .AddTransient(sp => new RecipeAppDbContextFactory(AppConfig.Settings.DbConnectionString))

                // Setup services
                .AddScoped<IDataFetcher, DataFetcher>()
                .AddScoped<IScraper, ScraperService>()

                .AddScoped<INavigationService, WpfNavigationService>()

                // Setup view models
                .AddScoped<IPageViewModel, ImportViewModel>()
                ;
            
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void CreateDbContexts()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(AppConfig.Settings.DbConnectionString).Options;

            using RecipeAppDbContext context = new(options);
            context.Database.Migrate();
        }
    }
}
