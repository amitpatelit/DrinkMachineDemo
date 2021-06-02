using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CofeeMachine.Test
{
    [TestClass]
    public class UnitTest1
    {
        IcofeeMakerService icofeeMakerService = new cofeeMakerService();

        [TestMethod]
        public void TestMethod1()
        {
            //Make Coffee with Milk 
            icofeeMakerService.NewDrink(DrinkType.Coffee, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Make Coffee without Milk 
            icofeeMakerService.NewDrink(DrinkType.Coffee, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Make Latte
            icofeeMakerService.NewDrink(DrinkType.Latte);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Make Cappuccino
            icofeeMakerService.NewDrink(DrinkType.Cappuccino);
        }

        [TestMethod]
        public void TestMethod5()
        {

            //Create Multiple Drinks to Check Lowest Bean Capacity and Milk Capacity
            icofeeMakerService.ShowCurrentQuantity();
            icofeeMakerService.NewDrink(DrinkType.Coffee, true);
            icofeeMakerService.NewDrink(DrinkType.Coffee, false);
            icofeeMakerService.NewDrink(DrinkType.Latte);

            for (int i = 0; i < 5; i++)
            {
                icofeeMakerService.NewDrink(DrinkType.Cappuccino);
            }
        }
    }
}
