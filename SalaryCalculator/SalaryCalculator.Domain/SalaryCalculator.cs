namespace SalaryCalculator.Domain
{
    public abstract class SalaryCalculator
    {
        public Salary GetCalculatedSalary(decimal hours, decimal rate)
        {
            GrossAmount = hours*rate;

            var incomeTax = CalculateIncomeTax();
            var universalSocialCharge = CalculateUniversalSocialCharge();
            var pension = CalculatePension();

            return new Salary(hours, rate, incomeTax, universalSocialCharge, pension);
        }

        internal decimal GrossAmount { get; set; }

        internal abstract decimal CalculateIncomeTax();

        internal abstract decimal CalculateUniversalSocialCharge();

        internal abstract decimal CalculatePension();
    }
}
