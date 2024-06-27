using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);
    internal class CalorieTracker
    {
       

            public event CaloriesExceededEventHandler CaloriesExceeded;
            private double totalCalories;

            public void AddCalories(double calories)
            {
                totalCalories += calories;
                Console.WriteLine($"Added calories with {calories} calories. Total is now {totalCalories}.");
                if (totalCalories > 300)
                {
                    OnCaloriesExceeded(EventArgs.Empty);
                }
            }

            protected virtual void OnCaloriesExceeded(EventArgs e)
            {
                CaloriesExceeded?.Invoke(this, e);
            }
        
    }
}
