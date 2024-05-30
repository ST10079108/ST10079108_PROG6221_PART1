using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipeSandbox
{
    internal class StepClass
    {
        public StepClass() { }
        public StepClass(int stepNum, string desc)
        {
            StepNum = stepNum;
            Desc = desc;

        }

        public int StepNum { get; set; }
        public string Desc { get; set; }
    }
}
//<summary>
//In this code I created a deafault constructor as well as a constructor with arguments for step number and step description
//This class is used to store steps instances
//</summary>