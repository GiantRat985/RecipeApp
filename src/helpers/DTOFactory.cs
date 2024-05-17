namespace RecipeApp
{
    public static class DTOFactory
    {
        public static RecipeDTO ConvertToDTO(RecipeHtml recipe)
        {
            return new RecipeDTO
            {
                ID = recipe.ID,
                Title = recipe.Title,
                
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
