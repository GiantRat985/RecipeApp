
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp
{
    public class RecipeModelHtml : IRecipeModel
    {
        public DateTime DateAdded { get; }
        public string Content { get; }

        public RecipeModelHtml(string content)
        {
            Content = content;
            DateAdded = DateTime.Now;
        }
    }
}
