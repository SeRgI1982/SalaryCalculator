using SalaryCalculator.Domain;

namespace SalaryCalculator.Services
{
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        private readonly ISalaryCalculatorFactory _salaryCalculatorFactory;

        public SalaryCalculatorService(ISalaryCalculatorFactory salaryCalculatorFactory)
        {
            _salaryCalculatorFactory = salaryCalculatorFactory;
        }

        public Salary GetCalculatedSalary(decimal hours, decimal rate, string location)
        {
            var salaryCalculator = _salaryCalculatorFactory.GetSalaryCalculator(location);
            var result = salaryCalculator.GetCalculatedSalary(hours, rate);
            return result;
        }
    }
}
