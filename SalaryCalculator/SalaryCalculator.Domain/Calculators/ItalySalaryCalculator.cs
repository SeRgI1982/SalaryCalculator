namespace SalaryCalculator.Domain.Calculators
{
    public class ItalySalaryCalculator : SalaryCalculator
    {
        internal override decimal CalculateIncomeTax()
        {
            decimal result = 0;

            if (GrossAmount > 0)
            {
                result = new decimal(0.25*(double) GrossAmount);
            }

            return result;
        }

        internal override decimal CalculateUniversalSocialCharge()
        {
            return 0;
        }

        internal override decimal CalculatePension()
        {
            decimal result = 0;

            if (GrossAmount > 0)
            {
                result = new decimal(0.0919*(double) GrossAmount);
            }

            return result;
        }
    }
}