using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Interfaces
{
    public interface IConsoleWrapper
    {
        void WriteLine(string message);
        string ReadLine();
    }
}
