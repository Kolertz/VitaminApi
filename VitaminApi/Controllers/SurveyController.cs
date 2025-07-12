using Microsoft.AspNetCore.Mvc;
using VitaminApi.DTOs;
using VitaminApi.Interfaces;

namespace VitaminApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveysController(ISurveyService surveyService) : ControllerBase
{
    private readonly ISurveyService _surveyService = surveyService;

    [HttpGet("{id}")]
    public async Task<ActionResult<SurveyDto>> GetSurvey(int id)
    {
        try
        {
            var survey = await _surveyService.GetSurveyResultsAsync(id);
            return Ok(survey);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
