using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerzenHelper.UniversityService.Models.Db
{
    public class DbUniversitySettings
    {
        public const string TableName = "UniversitySettings";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public DbUniversity University { get; set; }
    }

    public class DbUniversitySettingsConfiguration : IEntityTypeConfiguration<DbUniversitySettings>
    {
        public void Configure(EntityTypeBuilder<DbUniversitySettings> builder)
        {
            builder
                .ToTable(DbUniversitySettings.TableName);

            builder
                .HasKey(x => x.Id);


            builder
                .HasOne(x => x.University)
                .WithOne(x => x.Settings);
        }
    }
}
