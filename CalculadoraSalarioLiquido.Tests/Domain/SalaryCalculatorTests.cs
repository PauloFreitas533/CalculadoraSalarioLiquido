using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraSalarioLiquido.Domain;
using Xunit;

namespace CalculadoraSalarioLiquido.Tests.Domain
{
    public class SalaryCalculatorTests
    {
        [Theory]
        [InlineData(1412.00, 1306.10)] 
        [InlineData(2700.00, 2272.72)] 
        [InlineData(3500.00, 2618.00)] 
        [InlineData(5000.00, 3332.50)] 
        [InlineData(10000.00, 6235.00)] 
        public void CalculateNetSalary_ShouldReturnExpectedNetSalary(decimal grossSalary, decimal expectedNetSalary)
        {
            // Arrange
            var calculator = new SalaryCalculator();

            // Act
            var netSalary = calculator.CalculateNetSalary(grossSalary);

            // Assert
            Assert.Equal(expectedNetSalary, netSalary, 2);
        }

        [Theory]
        [InlineData(1412.00, 105.90)] 
        [InlineData(2700.00, 243.00)] 
        [InlineData(3500.00, 420.00)] 
        [InlineData(5000.00, 700.00)] 
        [InlineData(10000.00, 1400.00)] 
        public void CalculateINSS_ShouldReturnExpectedINSS(decimal grossSalary, decimal expectedINSS)
        {
            // Arrange
            var calculator = new SalaryCalculator();

            // Act
            var inss = calculator.CalculateINSS(grossSalary);

            // Assert
            Assert.Equal(expectedINSS, inss, 2);
        }

        [Theory]
        [InlineData(1412.00, 0)] 
        [InlineData(2700.00, 184.28)] 
        [InlineData(3500.00, 462.00)] 
        [InlineData(5000.00, 967.50)] 
        [InlineData(10000.00, 2365.00)] 
        public void CalculateIR_ShouldReturnExpectedIR(decimal grossSalary, decimal expectedIR)
        {
            // Arrange
            var calculator = new SalaryCalculator();

            // Act
            var inss = calculator.CalculateINSS(grossSalary);
            var ir = calculator.CalculateIR(grossSalary, inss);

            // Assert
            Assert.Equal(expectedIR, ir, 2);
        }

        [Theory]
        [InlineData(2699.99, 2497.49)]
        [InlineData(3499.99, 2946.12)]
        [InlineData(4999.99, 3739.99)]
        [InlineData(9999.99, 6664.99)]
        public void CalculateNetSalary_ShouldReturnExpectedNetSalary_ForBoundaryValues(decimal grossSalary, decimal expectedNetSalary)
        {
            // Arrange
            var calculator = new SalaryCalculator();

            // Act
            var netSalary = calculator.CalculateNetSalary(grossSalary);

            // Assert
            Assert.Equal(expectedNetSalary, netSalary, 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void CalculateNetSalary_ShouldThrowArgumentException_ForInvalidGrossSalary(decimal grossSalary)
        {
            // Arrange
            var calculator = new SalaryCalculator();
            var expectedMessage = "O salário bruto deve ser maior que zero.";

            var exception = Assert.Throws<ArgumentException>(() => calculator.CalculateNetSalary(grossSalary));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
