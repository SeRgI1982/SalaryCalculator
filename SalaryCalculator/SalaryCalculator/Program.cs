using System;
using System.Text;
using Microsoft.Practices.Unity;
using SalaryCalculator.Domain;
using SalaryCalculator.Services;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            Initializer.Initialize(container);

            var service = container.Resolve<ISalaryCalculatorService>();

            decimal hours;

            Console.Write("Please enter the hours worked: ");
            if (!decimal.TryParse(Console.ReadLine(), out hours))
            {
                Console.WriteLine("Incorrect input - hours");
                return;
            }

            Console.Write("Please enter the hourly rate: ");
            decimal rate;

            if (!decimal.TryParse(Console.ReadLine(), out rate))
            {
                Console.WriteLine("Incorrect input - rate");
                return;
            }

            Console.Write("Please enter the employee’s location: ");
            var location = Console.ReadLine();

            try
            {
                var salary = service.GetCalculatedSalary(hours, rate, location);
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine($"Employee location: {location}");
                sb.AppendLine();
                sb.AppendLine($"Gross Amount: {salary.GrossAmount} EUR");
                sb.AppendLine();
                sb.AppendLine("Less deductions");
                sb.AppendLine();
                sb.AppendLine($"Income Tax : {salary.IncomeTax} EUR");
                sb.AppendLine($"Universal Social Charge: {salary.UniversalSocialCharge} EUR");
                sb.AppendLine($"Pension: {salary.Pension} EUR");
                sb.AppendLine($"Net Amount: {salary.NetAmount} EUR");
                Console.Write(sb.ToString());
            }
            catch (NotSupportedException nex)
            {
                Console.WriteLine(nex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown exception: {ex.Message}");
            }
            
            Console.ReadKey();
        }
     }
}
