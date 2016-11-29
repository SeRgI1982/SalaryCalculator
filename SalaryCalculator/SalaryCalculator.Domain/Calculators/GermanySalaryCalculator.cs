namespace SalaryCalculator.Domain.Calculators
{
    public class GermanySalaryCalculator : SalaryCalculator
    {
        internal override decimal CalculateIncomeTax()
        {
            decimal result = 0;

            if (GrossAmount > 400)
            {
                result = new decimal(0.25*400 + 0.32*(double) (GrossAmount - 400));
            }
            else if (GrossAmount > 0)
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
                result = new decimal(0.02*(double) GrossAmount);
            }

            return result;
        }
    }
}