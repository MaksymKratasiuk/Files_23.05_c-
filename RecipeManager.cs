using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_23._05_c_
{
    class RecipeManager
    {
        public List<Recipe> recipes { get; set; }

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        public void UpdateRecipe(Recipe recipe, string newName, string newCuisine, List<string> newIngredients, int newCookingTime, List<string> newSteps)
        {
            recipe.Name = newName;
            recipe.Cuisine = newCuisine;
            recipe.Ingredients = newIngredients;
            recipe.CookingTime = newCookingTime;
            recipe.Steps = newSteps;
        }

        public List<Recipe> SearchByCuisine(string cuisine)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Cuisine == cuisine)
                {
                    matchingRecipes.Add(recipe);
                }
            }
            return matchingRecipes;
        }

        // Додаткові методи для пошуку за іншими характеристиками рецептів

        public void SaveRecipesToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (Recipe recipe in recipes)
                {
                    writer.WriteLine(recipe.Name);
                    writer.WriteLine(recipe.Cuisine);
                    writer.WriteLine(recipe.CookingTime);

                    foreach (string ingredient in recipe.Ingredients)
                    {
                        writer.WriteLine(ingredient);
                    }

                    foreach (string step in recipe.Steps)
                    {
                        writer.WriteLine(step);
                    }

                    writer.WriteLine(); // Роздільник між рецептами
                }
            }
        }

        public void LoadRecipesFromFile(string filePath)
        {
            recipes.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string name = reader.ReadLine();
                    string cuisine = reader.ReadLine();
                    int cookingTime = int.Parse(reader.ReadLine());

                    List<string> ingredients = new List<string>();
                    string ingredient = reader.ReadLine();
                    while (!string.IsNullOrWhiteSpace(ingredient))
                    {
                        ingredients.Add(ingredient);
                        ingredient = reader.ReadLine();
                    }

                    List<string> steps = new List<string>();
                    string step = reader.ReadLine();
                    while (!string.IsNullOrWhiteSpace(step))
                    {
                        steps.Add(step);
                        step = reader.ReadLine();
                    }

                    Recipe recipe = new Recipe
                    {
                        Name = name,
                        Cuisine = cuisine,
                        CookingTime = cookingTime,
                        Ingredients = ingredients,
                        Steps = steps
                    };

                    recipes.Add(recipe);
                }
            }
        }

        public void GenerateReportByCuisine(string cuisine)
        {
            List<Recipe> matchingRecipes = SearchByCuisine(cuisine);
            PrintRecipes();
        }

        public void GenerateReportByCookingTime(int maxCookingTime)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.CookingTime <= maxCookingTime)
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void GenerateReportByIngredient(string ingredient)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Ingredients.Contains(ingredient))
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void GenerateReportByName(string name)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Name.Contains(name))
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void GenerateReportByCalories(int maxCalories)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Calories <= maxCalories)
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void GenerateReportByDishType(string dishType)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.DishType == dishType)
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void GenerateReportByCombinationOfDishTypes(List<string> dishTypes)
        {
            List<Recipe> matchingRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                bool containsAllDishTypes = true;
                foreach (string dishType in dishTypes)
                {
                    if (!recipe.DishType.Contains(dishType))
                    {
                        containsAllDishTypes = false;
                        break;
                    }
                }
                if (containsAllDishTypes)
                {
                    matchingRecipes.Add(recipe);
                }
            }
            PrintRecipes();
        }

        public void PrintRecipes()
        {
            foreach (var recipe in recipes)
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
        }
    }

}
