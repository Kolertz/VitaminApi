namespace VitaminApi.Models;

public class VitaminSurveyResult
{
    public int Id { get; set; }
    public int SurveyResultId { get; set; }
    public SurveyResult? SurveyResult { get; set; }
    public int VitaminId { get; set; }
    public Vitamin? Vitamin { get; set; }
    public decimal MinLevel { get; set; }
    public decimal MaxLevel { get; set; }
    public decimal CurrentLevel { get; set; }
}
