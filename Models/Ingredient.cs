namespace Menu.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Connecting the class to the dishIngredient model
        public List<DishIngredient>? DishIngredients { get; set; };
    }
}
