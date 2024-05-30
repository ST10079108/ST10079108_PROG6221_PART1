using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace recipeSandbox
{
    internal class RecipeClass
    {

        public RecipeClass()
        {

        }

        public RecipeClass(string name, double numberOfIng, double numberOfSteps)
        {
            Name = name;
            NumberOfIng = numberOfIng;
            NumberOfSteps = numberOfSteps;


        }

        public string Name { get; set; }
        public double NumberOfIng { get; set; }
        public double NumberOfSteps { get; set; }



    }
}
//<summary>
//In this code I created a deafault constructor as well as a constructor with arguments for recipe name, number of ingredients and number of steps
//This class is used to store recipe instances, but is mainly used for headings
//</summary>