using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ITaxCalculator
    {
        int ApplyIncomeTax(int salary);
        int ApplySocialTax(int salary);
    }
}
