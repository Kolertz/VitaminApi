using VitaminApi.DTOs;

namespace VitaminApi.Interfaces;
public interface ISurveyService
{
    Task<SurveyDto> GetSurveyResultsAsync(int surveyId);
}