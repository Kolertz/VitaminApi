namespace VitaminApi.DTOs;

public class ConsumptionResultDto
{
    public int VitaminId { get; set; }
    public string VitaminName { get; set; } = string.Empty;
    public decimal CurrentConsumption { get; set; }
    public decimal FromFood { get; set; }
    public decimal FromMedication { get; set; }
}
