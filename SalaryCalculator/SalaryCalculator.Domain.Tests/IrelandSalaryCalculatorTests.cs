using NUnit.Framework;
using SalaryCalculator.Domain.Calculators;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class IrelandSalaryCalculatorTests
    {
        [TestCase(-10, 1)]
        [TestCase(1, -10)]
        public void IncomeTaxIsEqualZeroWhenHoursOrRateIsNegative(decimal hours, decimal rate)
        {
            // Arrange
            var sut = new IrelandSalaryCalculator {GrossAmount = hours*rate};
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
        [TestCase(10, 80, 230)]
        public void IncomeTaxIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new IrelandSalaryCalculator { GrossAmount = hours * rate };
            
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
            var sut = new IrelandSalaryCalculator {GrossAmount = hours*rate};
            decimal expected = 0;

            // Act
            var result = sut.CalculateUniversalSocialCharge();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0.07)]
        [TestCase(10, 50, 35)]
        [TestCase(10, 80, 59)]
        public void UniversalSocialChargeIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new IrelandSalaryCalculator { GrossAmount = hours * rate };

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
            var sut = new IrelandSalaryCalculator {GrossAmount = hours*rate};
            decimal expected = 0;

            // Act
            var result = sut.CalculatePension();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0.04)]
        [TestCase(10, 10, 4)]
        [TestCase(10, 100, 40)]
        public void PensionIsCalculatedProperlyForProperData(decimal hours, decimal rate, decimal expected)
        {
            // Arrange
            var sut = new IrelandSalaryCalculator { GrossAmount = hours * rate };

            // Act
            var result = sut.CalculatePension();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
