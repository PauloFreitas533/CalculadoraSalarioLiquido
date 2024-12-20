using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CalculadoraSalarioLiquido.Tests.API.Controllers
{
    public class SalaryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SalaryControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Index_ShouldReturnStatus200()
        {
            // Act
            var response = await _client.GetAsync("/Salary/Index");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Calculate_ShouldReturnStatus200()
        {
            // Arrange
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grossSalary", "5000")
            });

            // Act
            var response = await _client.PostAsync("/Salary/Calculate", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

