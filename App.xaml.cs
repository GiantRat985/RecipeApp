using System.Windows;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using RecipeApp.src;
using AutoMapper;

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
                .AddTransient<ViewAllViewModel>()
                
                // Setup dbcontext
                .AddSingleton<RecipeAppDbContextFactory>(sp => new(AppConfig.Settings.DbConnectionString))

                // Setup services
                .AddScoped<IDataFetcher, DataFetcher>()
                .AddScoped<IScraper, ScraperService>()
                .AddScoped<WebProcessor>()
                .AddTransient<RecipeRepository>()
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
