using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.EFSupport.Provider;
using HerzenHelper.Core.Enums;
using HerzenHelper.UniversityService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.UniversityService.Data.Provider
{
    [AutoInject(InjectType.Scoped)]
    public interface IDataProvider : IBaseDataProvider
    {
        public DbSet<DbUniversity> Universities { get; set; }
        public DbSet<DbUniversityAddition> UniversityAdditions { get; set; }
    }
}
