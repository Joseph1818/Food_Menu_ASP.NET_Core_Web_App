﻿namespace Menu.Models
{
    public class DishIngredient
    {
        public int DishID { get; set; }
        public Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }


    }

}
