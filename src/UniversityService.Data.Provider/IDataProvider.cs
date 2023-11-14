using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using UniversityHelper.Core.Enums;
using UniversityHelper.UniversityService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.UniversityService.Data.Provider
{
    [AutoInject(InjectType.Scoped)]
    public interface IDataProvider : IBaseDataProvider
    {
        public DbSet<DbUniversity> Universities { get; set; }
        public DbSet<DbUniversityAddition> UniversityAdditions { get; set; }
    }
}
