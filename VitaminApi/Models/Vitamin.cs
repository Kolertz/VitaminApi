namespace VitaminApi.Models;

public class Vitamin
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Unit { get; set; } = "мг";

    public ICollection<VitaminNormSurveyResult> VitaminSurveyResults { get; set; } = [];
    public ICollection<VitaminConsumptionSurveyResult> VitaminConsumptionSurveyResults { get; set; } = [];
}
