using NUnit.Framework;
using SalaryCalculator.Domain.Calculators;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class SalaryCalculatorTests
    {
        [TestCase(1, 1, 0.25, 0.07, 0.04, 0.64, 1)]
        [TestCase(10, 100, 310, 75, 40, 575, 1000)]
        public void SalaryIsCalculatedProperlyForIreland(
            decimal hours, 
            decimal rate, 
            decimal expectedIncomeTax, 
            decimal expectedUsc,
            decimal expectedPension, 
            decimal expectedNetAmount, 
            decimal expectedGrossAmount)
        {
            // Arrange
            var sut = new IrelandSalaryCalculator();

            // Act
            var result = sut.GetCalculatedSalary(hours, rate);

            // Assert
            Assert.AreEqual(expectedIncomeTax, result.IncomeTax);
            Assert.AreEqual(expectedUsc, result.UniversalSocialCharge);
            Assert.AreEqual(expectedPension, result.Pension);
            Assert.AreEqual(expectedNetAmount, result.NetAmount);
            Assert.AreEqual(expectedGrossAmount, result.GrossAmount);
        }

        [TestCase(1, 1, 0.25, 0, 0.0919, 0.6581, 1)]
        [TestCase(10, 100, 250, 0, 91.9, 658.1, 1000)]
        public void SalaryIsCalculatedProperlyForItaly(
            decimal hours,
            decimal rate,
            decimal expectedIncomeTax,
            decimal expectedUsc,
            decimal expectedPension,
            decimal expectedNetAmount,
            decimal expectedGrossAmount)
        {
            // Arrange
            var sut = new ItalySalaryCalculator();

            // Act
            var result = sut.GetCalculatedSalary(hours, rate);

            // Assert
            Assert.AreEqual(expectedIncomeTax, result.IncomeTax);
            Assert.AreEqual(expectedUsc, result.UniversalSocialCharge);
            Assert.AreEqual(expectedPension, result.Pension);
            Assert.AreEqual(expectedNetAmount, result.NetAmount);
            Assert.AreEqual(expectedGrossAmount, result.GrossAmount);
        }

        [TestCase(1, 1, 0.25, 0, 0.02, 0.73, 1)]
        [TestCase(10, 50, 132, 0, 10, 358, 500)]
        public void SalaryIsCalculatedProperlyForGermany(
            decimal hours,
            decimal rate,
            decimal expectedIncomeTax,
            decimal expectedUsc,
            decimal expectedPension,
            decimal expectedNetAmount,
            decimal expectedGrossAmount)
        {
            // Arrange
            var sut = new GermanySalaryCalculator();

            // Act
            var result = sut.GetCalculatedSalary(hours, rate);

            // Assert
            Assert.AreEqual(expectedIncomeTax, result.IncomeTax);
            Assert.AreEqual(expectedUsc, result.UniversalSocialCharge);
            Assert.AreEqual(expectedPension, result.Pension);
            Assert.AreEqual(expectedNetAmount, result.NetAmount);
            Assert.AreEqual(expectedGrossAmount, result.GrossAmount);
        }
    }
}