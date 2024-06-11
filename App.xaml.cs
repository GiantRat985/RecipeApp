using System.Windows;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using RecipeApp.src;
using CoreHtmlToImage;

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
                // Setup dbcontext
                .AddSingleton<RecipeAppDbContextFactory>(sp => new(AppConfig.Settings.DbConnectionString))
                ;
            
            ConfigureServices(serviceCollection);
            ConfigureWebProcessing(serviceCollection);
            ConfigureViewModels(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<RecipeRepository>();
            services.AddSingleton<WpfNavigationService>();
            services.AddSingleton<PageMediator>();
            services.AddTransient<HtmlConverter>();
        }

        private void ConfigureWebProcessing(IServiceCollection services)
        {
            services
                .AddScoped<IDataFetcher, DataFetcher>()
                .AddScoped<ScraperService>()
                .AddScoped<WebProcessor>()
                .AddTransient<PrintPageExtractor>()
                .AddTransient<MetadataScraper>()
                .AddTransient<PrintNodeParser>()
                .AddTransient<RecipeFormatter>();
        }

        private void ConfigureViewModels(IServiceCollection services)
        {
            // Setup view models
            services
                .AddScoped<MainViewModel>()
                .AddScoped<HomeViewModel>()
                .AddTransient<ImportViewModel>()
                .AddTransient<DisplayAllViewModel>();
        }

        private void CreateDbContexts()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(AppConfig.Settings.DbConnectionString).Options;

            using RecipeAppDbContext context = new(options);
            context.Database.Migrate();
        }
    }
}
