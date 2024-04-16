using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class RecipeClass
    {
        private string name;
        private double numberOfIng, numberOfSteps;
       public RecipeClass() { 
        
        }

       public RecipeClass(string name, double numberOfIng, double numberOfSteps) { 
        
            this.name = name;
            this.numberOfIng = numberOfIng;
            this.numberOfSteps = numberOfSteps;
           
        
        }

        public string Name { get; set; }
        public double NumberOfIng { get; set; }
        public double NumberOfSteps { get; set;}

        public string RecipeDec() //This method displays the recipe details
        {

            string desc = "\nYour "+name+" recipe requires "+numberOfIng+" ingredients and takes "+numberOfSteps+" steps to complete\n";

            return desc; 
        }
       


    }
}
