using System;
using System.Collections.Generic;
using System.Text;
using UI.Interfaces;

namespace UI.Implementations
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
