using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implementations;
using Services.Interfaces;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ServiceTests
    {
        private INameGenerator _nameGenerator = new NameGenerator();
        private ITaxCalculator _taxCalculator = new TaxCalculator();

        [TestMethod]
        public void GenerateMaleName_Correct()
        {
            Gender gender = Gender.Male;

            var builder = _nameGenerator.GenerateName();

            Assert.IsNotNull(builder);

            string name = _nameGenerator.AdjustToGender(builder, gender);

            Assert.IsNotNull(name);
            Assert.IsTrue(name.Length >= 2);
            Assert.IsTrue(name.Length <= 10);
            Assert.AreNotEqual('a', name.Last());
        }

        [TestMethod]
        public void GenerateFemaleName_Correct()
        {
            Gender gender = Gender.Female;

            var builder = _nameGenerator.GenerateName();

            Assert.IsNotNull(builder);

            string name = _nameGenerator.AdjustToGender(builder, gender);

            Assert.IsNotNull(name);
            Assert.IsTrue(name.Length >= 3);
            Assert.IsTrue(name.Length <= 11);
            Assert.AreEqual('a', name.Last());
        }

        [TestMethod]
        public void GrossLessThanThousand()
        {
            int salary = 950;

            salary = _taxCalculator.ApplyIncomeTax(salary);

            Assert.AreEqual(950, salary);

            salary = _taxCalculator.ApplySocialTax(salary);

            Assert.AreEqual(950, salary);
        }

        [TestMethod]
        public void LessThanThousandAfterIncomeTax()
        {
            int salary = 1050;

            salary = _taxCalculator.ApplyIncomeTax(salary);

            Assert.AreEqual(945, salary);

            salary = _taxCalculator.ApplySocialTax(salary);

            Assert.AreEqual(945, salary);
        }

        [TestMethod]
        public void BetweenThousandAndThreeThousandAfterIncomeTax()
        {
            int salary = 2405;

            salary = _taxCalculator.ApplyIncomeTax(salary);

            Assert.AreEqual(2165, salary);

            salary = _taxCalculator.ApplySocialTax(salary);

            Assert.AreEqual(1841, salary);
        }

        [TestMethod]
        public void MoreThanThreeThousandAfterIncomeTax()
        {
            int salary = 3500;

            salary = _taxCalculator.ApplyIncomeTax(salary);

            Assert.AreEqual(3150, salary);

            salary = _taxCalculator.ApplySocialTax(salary);

            Assert.AreEqual(3150, salary);
        }
    }
}
