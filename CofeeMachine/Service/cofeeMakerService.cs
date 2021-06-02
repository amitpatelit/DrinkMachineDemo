using System;

namespace CofeeMachine
{
    public class cofeeMakerService : IcofeeMakerService
    {
        int MaxBean;
        int MaxMilk;

        public cofeeMakerService()
        {
            MaxMilk = 20;
            MaxBean = 25;
        }

        #region Private Methods
        private DrinkType GetDrink(string DrinkCode)
        {
            switch (DrinkCode)
            {
                case "1":
                    return DrinkType.Coffee;
                case "2":
                    return DrinkType.Latte;
                case "3":
                    return DrinkType.Cappuccino;
                default: return DrinkType.None;
            }
        }
        private bool CheckBeanQuantity()
        {
            if (MaxBean <= 5)
                Console.WriteLine($"Bean quantity ({MaxBean}) seems to be very low.");

            return (MaxBean < 5) ? false : true;
        }

        /// <summary>
        /// Function used to Get input as String from User and also Validate the input for Null & Blank 
        /// </summary>
        /// <param name="Message">Input Custom Message to Show on Console</param>
        /// <returns>Return String</returns>
        private string GetInput(String Message)
        {
            StartGetInput:
            Console.Write(Message + " : ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input Can't Be Blank");
                goto StartGetInput;
            }
            if (input.ToLower() == "off")
            {
                CloseApplication();
            }
            return input;
        }

        /// <summary>
        /// For Closing The Application
        /// </summary>
        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        #endregion

        /// <summary>
        /// Function Starts The Machine
        /// </summary>
        public void StartMachine()
        {
            Console.WriteLine("--------------------- W E L C O M E ----------------------");
            string input = GetInput("Press Any Key for start or Type 'off' to Shutdown Machine");
            ShowCurrentQuantity();
            start:

            string DrinkCodeInput = GetInput("Please Input 1 for Coffee, 2 for Latte , 3 for Cappuccino");
            DrinkType DrinkCode = GetDrink(DrinkCodeInput);
            bool MilkConfirmation = true;
            if (DrinkCode == DrinkType.Coffee)
                MilkConfirmation = WantMilk();
            GetSugar();
            NewDrink(DrinkCode, MilkConfirmation);
            input = GetInput("\nPress any key to Start Again  or Type 'off' to Shutdown Machine");
            goto start;
        }

        /// <summary>
        /// Show Actual Quantity of Beans and Milk in Machine
        /// </summary>
        public void ShowCurrentQuantity()
        {
            Console.WriteLine("Current Quantity Status");
            Console.WriteLine(string.Format("Beans : {0}, Milk : {1}\n", MaxBean, MaxMilk));
        }

        /// <summary>
        /// Create New Drink
        /// </summary>
        /// <param name="DrinkCode"> 1 for Coffee, 2 for Latte , 3 for Cappuccino</param>
        /// <param name="MilkConfirmation">'Y' for Yes and 'N' for No</param>
        public void NewDrink(DrinkType DrinkCode, bool MilkConfirmation = true)
        {
            string drinkType = DrinkCode.ToString();

            Console.WriteLine($"Wait.. While we are Preparing your {drinkType}");

            if (CheckBeanQuantity())
            {
                int milkconsuption = 0, beanconsuption = 0;
                switch (DrinkCode)
                {
                    case DrinkType.Coffee:
                        milkconsuption = MilkConfirmation ? 1 : 0;
                        beanconsuption = 2;
                        break;
                    case DrinkType.Latte:
                        milkconsuption = 2;
                        beanconsuption = 3;
                        break;
                    case DrinkType.Cappuccino:
                        milkconsuption = 3;
                        beanconsuption = 5;
                        break;
                    default:
                        break;
                }

                ConsuptionCalculations(milkconsuption, beanconsuption);
                Console.WriteLine(string.Format("Enjoy Your {0}", drinkType));
                ShowCurrentQuantity();
            }
        }

        /// <summary>
        /// Substract the used Milk and Bean from the Machine
        /// </summary>
        /// <param name="milkconsumption">Enter Used Milk Value</param>
        /// <param name="beanconsumption">Enter Used Bean Value</param>
        public void ConsuptionCalculations(int milkconsumption, int beanconsumption)
        {
            MaxMilk -= milkconsumption;
            MaxBean -= beanconsumption;
        }

        /// <summary>
        /// Get User Confirmation for Add Milk in Drink
        /// </summary>
        /// <returns>Return true or False</returns>
        public bool WantMilk()
        {
            GetMilk:
            string MilkQuantity = GetInput("Type 'Y' for Add Milk in Drink Otherwise 'N' for No");
            if (MilkQuantity.ToLower() == "y" || MilkQuantity.ToLower() == "n")
            {
                return ((MilkQuantity.ToLower() == "y") ? true : false);
            }
            else
            {
                Console.WriteLine("Input Should Be 'Y' or 'N'");
                goto GetMilk;
            }
        }

        /// <summary>
        /// Gets the input for Sugar 
        /// </summary>
        public void GetSugar()
        {
            GetSugar:
            int SugarQuantity = 0;
            try
            {
                SugarQuantity = Convert.ToInt32(GetInput("How much Sugar Please? "));
                if (SugarQuantity <= 0)
                {
                    Console.WriteLine("Input Can't Be Zero");
                    goto GetSugar;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter Correct Sugar Quantity");
                goto GetSugar;
            }
        }
    }
}
