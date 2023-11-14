using System.Reflection;
using System.Threading.Tasks;
using UniversityHelper.UniversityService.Data.Provider;
using UniversityHelper.UniversityService.Models.Db;
using UniversityHelper.Core.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.UniversityService.Data.Provider.MsSql.Ef
{
    public class UniversityServiceDbContext : DbContext, IDataProvider
    {
        public DbSet<DbUniversity> Universities { get; set; }
        public DbSet<DbUniversityAddition> UniversityAdditions { get; set; }
        public DbSet<DbUniversitySettings> UniversitySettings { get; set; }

        public UniversityServiceDbContext(DbContextOptions<UniversityServiceDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("UniversityHelper.UniversityService.Models.Db"));
        }

        public object MakeEntityDetached(object obj)
        {
            Entry(obj).State = EntityState.Detached;

            return Entry(obj).State;
        }

        void IBaseDataProvider.Save()
        {
            SaveChanges();
        }

        public void EnsureDeleted()
        {
            Database.EnsureDeleted();
        }

        public bool IsInMemory()
        {
            return Database.IsInMemory();
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}
