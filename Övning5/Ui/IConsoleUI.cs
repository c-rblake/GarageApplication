namespace Övning5
{
    internal interface IConsoleUI
    {
        void Print(string message);

        void ViewMenu();
        string ReadKey();

        public void createVehicle();
    }
}