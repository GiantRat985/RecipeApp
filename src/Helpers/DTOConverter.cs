namespace RecipeApp
{
    public static class DTOConverter
    {
        public static RecipeDTO ConvertToDTO(IRecipe recipe)
        {
            return new RecipeDTO
            {
                ID = recipe.ID,
                Title = recipe.Title,
                URL = recipe.URL,
                Description = recipe.Description,
                Body = recipe.Body,
                Thumbnail = recipe.Thumbnail,
            };
        }

        public static RecipeDTO CreateEmptyDTO(int id)
        {
            return new RecipeDTO
            {
                ID = id,
                Title = ""
            };
        }
    }
}
