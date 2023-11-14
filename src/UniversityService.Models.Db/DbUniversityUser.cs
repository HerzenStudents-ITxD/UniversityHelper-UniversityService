using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.UniversityService.Models.Db
{
  public record DbUniversityUser
  {
    public const string TableName = "UniversitiesUsers";
    public const string HistoryTableName = "UniversitiesUsersHistory";

    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public Guid UserId { get; set; }
    public double? Rate { get; set; }
    public DateTime StartWorkingAt { get; set; }
    public DateTime? EndWorkingAt { get; set; }
    public DateTime? Probation { get; set; }
    public bool IsActive { get; set; }
    public Guid CreatedBy { get; set; }

    public DbCompany Company { get; set; }
    public DbContractSubject ContractSubject { get; set; }
  }

  public class DbCompanyUserConfiguration : IEntityTypeConfiguration<DbCompanyUser>
  {
    public void Configure(EntityTypeBuilder<DbCompanyUser> builder)
    {
      builder
        .ToTable(
          DbCompanyUser.TableName,
          cu => cu.IsTemporal(b =>
          {
            b.UseHistoryTable(DbCompanyUser.HistoryTableName);
          }));

      builder
        .HasKey(t => t.Id);

      builder
        .HasOne(u => u.Company)
        .WithMany(c => c.Users);

      builder
        .HasOne(u => u.ContractSubject)
        .WithMany(cs => cs.Users);
    }
  }
}
