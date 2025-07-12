namespace VitaminApi.Models;

public class MedicationSurveyResult
{
    public int MedicationId { get; set; }
    public Medication? Medication { get; set; }
    public int SurveyResultId { get; set; }
    public SurveyResult? SurveyResult { get; set; }
}
