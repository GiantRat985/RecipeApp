
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeHtml : IRecipeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }
        public string Title { get; }
        public DateTime DateAdded { get; }
        public string Content { get; }
        public string UserNotes { get; }

        public RecipeHtml(string title, string content, string notes)
        {
            Title = title;
            Content = content;
            UserNotes = notes;
            DateAdded = DateTime.Now;
        }
    }
}
