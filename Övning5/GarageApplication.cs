using System;

namespace Övning5
{
    internal class GarageApplication
    {
        internal void Run()
        {
            IConsoleUI ui = new ConsoleUI();
            GarageHandler gh = new GarageHandler(ui);
            gh.Run();
        }
    }
}