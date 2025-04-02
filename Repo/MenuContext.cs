using Menu.Models;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Repo

{
    public class MenuContext : DbContext //Add DbContext
    {
        // 1. By Default every Context class need this constructor
        public MenuContext (DbContextOptions<MenuContext> options):base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)

        {
            //2. Creating relationship bettwen both the dishId and IngredientId
            modelbuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishID,
                di.IngredientId
            });

            //4. One Dish is  connected to Many DishIngredients ingredient with a foreign Key of IngredientId
            modelbuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishID);
            //5. One Ingredient is connected to Many Dishingredients with a foreign Key of IngredientId
            modelbuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            //7. Adding data into the database

            modelbuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Margherita ",
                    Price = 59,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0274/9503/9079/files/20220211142754-margherita-9920_5a73220e-4a1a-4d33-b38f-26e98e3cd986.jpg?v=1723650067"

                }
                );

            modelbuilder.Entity<Ingredient>().HasData(
                new Ingredient
{
                    Id=1,
                    Name="Black paper",
                    
                },
                 new Ingredient
                 {
                     Id = 2,
                     Name = "Tomato Saunce",

                 }
                );

            modelbuilder.Entity<DishIngredient>().HasData(
                new DishIngredient
                {
                    DishID = 1,
                    IngredientId = 1,
                },
                 new DishIngredient
                 {
                     DishID = 1,
                     IngredientId = 2,
                 }
                );

            //3.base.OnModelCreating(modelbuilder);
        }
            //6. Create DbSet instance for each model we have created 
            public DbSet<Dish> Dishes { get; set; }
            public DbSet<Ingredient> Ingredients { get; set; }
            public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
