using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;
using HerzenHelper.UniversityService.Models.Db;
using HerzenHelper.UniversityService.Models.Dto.Requests.Filters;

namespace HerzenHelper.UniversityService.Data.Interfaces
{
    [AutoInject]
    public interface IUniversityRepository
    {
        Task CreateAsync(DbUniversity dbUniversity);

        Task<DbUniversity> GetAsync();

        Task<List<DbUniversity>> FindAllAsync();

        Task<bool> DoesExistAsync(Guid universityId);

        Task<bool> EditStatusAsync(Guid universityId, bool isActive);
    }
}
