
namespace CofeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IcofeeMakerService cm = new cofeeMakerService();
            cm.StartMachine();
        }
    }
}
