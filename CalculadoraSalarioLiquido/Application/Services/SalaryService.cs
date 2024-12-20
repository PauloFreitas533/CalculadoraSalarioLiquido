using CalculadoraSalarioLiquido.Domain;

namespace CalculadoraSalarioLiquido.Application.Services
{
    public class SalaryService
    {
        private readonly SalaryCalculator _salaryCalculator;

        public SalaryService(SalaryCalculator salaryCalculator)
        {
            _salaryCalculator = new SalaryCalculator();
        }

        public decimal GetNetSalary(decimal grossSalary)
        {
            return _salaryCalculator.CalculateNetSalary(grossSalary);
        }

    }
}
