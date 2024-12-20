namespace CalculadoraSalarioLiquido.Domain
{
    public class SalaryCalculator
    {
        public decimal CalculateNetSalary(decimal grossSalary) 
        {
            decimal calculateINSS = CalculateINSS(grossSalary);
            decimal calculateIR = CalculateIR(grossSalary, calculateINSS);
            return grossSalary - calculateINSS - calculateIR;
        }

        public decimal CalculateINSS(decimal grossSalary) 
        {
            if (grossSalary <= 2699.99m)
                return grossSalary * 0.075m;
            if (grossSalary <= 3499.99m)
                return grossSalary * 0.09m;
            if (grossSalary <= 4999.99m)
                return grossSalary * 0.12m;

            return grossSalary * 0.14m;
        }

        public decimal CalculateIR(decimal grossSalary, decimal inss)
        {
            if (grossSalary <= 2699.99m)
                return 0;
            if (grossSalary <= 3499.99m)
                return (grossSalary - inss) * 0.075m;
            if (grossSalary <= 4999.99m)
                return (grossSalary - inss) * 0.15m;
            if (grossSalary <= 9999.99m)
                return (grossSalary - inss) * 0.225m;

            return (grossSalary - inss) * 0.275m;
        }
    }
}
