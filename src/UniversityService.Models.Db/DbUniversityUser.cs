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
    public bool IsActive { get; set; }
    public Guid CreatedBy { get; set; }

    public DbUniversity University { get; set; }
  }

  public class DbUniversityUserConfiguration : IEntityTypeConfiguration<DbUniversityUser>
  {
    public void Configure(EntityTypeBuilder<DbUniversityUser> builder)
    {
      builder
        .ToTable(
          DbUniversityUser.TableName,
          cu => cu.IsTemporal(b =>
          {
            b.UseHistoryTable(DbUniversityUser.HistoryTableName);
          }));

      builder
        .HasKey(t => t.Id);

      builder
        .HasOne(u => u.University)
        .WithMany(c => c.Users);
    }
  }
}
