using CalculadoraSalarioLiquido.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CalculadoraSalarioLiquido.API.Controllers.SalaryControllers
{
    [Route("[controller]")]
    public class SalaryController : Controller
    {
        private readonly SalaryService _salaryService;

        public SalaryController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Calculate")]
        public IActionResult Calculate(string grossSalary)
        {
            try
            {
                if (decimal.TryParse(grossSalary, NumberStyles.Any, new CultureInfo("pt-BR"), out decimal grossSalaryValue))
                {
                    var netSalary = _salaryService.GetNetSalary(grossSalaryValue);
                    ViewBag.NetSalary = netSalary;
                }
                else
                {
                    ViewBag.Error = "Valor inválido.";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
        }
    }
}
