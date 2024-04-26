using System.Windows;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string _connectionString = null!;
        private IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetupConfiguration();

            SetupServiceProvider();

            CreateDbContexts();

            var mainWindow = _serviceProvider!.GetService<MainWindow>();
            mainWindow!.Show();
        }

        #region Setup Methods

        private void SetupConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            IConfigurationRoot configuration = builder.Build();

            _connectionString = configuration.GetSection("AppSettings")["ConnectionString"]!;
        }

        private void SetupServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<MainWindow>()

                .AddTransient(sp => new RecipeAppDbContextFactory(_connectionString))
                ;
            
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void CreateDbContexts()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            using RecipeAppDbContext context = new(options);
            context.Database.Migrate();
        }
    }

    #endregion
}
