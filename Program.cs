using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{

    internal class Program
    {
        public static double scale; //Variaable that can either be 0.5, 2, or 3 depending on the users choice
        public static List<RecipeClass> RecipeList = new List<RecipeClass>(); // list of recipes, mainly used for headings
        public static List<IngredientClass> IngredientsList = new List<IngredientClass>(); // list of ingredients
        public static List<StepClass> StepsList = new List<StepClass>(); //list of steps
        public static Dictionary<string, string> recipeDictionary = new Dictionary<string, string>(); // recipe dictionary
        public static string recipeDesc, ingredientsDesc, stepsDesc, fullDescription;
        public static string recipeName;
        public static double numberOfIngredients, numberOfSteps;
        public static string ingredientName, ingredientMeasurement, ingredientFoodGroup, unitOfMeasurement;
        public static double ingredientCalories, ingredientQuantity;
        public static string stepDescription;
        public static bool closeApp = false; // boolean that allows the app to keep running, the app will stop when this is true
        public static double totalCalories = 0; // total calories is calculated through iterations of adding ingredients
        static void Main(string[] args)
        {
            CalorieTracker ct = new CalorieTracker();
            ct.CaloriesExceeded += Tracker_CaloriesExceeded;






            while (closeApp == false)
            {

                Console.WriteLine("Recipe App menu:");

                Console.WriteLine("1) Enter a new recipe");

                Console.WriteLine("2) Display all recipes");

                Console.WriteLine("3) Display a specific recipe");

                Console.WriteLine("4) Close application");

                Console.Write("Please select an option: ");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        AddRecipe();

                        AddIngredient(ct);

                        AddStep();

                        DisplayRecipe();

                        ScaleUp();

                        ResetQuantities();

                        fullDescription = GenerateRecipeDescription();

                        StoreRecipe();

                        ClearData();

                        break;
                    case "2":
                        DisplayAllRecipes();
                        break;
                    case "3":

                        DisplayChosenRecipe();
                        break;
                    case "4":

                        Console.WriteLine("App shutting down...");
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }



        //Start of add step method
        static public void AddStep() //This method prompts the user for step details, stores them and passes them to the Step Class
        {
            Console.WriteLine("\nEnter details of each step");
            //string stepsDesc = "\nSteps: ";
            for (int i = 1; i <= numberOfSteps; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Step number " + i + ":");

                Console.Write("\nDescription: ");
                stepDescription = Console.ReadLine();

                StepsList.Add(new StepClass(i, stepDescription));
                //stepsDesc += "\n" +i + "\n" + stepDescription;
            }
            Console.WriteLine();

        }
        //End of add step method




        //Start of Add Ingredient method
        static public void AddIngredient(CalorieTracker ct) //This method prompts the user for ingredient details, stores them and passes them to the Ingredient Class
        {

            Console.WriteLine("\nEnter details of each ingredient");
            //string ingredientsDesc = "\nIngredients:";
            for (int i = 1; i <= numberOfIngredients; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Ingredient " + i + ":");

                Console.Write("\nName: ");
                ingredientName = Console.ReadLine();

                Console.Write("\nQuantity: ");
                ingredientQuantity = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nUnit of measurement: ");
                unitOfMeasurement = Console.ReadLine();

                Console.WriteLine("\nCalories: ");
                ingredientCalories = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nFood group: ");
                ingredientFoodGroup = Console.ReadLine();

                
                ct.AddCalories(ingredientCalories);
                

                IngredientsList.Add(new IngredientClass(ingredientName, ingredientQuantity, unitOfMeasurement, ingredientCalories, ingredientFoodGroup));


                totalCalories += ingredientCalories;

                

                
               

            }




        }
        //End of add ingredient method

        private static void Tracker_CaloriesExceeded(object sender, EventArgs e)
        {
            Console.WriteLine("Warning: Total calories have exceeded 300!");
        }



        //Start of add recipe method
        static public void AddRecipe() //This method prompts the user for recipe details, stores them and passes them to the Recipe Class
        {
            Console.WriteLine("Welcome to the Recipe App");

            Console.WriteLine("\nEnter details of the recipe");

            Console.WriteLine("\nRecipe name:");
            recipeName = Console.ReadLine();

            Console.WriteLine("Number of ingredients:");
            numberOfIngredients = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Number of steps:");
            numberOfSteps = Convert.ToDouble(Console.ReadLine());


            RecipeList.Add(new RecipeClass(recipeName, numberOfIngredients, numberOfSteps));

        }
        //End of add recipe method


        //Start of display recipe method
        static public void DisplayRecipe() //This method displays the entire recipe
        {
            //DisplayRecipe();
            foreach (var recipe in RecipeList)
            {
                Console.WriteLine($"{recipe.Name} - {recipe.NumberOfIng} ingredient(s) - {recipe.NumberOfSteps} step(s)");
            }
            Console.WriteLine();

            Console.WriteLine("\nList of ingredients:");
            foreach (var ingredient in IngredientsList)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            }
            Console.WriteLine();

            Console.WriteLine("\nList of steps:");
            foreach (var step in StepsList)
            {
                Console.WriteLine($"{step.StepNum}: {step.Desc}");
            }
            Console.WriteLine();

        }
        //End of display recipe method

        //Start of scale up method
        static public void ScaleUp() //This method asks the user if they would like to scale up the recipe by either 0.5, 2, or 3
        {

            Console.WriteLine("\nWould you like to scale up the recipe?\nEnter  y  for yes or  n  for no ");
            string userScaleInput = Console.ReadLine();
            int userScale;

            if (userScaleInput.Equals("y") || userScaleInput.Equals("Y"))
            {
                Console.WriteLine("\nYou can scale the Recipe by 0.5, 2 or 3\nPress \n1 for 0.5\n2 for 2\n3 for 3");
                userScale = Convert.ToInt32(Console.ReadLine());

                if (userScale == 1) { scale = 0.5; }
                if (userScale == 2) { scale = 2; }
                if (userScale == 3) { scale = 3; }

                for (int i = 0; i < IngredientsList.Count; i++)
                {
                    ((IngredientClass)IngredientsList[i]).Quantity *= scale;
                    ((IngredientClass)IngredientsList[i]).Calories *= scale;
                }
                Console.WriteLine("\n");
                DisplayRecipe();

            }
            else if (userScaleInput.Equals("n") || userScaleInput.Equals("N"))
            {

            }
        }
        //End of scale up method

        //Start of reset quantities method
        static public void ResetQuantities() //This method gives the user an option to reset ingredient quantities
        {

            //Reset quantities
            Console.WriteLine("\nWould you like to reset the ingredient quantities?\nEnter  y  for yes or  n  for no\n");
            string userResetInput = Console.ReadLine();
            if (userResetInput.Equals("y") || userResetInput.Equals("Y"))
            {
                for (int i = 0; i < IngredientsList.Count; i++)
                {
                    ((IngredientClass)IngredientsList[i]).Quantity /= scale;
                    ((IngredientClass)IngredientsList[i]).Calories /= scale;
                }

                DisplayRecipe();


            }
            else if (userResetInput.Equals("n") || userResetInput.Equals("N"))
            {

            }
        }
        //End of reset quantities method


        //Start of generate recipe description
        public static string GenerateRecipeDescription()
        {
            recipeDesc = recipeName + " - " + numberOfIngredients + "ingredient(s)" + " - " + numberOfSteps + " step(s)";
            foreach (var recipe in RecipeList)
            {
                Console.WriteLine($"{recipe.Name} - {recipe.NumberOfIng} ingredient(s) - {recipe.NumberOfSteps} step(s)");
            }


            ingredientsDesc = "\nIngredients:";
            foreach (var ingredient in IngredientsList)
            {
                ingredientsDesc += "\n" + ingredient.Quantity + "  " + ingredient.UnitOfMeasurement + " of " + ingredient.Name + "(" + ingredient.Calories + " calories)" + ingredient.FoodGroup;
            }


            stepsDesc = "\nSteps:";
            foreach (var step in StepsList)
            {
                stepsDesc += "\n" + step.StepNum + ". " + step.Desc;
            }
            string fullDesc = recipeDesc + ingredientsDesc + stepsDesc + "\n total calories = " + totalCalories;

            return fullDesc;
        }
        //End of generate recipe description


        //start of store recipe
        public static void StoreRecipe()
        {
            recipeDictionary.Add(recipeName, fullDescription);

        }
        //end of store recipe



        //Start of clear data method
        static public void ClearData() // This method gives the user an option to clear data and enter a new recipe
        {

            //Clear data
            Console.WriteLine("\nWould you like to clear all data and enter a new recipe?\nEnter  y  for yes or  n  for no\n");
            string userClearInput = Console.ReadLine();
            if (userClearInput.Equals("y") || userClearInput.Equals("Y"))
            {

                IngredientsList.Clear();
                RecipeList.Clear();
                StepsList.Clear();
                recipeDesc = "";
                ingredientsDesc = "";
                stepsDesc = "";
                fullDescription = "";
                totalCalories = 0;

            }
            else if (userClearInput.Equals("n") || userClearInput.Equals("N"))
            {
                Console.WriteLine("Press any key to exit the application");
                closeApp = true;
                Console.ReadKey();
            }

        }
        //End of clear data method

        static public void DisplayAllRecipes() // method that displays all recipes
        {
            Console.WriteLine("All recipes:");
            foreach (KeyValuePair<string, string> entry in recipeDictionary)
            {
                Console.WriteLine();
                Console.WriteLine($"Recipe name: {entry.Key}, \n {entry.Value}");
            }
            Console.WriteLine("All recipes:");


        }

        static void DisplayChosenRecipe() // method that displays a specific recipe based on the user's input
        {
            Console.Write("Enter the name of the recipe you want to display: ");
            string name = Console.ReadLine();

            if (recipeDictionary.TryGetValue(name, out string description))
            {
                Console.WriteLine($"Recipe: {name}");
                Console.WriteLine($"Description: {description}");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
//<summary>
//In the program class i have used methods to to not saturate the main method. 
//i created a menu that allows the user to choose which operation they would like to do.
//</summary>