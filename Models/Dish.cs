namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public double Price { get; set; }

        //Connecting the class to the dish ingredient monde
        public List<DishIngredient> ? DishIngredients { get; set; }
    }
}
