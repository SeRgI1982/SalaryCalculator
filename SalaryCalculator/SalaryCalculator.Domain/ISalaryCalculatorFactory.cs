namespace SalaryCalculator.Domain
{
    public interface ISalaryCalculatorFactory
    {
        SalaryCalculator GetSalaryCalculator(string location);
    }
}