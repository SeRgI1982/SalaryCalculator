using NUnit.Framework;
using SalaryCalculator.Domain.Calculators;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class SalaryTests
    {
        [TestCase(1, 10, 1, 1, 1, 7, 10)]
        [TestCase(0, 10, 1, 1, 1, 0, 0)]
        [TestCase(10, 0, 1, 1, 1, 0, 0)]
        [TestCase(-10, 1, 1, 1, 1, 0, 0)]
        [TestCase(1, -10, 1, 1, 1, 0, 0)]
        public void GrossAmountAndNetAmountAreCalculatedProperly(
            decimal hours,
            decimal rate,
            decimal incomeTax,
            decimal usc,
            decimal pension,
            decimal expectedNetAmount,
            decimal expectedGrossAmount)
        {
            // Arrange
            

            // Act
            var result = new Salary(hours, rate, incomeTax, usc, pension);

            // Assert
            Assert.AreEqual(expectedNetAmount, result.NetAmount);
            Assert.AreEqual(expectedGrossAmount, result.GrossAmount);
        }
    }
}