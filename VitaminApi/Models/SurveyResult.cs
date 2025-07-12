namespace VitaminApi.Models;

public class SurveyResult
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<VitaminSurveyResult> VitaminSurveyResults { get; set; } = [];
    public ICollection<MedicationSurveyResult> MedicationSurveyResults { get; set; } = [];
    public ICollection<VitaminConsumptionSurveyResult> VitaminConsumptionSurveyResults { get; set; } = [];
}
