using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class RecordFormatterBase : IRecordFormatter<RecipeRecordBase>
    {
        public RecipeRecordBase FormatRecipeData(IRecipeModel recipe)
        {
            var record = new RecipeRecordBase
            {
                DateAdded = recipe.DateAdded,
                Content = recipe.Content,
            };
            return record;
        }
    }
}
