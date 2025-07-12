using VitaminApi.Data;
using VitaminApi.Models;

namespace VitaminApi.Utils;

public static class TestDataSeeder
{
    public static async Task SeedAsync(VitaminDbContext context)
    {
        var vitaminD = new Vitamin { Name = "Витамин D", Unit = "мкг" };
        var vitaminB12 = new Vitamin { Name = "Витамин B12", Unit = "мкг" };
        var vitaminC = new Vitamin { Name = "Витамин C", Unit = "мг" };

        // Лекарства
        var multiVitamin = new Medication
        {
            Name = "Мультивитаминный комплекс",
            Description = "Содержит витамины D, B12 и C"
        };

        // Пользователь
        var testUser = new User { Id = 1 };

        // Результат опроса
        var surveyResult = new SurveyResult
        {
            UserId = testUser.Id,
            CreatedAt = DateTime.UtcNow,
            VitaminSurveyResults =
                [
                    new() {
                        Vitamin = vitaminD,
                        MinLevel = 50,
                        MaxLevel = 50  // Витамин D имеет точную норму
                    },
                    new() {
                        Vitamin = vitaminC,
                        MinLevel = 70,
                        MaxLevel = 90  // Витамин C допускает колебания
                    },
                    new() {
                        Vitamin = vitaminB12,
                        MinLevel = 5,
                        MaxLevel = 5   // Витамин B12 имеет точную норму
                    }
                ],
            VitaminConsumptionSurveyResults =
                [
                    new() { Vitamin = vitaminD, Current = 15, FromFood = 10, FromMedication = 5 },
                    new() { Vitamin = vitaminC, Current = 80, FromFood = 70, FromMedication = 10 },
                    new() { Vitamin = vitaminB12, Current = 4, FromFood = 3, FromMedication = 1 }
                ],
            MedicationSurveyResults =
                [
                    new() { Medication = multiVitamin }
                ]
        };

        await context.Vitamins.AddRangeAsync(vitaminD, vitaminC, vitaminB12);
        await context.Medications.AddAsync(multiVitamin);
        await context.Users.AddAsync(testUser);
        await context.SurveyResults.AddAsync(surveyResult);

        await context.SaveChangesAsync();
    }
}
