namespace VitaminApi.Models;

public class VitaminConsumptionSurveyResult
{
    public int Id { get; set; }
    public int VitaminId { get; set; }
    public Vitamin? Vitamin { get; set; }
    public int SurveyResultId { get; set; }
    public SurveyResult? SurveyResult { get; set; }
    public decimal Current { get; set; }
    public decimal FromFood { get; set; }
    public decimal FromMedication { get; set; }
}
