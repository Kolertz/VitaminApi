namespace VitaminApi.Models;

public class User
{
    public int Id { get; set; }
    public ICollection<SurveyResult> SurveyResults { get; set; } = [];
}
