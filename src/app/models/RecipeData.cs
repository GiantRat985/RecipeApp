
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    /// <summary>
    /// Data container for recipe information.
    /// </summary>
    [PrimaryKey(nameof(ID))]
    public class RecipeData
    {
        /// <summary>
        /// Database primary key
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }
        /// <summary>
        /// The date a recipe was added to the database
        /// </summary>
        public DateTime? DateAdded { get; set; }
        /// <summary>
        /// Html content of recipe page
        /// </summary>
        public string? HtmlContent { get; set; }
        /// <summary>
        /// Website input url <see langword="string"/>
        /// </summary>
        public string? WebsiteUrl { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }

        public RecipeData()
        {
            if (DateAdded == null)
            { 
                DateAdded = DateTime.Today;
            }
        }
    }
}
