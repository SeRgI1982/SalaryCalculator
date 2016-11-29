using NUnit.Framework;
using SalaryCalculator.Domain.Calculators;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class GermanySalaryCalculatorTests
    {
        [TestCase(-10, 1)]
        [TestCase(1, -10)]
        public void IncomeTaxIsEqualZeroWhenHoursOrRateIsNegative(decimal hours, decimal rate)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };
            decimal expected = 0;

            // Act
            var result = sut.CalculateIncomeTax();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0.25)]
        [TestCase(10, 40, 100)]
        [TestCase(10, 50, 132)]
        public void IncomeTaxIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };

            // Act
            var result = sut.CalculateIncomeTax();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(-10, 1)]
        [TestCase(1, -10)]
        public void UniversalSocialChargeIsEqualZeroWhenHoursOrRateIsNegative(decimal hours, decimal rate)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };
            decimal expected = 0;

            // Act
            var result = sut.CalculateUniversalSocialCharge();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0)]
        [TestCase(10, 50, 0)]
        public void UniversalSocialChargeIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };

            // Act
            var result = sut.CalculateUniversalSocialCharge();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(-10, 1)]
        [TestCase(1, -10)]
        public void PensionIsEqualZeroWhenHoursOrRateIsNegative(decimal hours, decimal rate)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };
            decimal expected = 0;

            // Act
            var result = sut.CalculatePension();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0.02)]
        [TestCase(10, 10, 2)]
        public void PensionIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new GermanySalaryCalculator { GrossAmount = hours * rate };

            // Act
            var result = sut.CalculatePension();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}