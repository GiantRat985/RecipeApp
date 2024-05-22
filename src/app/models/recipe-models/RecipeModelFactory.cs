using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class RecipeModelFactory : IModelFactory
    {
        public IRecipeModel CreateRecipeModel(string content)
        {
            IRecipeModel recipe = new RecipeModelHtml(content);

            return recipe;
        }
    }
}
