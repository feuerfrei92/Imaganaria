using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using System;
using UI.Implementations;
using UI.Interfaces;

namespace Imaganaria
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INameGenerator, NameGenerator>()
                .AddSingleton<ITaxCalculator, TaxCalculator>()
                .AddSingleton<IConsoleWrapper, ConsoleWrapper>()
                .AddSingleton<IDisplayer, Displayer>()
                .BuildServiceProvider();

            var displayer = serviceProvider.GetService<IDisplayer>();

            do
            {
                var person = new Person();
                displayer.GenderSetter(person);
                displayer.NameSetter(person);
                displayer.SalarySetter(person);
            }
            while (displayer.AnotherPerson());
        }
    }
}
