using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interfaces;
using UI.Implementations;
using UI.Interfaces;

namespace Tests
{
    [TestClass]
    public class UITests
    {
        private Mock<INameGenerator> _nameGenerator;
        private Mock<ITaxCalculator> _taxCalculator;
        private Mock<IConsoleWrapper> _consoleWrapper;
        private IDisplayer _displayer;

        public UITests()
        {
            _nameGenerator = new Mock<INameGenerator>();
            _taxCalculator = new Mock<ITaxCalculator>();
            _consoleWrapper = new Mock<IConsoleWrapper>();
        }

        [TestMethod]
        public void GenderInput_Correct()
        {
            _consoleWrapper.Setup(c => c.ReadLine()).Returns("m");
            var person = new Person();
            _displayer = new Displayer(_nameGenerator.Object, _taxCalculator.Object, _consoleWrapper.Object);

            _displayer.GenderSetter(person);

            Assert.AreEqual(Gender.Male, person.PersonGender);
        }

        [TestMethod]
        public void SalaryInput_Correct()
        {
            _consoleWrapper.Setup(c => c.ReadLine()).Returns("2400");
            _taxCalculator.Setup(t => t.ApplyIncomeTax(It.IsAny<int>())).Returns(2160);
            _taxCalculator.Setup(t => t.ApplySocialTax(It.IsAny<int>())).Returns(1836);
            var person = new Person();

            _displayer = new Displayer(_nameGenerator.Object, _taxCalculator.Object, _consoleWrapper.Object);

            _displayer.SalarySetter(person);

            Assert.AreEqual(1836, person.Salary);
        }

        [TestMethod]
        public void AnotherPersonInput_Next()
        {
            _consoleWrapper.Setup(c => c.ReadLine()).Returns("y");

            _displayer = new Displayer(_nameGenerator.Object, _taxCalculator.Object, _consoleWrapper.Object);

            Assert.IsTrue(_displayer.AnotherPerson());
        }

        [TestMethod]
        public void AnotherPersonInput_NoMore()
        {
            _consoleWrapper.Setup(c => c.ReadLine()).Returns("n");

            _displayer = new Displayer(_nameGenerator.Object, _taxCalculator.Object, _consoleWrapper.Object);

            Assert.IsFalse(_displayer.AnotherPerson());
        }
    }
}
