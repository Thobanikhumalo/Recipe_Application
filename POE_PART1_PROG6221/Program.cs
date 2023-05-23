using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART1_PROG6221
{
    internal class Program
    {
        static void Main(string[] args)
        {


         PROG6221_POE_PART1 POE = new PROG6221_POE_PART1();
         POE.MainMenu();
         POE.Engridients();  
         POE.RecipeSteps();
         POE.Display();
         POE.Scale();
         POE.Reset();
         POE.ClearData();
        }
    }
}
