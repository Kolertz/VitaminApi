using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VitaminApi.Models;

namespace VitaminApi.Data;

public class VitaminDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<SurveyResult> SurveyResults { get; set; } = null!;
    public DbSet<VitaminSurveyResult> VitaminSurveyResults { get; set; } = null!;
    public DbSet<MedicationSurveyResult> MedicationSurveyResults { get; set; } = null!;
    public DbSet<VitaminConsumptionSurveyResult> VitaminConsumptionSurveyResults { get; set; } = null!;
    public DbSet<Vitamin> Vitamins { get; set; } = null!;
    public DbSet<Medication> Medications { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User to SurveyResult (one-to-many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.SurveyResults)
            .WithOne(sr => sr.User)
            .HasForeignKey(sr => sr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // SurveyResult to VitaminSurveyResult (one-to-many)
        modelBuilder.Entity<SurveyResult>()
            .HasMany(sr => sr.VitaminSurveyResults)
            .WithOne(vsr => vsr.SurveyResult)
            .HasForeignKey(vsr => vsr.SurveyResultId)
            .OnDelete(DeleteBehavior.Cascade);

        // SurveyResult to MedicationSurveyResult (one-to-many)
        modelBuilder.Entity<SurveyResult>()
            .HasMany(sr => sr.MedicationSurveyResults)
            .WithOne(msr => msr.SurveyResult)
            .HasForeignKey(msr => msr.SurveyResultId)
            .OnDelete(DeleteBehavior.Cascade);

        // SurveyResult to VitaminConsumptionSurveyResult (one-to-many)
        modelBuilder.Entity<SurveyResult>()
            .HasMany(sr => sr.VitaminConsumptionSurveyResults)
            .WithOne(vcsr => vcsr.SurveyResult)
            .HasForeignKey(vcsr => vcsr.SurveyResultId)
            .OnDelete(DeleteBehavior.Cascade);

        // Vitamin to VitaminSurveyResult (one-to-many)
        modelBuilder.Entity<Vitamin>()
            .HasMany(v => v.VitaminSurveyResults)
            .WithOne(vsr => vsr.Vitamin)
            .HasForeignKey(vsr => vsr.VitaminId)
            .OnDelete(DeleteBehavior.Cascade);

        // Vitamin to VitaminConsumptionSurveyResult (one-to-many)
        modelBuilder.Entity<Vitamin>()
            .HasMany(v => v.VitaminConsumptionSurveyResults)
            .WithOne(vcsr => vcsr.Vitamin)
            .HasForeignKey(vcsr => vcsr.VitaminId)
            .OnDelete(DeleteBehavior.Cascade);

        // Medication to MedicationSurveyResult (one-to-many)
        modelBuilder.Entity<Medication>()
            .HasMany(m => m.MedicationSurveyResults)
            .WithOne(msr => msr.Medication)
            .HasForeignKey(msr => msr.MedicationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Составной ключ для MedicationSurveyResult (many-to-many)
        modelBuilder.Entity<MedicationSurveyResult>()
            .HasKey(msr => new { msr.MedicationId, msr.SurveyResultId });

        // Настройка связей для MedicationSurveyResult
        modelBuilder.Entity<MedicationSurveyResult>()
            .HasOne(msr => msr.Medication)
            .WithMany(m => m.MedicationSurveyResults)
            .HasForeignKey(msr => msr.MedicationId);

        modelBuilder.Entity<MedicationSurveyResult>()
            .HasOne(msr => msr.SurveyResult)
            .WithMany(sr => sr.MedicationSurveyResults)
            .HasForeignKey(msr => msr.SurveyResultId);
    }
}
