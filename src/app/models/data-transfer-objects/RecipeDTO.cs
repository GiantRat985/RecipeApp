using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp
{
    public class RecipeDTO : IRecipeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public string? URL { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
