using System;

namespace POE_PART1_PROG6221
{
    internal class PROG6221_POE_PART1
    {

        // Declaring  arrays for ingredients and recipe steps

        string[] Name;
        double[] Quantity;
        String[] Measurement;
        string[] Steps;

        // Declaring  variables
        int choose; // for  user menu 

        double[] OriginalQuantities; // will store original ingredient quantities



        public void MainMenu()
        {
            // asking the user for correct input 
            while (choose <= 5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CHOOSE : " + "\n1: TO ADD recipe " +
                                                  "\n2: TO Display full Recipe " +
                                                  "\n3: TO Scale the ingredients quantities " +
                                                  "\n4: TO Reset Quantities " +
                                                  "\n5: TO Clear all the Data  ");

                // take user input from console
                choose = Convert.ToInt32(Console.ReadLine());


                // Processing the user's input based on the chosen option
                switch (choose)
                {

                    case 1:

                        Engridients();
                        RecipeSteps();
                        Console.WriteLine();
                        break;


                    case 2:
                        Display();
                        Console.WriteLine();
                        break;

                    case 3:
                        Scale();
                        Console.WriteLine();
                        break;

                    case 4:
                        Reset();
                        Console.WriteLine();
                        break;


                    case 5:
                        ClearData();
                        Console.WriteLine();
                        break;

                    //if the user enters an invalid input, the application will tell them and the manu will display again
                   
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please choose a number between 1 and 5.");
                        choose = 0;
                        break;
                }
            }
        }


        public void Engridients()
        {
            // asking the user for the number of ingredients they want to add
            Console.Write("ENTER THE NUMBER OF INGRIDIENTS: ");
            int num = Convert.ToInt32(Console.ReadLine());

            // Creating arrays of the specified size to store the ingredient information
            Name = new string[num];
            Quantity = new double[num];
            Measurement = new string[num];
            OriginalQuantities = new double[num];

            for (int i = 0; i < num; i++)
            {
                // allowing the user to enter ingredient details
                Console.Write("ENTER THE INGRIEDIENT NAME: ");
                Name[i] = Console.ReadLine();
                

                Console.Write("ENTER THE INGRIEDIENT QUANTITY: ");
                Quantity[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("ENTER THE INGRIEDIENT UNIT OF MEASUREMENT: ");
                Measurement[i] = Console.ReadLine();

                // Storing original ingredient quantities for resetting purposes
                OriginalQuantities[i] = Quantity[i];
               
            }
        }


        public void RecipeSteps()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //asking the user for the number of recipe steps
            Console.Write("ENTER THE NUMBER OF STEPS: ");
            int numOfSteps = Convert.ToInt32(Console.ReadLine());


            // Creating an array of the specified size to store the recipe steps
            Steps = new string[numOfSteps];

           
            for (int i = 0; i < numOfSteps; i++)
            {
                int step = i + 1;
                Console.Write("STEP" + step + ": DESCRIPTION : ");
                Steps[i] = Console.ReadLine();
            }
        }



        // This method call all the information added by the user and display it
        public void Display()
        {
            if (Name.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No data to display. Please add a recipe");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                    RECIPE                        ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            // Show all the ingredients details e.g name, quantity and measurement
            Console.WriteLine("INGREDIENTS:");
            for (int i = 0; i < Name.Length; i++)
            {
                Console.WriteLine($"- {Name[i]}: {Quantity[i]} {Measurement[i]}");
            }

            Console.WriteLine();

            // Show each step in the recipe
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("STEPS AND DESCRIPTIONS: ");
            for (int i = 0; i < Steps.Length; i++)
            {
                int step = i + 1;
                string description = step + ">>" + Steps[i];
                Console.WriteLine(description);
            }

            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------");
        }


        // This method is used to scale a particular ingredient's quantity in the recipe
        public void Scale()
        {

             Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine();

            // asking the user to choose the recipe they want to scale
            Console.WriteLine("ENTER THE RECIPE NUMBER TO SCALE");


            for (int i = 0; i < Name.Length; i++)
            {

                int step = i + 1;

                string ingridient = step + ") " + Quantity[i] + " " + Measurement[i]
                     + " of " + Name[i];

                Console.WriteLine(ingridient);

            }

            // Get the user's input for the ingredient to scale
            string quantityToScaleInput = Console.ReadLine();
            int quantityToScale = Convert.ToInt32(quantityToScaleInput);

            double Scale = 0;


            // The user will choose how many times do they want to scale 
            Console.WriteLine("ENTER SCALE FACTOR" + "\n1) 0.5 (half)"
                + "\n2) 2 (double)" + "\n3) (triple)");
            
            // This integer accept the user input 
            int ScaleInput = Convert.ToInt32(Console.ReadLine());

            // This switch statement is used to store all the scale factors so that 
            // The user can choose how many times do they want to scale their ingredient 
            switch (ScaleInput)
            {
                case 1:
                    Scale = .5;
                    break;

                case 2:
                    Scale = 2.0;
                    break;

                case 3:
                    Scale = 3.0;
                    break;
            }

            // calculation of scaling the ingridient by the number choosen by the user
            Quantity[quantityToScale - 1] = Scale * Quantity[quantityToScale - 1];


            for (int i = 0; i < Name.Length; i++)
            {


                int step = i + 1;

                string ingridient = step + ") " + Quantity[i] + " " + Measurement[i]
                     + " of " + Name[i];

                Console.WriteLine(ingridient);
            }


        }

        //This method is used to Reset data from the new updated data to the original data
        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("PRESS 1 TO RESET THE QUANTITY OR ANY OTHER KEY TO COUNTINUE :");
            String RESET = Console.ReadLine();

            // If the user inputs "1", the quantities are reset to their original values
            if (RESET == "1")
            {
                for (int i = 0; i < Quantity.Length; i++)
                {
                    Quantity[i] = OriginalQuantities[i];


                }

                Console.WriteLine("QUANTITY IS NOW BACK TO ORIGINAL");
            }



        }

        //This method is used to to clear or delete all the data the user entered
        public void ClearData()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write("PRESS 1 TO CLEAR ALL DATA OR ANY OTHER KEY TO COUNTINUE: ");

            string ClearData = Console.ReadLine();

            // If the user inputs "1", all the data in the recipe is cleared
            if (ClearData == "1")
            {

                Name = new string[] { };
                Quantity = new double[] { };
                Measurement = new string[] { };
                Steps = new string[] { };

             //This message tell the user that the information was deleted 
                Console.WriteLine("ALL DATA HAVE BEEN DELETED");

                


            }





        }





    }
}
