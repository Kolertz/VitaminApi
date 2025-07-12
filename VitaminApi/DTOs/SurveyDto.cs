namespace VitaminApi.DTOs;

public class SurveyDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public List<VitaminResultDto> VitaminResults { get; set; } = [];
    public List<ConsumptionResultDto> ConsumptionResults { get; set; } = [];
    public List<MedicationDto> Medications { get; set; } = [];
}
