namespace SalaryCalculator.Domain
{
    public interface ISalaryCalculatorService
    {
        Salary GetCalculatedSalary(decimal hours, decimal rate, string location);
    }
}