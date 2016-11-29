namespace SalaryCalculator.Domain
{
    public class Salary
    {
        public Salary(decimal hours, decimal rate, decimal incomeTax, decimal universalSocialCharge, decimal pension)
        {
            Hours = hours;
            Rate = rate;
            IncomeTax = incomeTax;
            UniversalSocialCharge = universalSocialCharge;
            Pension = pension;
        }

        public decimal Hours { get; }

        public decimal Rate { get; }

        public decimal IncomeTax { get; }

        public decimal UniversalSocialCharge { get; }

        public decimal Pension { get; }

        public decimal GrossAmount
        {
            get
            {
                var result = Hours*Rate;
                return result >= 0 ? result : 0;
            }
        }

        public decimal NetAmount
        {
            get
            {
                var result = GrossAmount - IncomeTax - UniversalSocialCharge - Pension;
                return result >= 0 ? result : 0;
            }
        }
    }
}