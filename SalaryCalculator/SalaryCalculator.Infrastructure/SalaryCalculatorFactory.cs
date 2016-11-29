using System;
using Microsoft.Practices.Unity;
using SalaryCalculator.Domain;

namespace SalaryCalculator.Infrastructure
{
    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        private readonly IUnityContainer _container;

        public SalaryCalculatorFactory(IUnityContainer container)
        {
            _container = container;
        }

        public Domain.SalaryCalculator GetSalaryCalculator(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            try
            {
                return _container.Resolve<Domain.SalaryCalculator>(location.ToLower());
            }
            catch (Exception)
            {
                throw new NotSupportedException($"The location: {location} is not supported");
            }
        }
    }
}
