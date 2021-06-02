namespace CofeeMachine
{
    public interface IcofeeMakerService
    {
        void StartMachine();
        void ShowCurrentQuantity();
        void NewDrink(DrinkType dringCode, bool MilkConfirmation = true);
        void GetSugar();
        bool WantMilk();
    }
}
