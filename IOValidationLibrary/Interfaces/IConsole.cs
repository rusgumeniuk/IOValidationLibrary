using System;
using System.Collections.Generic;
using System.Text;

namespace IOValidation.Interfaces
{
    public interface IConsole
    {
        void DisplayMainMenu();
        void DisplayMenu(string title, string description);
        void DisplayBackToMainMenu();
    }
}
