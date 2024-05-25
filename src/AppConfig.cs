using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RecipeApp
{
    public static class AppConfig
    {
        public static Settings Settings { get; private set; } = new Settings();

        public static void LoadCongifuration(string path)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(path, optional: false, reloadOnChange: true)
               .Build();

            configuration.GetSection(Settings.Key).Bind(Settings);
        }
    }
}
