using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraSalarioLiquido.Application.Services;
using CalculadoraSalarioLiquido.Domain;
using Xunit;

namespace CalculadoraSalarioLiquido.Tests.Application.Services
{
    public class SalaryServiceTests
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
            var salaryCalculator = new SalaryCalculator();
            var salaryService = new SalaryService(salaryCalculator);

            // Act
            var netSalary = salaryService.GetNetSalary(grossSalary);

            // Assert
            Assert.Equal(expectedNetSalary, netSalary, 2);
        }
    }
}
