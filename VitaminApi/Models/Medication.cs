namespace VitaminApi.Models;

public class Medication
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<MedicationSurveyResult> MedicationSurveyResults { get; set; } = [];
}
