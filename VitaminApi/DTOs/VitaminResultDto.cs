namespace VitaminApi.DTOs;

public class VitaminResultDto
{
    public int VitaminId { get; set; }
    public string VitaminName { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public decimal NormLevel { get; set; }
    public decimal CurrentLevel { get; set; }
}
