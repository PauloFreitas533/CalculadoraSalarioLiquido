using CalculadoraSalarioLiquido.Application.Services;
using CalculadoraSalarioLiquido.Domain;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Register application services
        builder.Services.AddScoped<SalaryService>();
        builder.Services.AddScoped<SalaryCalculator>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "salary",
            pattern: "{controller=Salary}/{action=Index}/{id?}");

        app.Run();
    }
}
