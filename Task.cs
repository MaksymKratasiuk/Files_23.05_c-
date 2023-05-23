using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_23._05_c_
{
    internal class Task1
    {
        public static void task1()
        {
            RecipeManager recipeManager = new RecipeManager();

            // Додавання рецептів
            recipeManager.AddRecipe(new Recipe
            {
                Name = "Spaghetti Bolognese",
                Cuisine = "Italian",
                Ingredients = new List<string> { "Spaghetti", "Ground beef", "Tomato sauce", "Onion", "Garlic" },
                CookingTime = 30,
                Steps = new List<string> { "Cook spaghetti according to package instructions", "In a pan, brown ground beef with onion and garlic", "Add tomato sauce and simmer for 15 minutes", "Serve sauce over cooked spaghetti" },
                Calories = 500,
                DishType = "Main Course"
            });

            recipeManager.AddRecipe(new Recipe
            {
                Name = "Chicken Teriyaki",
                Cuisine = "Japanese",
                Ingredients = new List<string> { "Chicken breast", "Teriyaki sauce", "Soy sauce", "Honey", "Ginger" },
                CookingTime = 40,
                Steps = new List<string> { "Marinate chicken in teriyaki sauce, soy sauce, honey, and ginger", "Grill chicken until cooked through", "Serve with steamed rice and vegetables" },
                Calories = 400,
                DishType = "Main Course"
            });

            // Виведення всіх рецептів
            Console.WriteLine("All Recipes:");
            recipeManager.PrintRecipes();

            // Видалення рецепту
            recipeManager.RemoveRecipe(new Recipe
            {
                Name = "Chicken Teriyaki",
                Cuisine = "Japanese",
                Ingredients = new List<string> { "Chicken breast", "Teriyaki sauce", "Soy sauce", "Honey", "Ginger" },
                CookingTime = 40,
                Steps = new List<string> { "Marinate chicken in teriyaki sauce, soy sauce, honey, and ginger", "Grill chicken until cooked through", "Serve with steamed rice and vegetables" },
                Calories = 400,
                DishType = "Main Course"
            });

            // Виведення всіх рецептів після видалення
            Console.WriteLine("Recipes after deletion:");
            recipeManager.PrintRecipes();

            // Зміна рецепту
            recipeManager.UpdateRecipe( new Recipe
            {
                Name = "Chicken Teriyaki (Modified)",
                Cuisine = "Japanese",
                Ingredients = new List<string> { "Chicken breast", "Teriyaki sauce", "Soy sauce", "Honey", "Garlic" },
                CookingTime = 35,
                Steps = new List<string> { "Marinate chicken in teriyaki sauce, soy sauce, honey, and garlic", "Grill chicken until cooked through", "Serve with steamed rice and vegetables" },
                Calories = 400,
                DishType = "Main Course"
            }, "Chicken Teriyaki (Updated)", "Japanese", new List<string> { "Chicken breast", "Teriyaki sauce", "Soy sauce", "Honey", "Ginger", "Garlic" }, 40, new List<string> { "Marinate chicken in teriyaki sauce, soy sauce, honey, ginger, and garlic", "Grill chicken until cooked through", "Serve with steamed rice and vegetables" });



            // Виведення всіх рецептів після зміни
            Console.WriteLine("Recipes after update:");
            recipeManager.PrintRecipes();

            // Пошук рецепту за видом кухні
            Console.WriteLine("Search Recipes by Cuisine: Japanese");
            List<Recipe> japaneseRecipes = recipeManager.SearchByCuisine("Japanese");
            foreach (Recipe recipe in japaneseRecipes)
            {
                Console.WriteLine($"Name: {recipe.Name}");
                Console.WriteLine($"Cuisine: {recipe.Cuisine}");
                Console.WriteLine("Ingredients:");
                foreach (string ingredient in recipe.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine($"Cooking Time: {recipe.CookingTime} minutes");
                Console.WriteLine("Steps:");
                foreach (string step in recipe.Steps)
                {
                    Console.WriteLine(step);
                }
                Console.WriteLine($"Calories: {recipe.Calories}");
                Console.WriteLine($"Dish Type: {recipe.DishType}");
                Console.WriteLine();
            }



            // Збереження рецептів у файл
            recipeManager.SaveRecipesToFile("recipes.txt");

            // Завантаження рецептів з файлу
            recipeManager.LoadRecipesFromFile("recipes.txt");

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
