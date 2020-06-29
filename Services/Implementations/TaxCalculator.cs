using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class TaxCalculator : ITaxCalculator
    {

        const int MIN_TAXABLE = 1000;
        const int MAX_TAXABLE = 3000;

        public int ApplyIncomeTax(int salary)
        {
            if (salary < MIN_TAXABLE)
            {
                return salary;
            }

            return (int)Math.Ceiling(salary * 0.9);
        }

        public int ApplySocialTax(int salary)
        {
            if (salary < MIN_TAXABLE || salary > MAX_TAXABLE)
            {
                return salary;
            }

            return (int)Math.Ceiling(salary * 0.85);
        }
    }
}
