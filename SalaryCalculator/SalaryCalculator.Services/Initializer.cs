using System;
using Microsoft.Practices.Unity;
using SalaryCalculator.Domain.Calculators;
using SalaryCalculator.Infrastructure;

namespace SalaryCalculator.Services
{
    public static class Initializer
    {
        public static void Initialize(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.RegisterType<Domain.ISalaryCalculatorService, SalaryCalculatorService>();
            container.RegisterType<Domain.ISalaryCalculatorFactory, SalaryCalculatorFactory>();
            container.RegisterType<Domain.SalaryCalculator, IrelandSalaryCalculator>("ireland", new ContainerControlledLifetimeManager());
            container.RegisterType<Domain.SalaryCalculator, ItalySalaryCalculator>("italy", new ContainerControlledLifetimeManager());
            container.RegisterType<Domain.SalaryCalculator, GermanySalaryCalculator>("germany", new ContainerControlledLifetimeManager());
        }    
    }
}