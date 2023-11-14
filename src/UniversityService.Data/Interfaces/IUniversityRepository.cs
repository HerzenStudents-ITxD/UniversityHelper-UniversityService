using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.UniversityService.Models.Db;
using UniversityHelper.UniversityService.Models.Dto.Requests.Filters;

namespace UniversityHelper.UniversityService.Data.Interfaces
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
