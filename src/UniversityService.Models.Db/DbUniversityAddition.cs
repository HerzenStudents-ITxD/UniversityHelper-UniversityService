using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHelper.UniversityService.Models.Db
{
    public class DbUniversityAddition
    {
        public const string TableName = "UniversityAddictions";

        public Guid Id { get; set; }

        public string Locale { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public DbUniversity University { get; set; }
    }

    public class DbUniversityAdditionConfiguration : IEntityTypeConfiguration<DbUniversityAddition>
    {
        public void Configure(EntityTypeBuilder<DbUniversityAddition> builder)
        {
            builder
                .ToTable(DbUniversityAddition.TableName);

            builder
                .HasKey(x => x.Id);


            builder
                .HasOne(x => x.University)
                .WithMany(x => x.Additions);
        }
    }
}
