using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class IngredientClass
    {
        
        public IngredientClass() { }

        public IngredientClass(string name, double quantity, string unitOfMeasurement) {
        
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
        }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set;}
        public double Quantity { get; set; }


        
    }
}
