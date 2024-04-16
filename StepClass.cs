using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class StepClass
    {
        public StepClass() { }
        public StepClass(int stepNum, string desc) {
            StepNum = stepNum;
            Desc = desc;
        
        }

        public int StepNum {  get; set; }
        public string Desc { get; set; }
    }
}
