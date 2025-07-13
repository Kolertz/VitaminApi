namespace VitaminApi.DTOs;

public class VitaminResultDto
{
    public int VitaminId { get; set; }
    public string VitaminName { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public decimal MinLevel { get; set; }
    public decimal MaxLevel { get; set; }
}
