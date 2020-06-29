using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Interfaces;

namespace UI.Implementations
{
    public class Displayer : IDisplayer
    {
        INameGenerator _nameGenerator;
        ITaxCalculator _taxCalculator;
        IConsoleWrapper _consoleWrapper;

        public Displayer(INameGenerator nameGenerator, ITaxCalculator taxCalculator, IConsoleWrapper consoleWrapper)
        {
            _nameGenerator = nameGenerator;
            _taxCalculator = taxCalculator;
            _consoleWrapper = consoleWrapper;
        }

        public void GenderSetter(Person person)
        {
            string gender;
            do
            {
                _consoleWrapper.WriteLine("Select gender for the person: m/f");
                gender = _consoleWrapper.ReadLine();
            }
            while (gender != "m" && gender != "f");

            switch (gender)
            {
                case "m":
                    person.PersonGender = Gender.Male;
                    break;
                case "f":
                    person.PersonGender = Gender.Female;
                    break;
            }
        }

        public void NameSetter(Person person)
        {
            var builder = _nameGenerator.GenerateName();
            person.Name = _nameGenerator.AdjustToGender(builder, person.PersonGender);
        }

        public void SalarySetter(Person person)
        {
            int salary;
            string input;
            do
            {
                _consoleWrapper.WriteLine($"Input salary for {person.Name}: ");
                input = _consoleWrapper.ReadLine();
            }
            while (!int.TryParse(input, out salary));

            person.Salary = salary;

            _consoleWrapper.WriteLine($"Gross salary for {person.Name}: {person.Salary}");
            person.Salary = _taxCalculator.ApplyIncomeTax(person.Salary);
            _consoleWrapper.WriteLine($"Salary for {person.Name} after income tax: {person.Salary}");
            person.Salary = _taxCalculator.ApplySocialTax(person.Salary);
            _consoleWrapper.WriteLine($"Salary for {person.Name} after social tax: {person.Salary}");
        }

        public bool AnotherPerson()
        {
            string answer;
            do
            {
                _consoleWrapper.WriteLine("Do you want to calculate another person? y/n");
                answer = _consoleWrapper.ReadLine();
            }
            while (answer != "y" && answer != "n");

            switch (answer)
            {
                case "y":
                    return true;
            }

            return false;
        }
    }
}
