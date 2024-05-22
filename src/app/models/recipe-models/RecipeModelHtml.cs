
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp
{
    public class RecipeModelHtml : IRecipeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }
        public DateTime DateAdded { get; }
        public string Content { get; }

        public RecipeModelHtml(string content)
        {
            Content = content;
            DateAdded = DateTime.Now;
        }
    }
}
