using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Media;
using System.IO;

namespace RecipeApp
{
    
    internal class Program
    {
        public static double scale; //Variaable that can either be 0.5, 2, or 3 depending on the users choice
        public static string ingredientName, unitOfMeasurement; // Variables passed to IngredientClass 
        public static double ingredientQuantity;                //
        public static string recipeName; // Variable passed to recipe List
        public static double numberOfIngredients; // Variable that stores the amount of times a user will add an ingredient
        public static double numberOfSteps; // Variable that stores the amount of times a user will add a step
        public static ArrayList IngredientsList = new ArrayList(); // Arraylist that stores ingredient objects
        public static ArrayList StepsList = new ArrayList(); // Arraylist that stores step objects
        public static bool closeApp = false; // boolean that allows the app to keep running, the app will stop when this is true
        public static string recipeOutput; // this variable stores the output from the add recipe method


        static void Main(string[] args)
        {
            while (closeApp == false)
            {

                //Calling methods
                StartSong("recipe.wav");
                AddRecipe();
                AddIngredient();
                AddStep();
                DisplayRecipe();
                ScaleUp();
                ResetQuantities();
                ClearData();
            }
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

            RecipeClass recipe = new RecipeClass(recipeName, numberOfIngredients, numberOfSteps);
            recipeOutput = recipe.RecipeDec();
        }
        //End of add recipe method




        //Start of Add Ingredient method
        static public void AddIngredient() //This method prompts the user for ingredient details, stores them and passes them to the Ingredient Class
        {
            

            Console.WriteLine("\nEnter details of each ingredient");
            for (int i = 1; i <= numberOfIngredients; i++)
            {

                Console.WriteLine("Ingredient " + i + ":");
                Console.WriteLine("\nName: ");
                ingredientName = Console.ReadLine();

                Console.WriteLine("\nQuantity: ");
                ingredientQuantity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nUnit of measurement: ");
                unitOfMeasurement = Console.ReadLine();

                IngredientsList.Add(new IngredientClass(ingredientName, ingredientQuantity, unitOfMeasurement));
            }
            
            
        }
        //End of add ingredient method





        //Start of add step method
        static public void AddStep() //This method prompts the user for step details, stores them and passes them to the Step Class
        {
            
            Console.WriteLine("\nEnter details of each step");
            for (int i = 1; i <= numberOfSteps; i++)
            {
                string stepDescription;

                Console.WriteLine("Step number " + i + ":");
                Console.WriteLine("\nDescription: ");
                stepDescription = Console.ReadLine();

                StepsList.Add(new StepClass(i, stepDescription));
            }
            Console.WriteLine("\n");
        }
        //End of add step method





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

            Console.WriteLine("\nWould you like to reset the ingredient quantities?\nEnter  y  for yes or  n  for no\n");
            string userResetInput = Console.ReadLine();
            if (userResetInput.Equals("y") || userResetInput.Equals("Y"))
            {
                for (int i = 0; i < IngredientsList.Count; i++)
                {
                    ((IngredientClass)IngredientsList[i]).Quantity /= scale;
                }

                DisplayRecipe();
            }
            else if (userResetInput.Equals("n") || userResetInput.Equals("N"))
            {

            }
        }
        //End of reset quantities method






        //Start of clear data method
        static public void ClearData() // This method gives the user an option to clear data and enter a new recipe
        {

            
            Console.WriteLine("\nWould you like to clear all data and enter a new recipe?\nEnter  y  for yes or  n  for no\n");
            string userClearInput = Console.ReadLine();
            if (userClearInput.Equals("y") || userClearInput.Equals("Y"))
            {

                IngredientsList.Clear();

            }
            else if (userClearInput.Equals("n") || userClearInput.Equals("N"))
            {
                Console.WriteLine("Press any key to exit the application");
                closeApp = true;
                Console.ReadKey();
            }
        }
        //End of clear data method






        //Start of display recipe method
        static public void DisplayRecipe() //This method displays the entire recipe
        {
            Console.WriteLine(recipeOutput);
            Console.WriteLine("\nIngredients:");
            foreach (IngredientClass ingredient in IngredientsList)
            {
                Console.WriteLine($"\n{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name}");
            }
            
            foreach (StepClass steps in StepsList)
            {
                Console.WriteLine($"\nStep {steps.StepNum}:\n{steps.Desc}");
            }

        }
        //End of display recipe method





        //Start of star song method
        static public void StartSong(string path) // this method plays music in the background while running the app
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = path;
            player.Play();
        }
        //End of start song method
    }
   
}
