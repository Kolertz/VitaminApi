
using Microsoft.EntityFrameworkCore;
using VitaminApi.Interfaces;
using VitaminApi.Services;
using VitaminApi.Data;
using VitaminApi.Utils;

namespace VitaminApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddLogging();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<VitaminDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ISurveyService, SurveyService>();

        var app = builder.Build();

        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<VitaminDbContext>();

        try
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.EnsureCreatedAsync();

            await TestDataSeeder.SeedAsync(dbContext);
            logger.LogInformation("База данных создана и заполнена тестовыми данными.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при инициализации БД.");
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
