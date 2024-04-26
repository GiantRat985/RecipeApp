using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string CONNECTION_STRING = "Data Source=recipeapp.db";
        private IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CreateDbContexts();

            CreateServiceProvider();

            var mainWindow = _serviceProvider!.GetService<MainWindow>();
            mainWindow!.Show();
        }

        private void CreateServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<MainWindow>()

                .AddTransient<RecipeAppDbContextFactory>()
                ;
            
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void CreateDbContexts()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (RecipeAppDbContext context  = new RecipeAppDbContext(options))
            {
                context.Database.Migrate();
            }
        }
    }

}
