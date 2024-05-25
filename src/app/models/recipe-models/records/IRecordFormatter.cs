using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IRecordFormatter<T> where T : RecipeRecordBase
    {
        public T FormatRecipeData(IRecipeModel recipe);
    }
}
