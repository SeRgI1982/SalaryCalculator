namespace SalaryCalculator.Domain.Calculators
{
    public class IrelandSalaryCalculator : SalaryCalculator
    {
        internal override decimal CalculateIncomeTax()
        {
            decimal result = 0;

            if (GrossAmount > 600)
            {
                result = new decimal(0.25*600 + 0.4*(double) (GrossAmount - 600));
            }
            else if (GrossAmount > 0)
            {
                result = new decimal(0.25*(double) GrossAmount);
            }

            return result;
        }

        internal override decimal CalculateUniversalSocialCharge()
        {
            decimal result = 0;

            if (GrossAmount > 500)
            {
                result = new decimal(0.07*500 + 0.08*(double) (GrossAmount - 500));
            }
            else if (GrossAmount > 0)
            {
                result = new decimal(0.07*(double) GrossAmount);
            }

            return result;
        }

        internal override decimal CalculatePension()
        {
            decimal result = 0;

            if (GrossAmount > 0)
            {
                result = new decimal(0.04*(double) GrossAmount);
            }

            return result;
        }
    }
}