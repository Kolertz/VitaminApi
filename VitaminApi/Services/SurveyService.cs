using Microsoft.EntityFrameworkCore;
using VitaminApi.Data;
using VitaminApi.DTOs;
using VitaminApi.Interfaces;

namespace VitaminApi.Services;

public class SurveyService(VitaminDbContext context) : ISurveyService
{
    private readonly VitaminDbContext _context = context;

    public async Task<SurveyDto> GetSurveyResultsAsync(int surveyId)
    {
        var survey = await _context.SurveyResults
            .Include(s => s.User)
            .Include(s => s.VitaminSurveyResults)
                .ThenInclude(vsr => vsr.Vitamin)
            .Include(s => s.VitaminConsumptionSurveyResults)
                .ThenInclude(vcsr => vcsr.Vitamin)
            .Include(s => s.MedicationSurveyResults)
                .ThenInclude(msr => msr.Medication)
            .FirstOrDefaultAsync(s => s.Id == surveyId);

        if (survey == null)
        {
            throw new KeyNotFoundException($"Survey with ID {surveyId} not found");
        }

        return new SurveyDto
        {
            Id = survey.Id,
            CreatedAt = survey.CreatedAt,
            UserId = survey.UserId,
            VitaminResults = survey.VitaminSurveyResults.Select(vsr => new VitaminResultDto
            {
                VitaminId = vsr.VitaminId,
                VitaminName = vsr.Vitamin!.Name,
                Unit = vsr.Vitamin.Unit,
                MinLevel = vsr.MinLevel,
                MaxLevel = vsr.MaxLevel
            }).ToList(),
            ConsumptionResults = survey.VitaminConsumptionSurveyResults.Select(vcsr => new ConsumptionResultDto
            {
                VitaminId = vcsr.VitaminId,
                VitaminName = vcsr.Vitamin!.Name,
                CurrentConsumption = vcsr.Current,
                FromFood = vcsr.FromFood,
                FromMedication = vcsr.FromMedication
            }).ToList(),
            Medications = survey.MedicationSurveyResults.Select(msr => new MedicationDto
            {
                Id = msr.MedicationId,
                Name = msr.Medication!.Name,
                Description = msr.Medication.Description
            }).ToList()
        };
    }
}
