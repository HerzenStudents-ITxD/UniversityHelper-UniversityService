using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.UniversityService.Models.Db
{
  public class DbUniversity
  {
    public const string TableName = "Universities";

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Tagline { get; set; }
    public string Contacts { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public bool IsActive { get; set; }
    public bool InDevelop { get; set; }

    public ICollection<DbUniversityAddition> Additions { get; set; }
    public ICollection<DbUniversityUser> Users { get; set; }

    public DbUniversitySettings Settings { get; set; }

    public DbUniversity()
    {
      Additions = new HashSet<DbUniversityAddition>();
      Users = new HashSet<DbUniversityUser>();
    }
  }

  public class DbUniversityConfiguration : IEntityTypeConfiguration<DbUniversity>
  {
    public void Configure(EntityTypeBuilder<DbUniversity> builder)
    {
      builder
          .ToTable(DbUniversity.TableName);

      builder
          .HasKey(x => x.Id);


      builder
          .HasMany(x => x.Additions)
          .WithOne(x => x.University);

      builder
          .HasOne(x => x.Settings)
          .WithOne(x => x.University);
    }
  }
}
