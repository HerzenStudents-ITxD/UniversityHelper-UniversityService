using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.Extensions;
using UniversityHelper.UniversityService.Data.Interfaces;
using UniversityHelper.UniversityService.Data.Provider;
using UniversityHelper.UniversityService.Models.Db;
using UniversityHelper.UniversityService.Models.Dto.Requests.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.UniversityService.Data
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly IDataProvider _provider;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public UniversityRepository(
          IDataProvider provider//,
          //IHttpContextAccessor httpContextAccessor
            )
        {
            _provider = provider;
            //_httpContextAccessor = httpContextAccessor;
        }

        public Task CreateAsync(DbUniversity dbUniversity)
        {
            if (dbUniversity is null)
            {
                return null;
            }

            _provider.Universities.Add(dbUniversity);
            return _provider.SaveAsync();
        }

        public async Task<DbUniversity> GetAsync()
        {
            return null;
            //return (await
            //  (from location in _provider.Locations
            //   join addition in _provider.LocationAdditions on location.Id equals addition.Location.Id
            //   join label in _provider.LocationLabels on location.Id equals label.Location.Id
            //   join photo in _provider.LocationPhotos on location.Id equals photo.Location.Id
            //   join position in _provider.LocationUnityPositions on location.Id equals position.LocationId
            //   join objectName in _provider.LocationUnityObjectName on location.Id equals objectName.Location.Id
            //   where location.Id == filter.LocationId
            //     && (addition.Locale == filter.Locale)
            //     && (label.Locale == filter.Locale)
            //   select new
            //   {
            //       Location = location
            //   }).ToListAsync()).AsEnumerable().GroupBy(r => r.Location.Id)
            //   .Select(x =>
            //   {
            //       DbLocation location = x.Select(x => x.Location).FirstOrDefault();
            //       location.Additions = x.Select(x => x.Additions).Where(x => x != null).GroupBy(x => x.Id).Select(x => x.First()).ToList();

            //       return (location, x.Select(x => x.User).Where(u => u is not null && u.IsActive).ToList(), x.Select(x => x.RightLocalization).ToList());
            //   }).FirstOrDefault();
        }

        public Task<bool> DoesExistAsync(Guid universityId)
        {
            return _provider.Universities.AnyAsync(r => r.Id == universityId);
        }

        public async Task<bool> EditStatusAsync(Guid universityId, bool isActive)
        {
            DbUniversity university = _provider.Universities.FirstOrDefault(x => x.Id == universityId);

            if (university is null)
            {
                return false;
            }

            _provider.Locations.Update(university);

            university.IsActive = isActive;
            university.CreatedBy = 0;// _httpContextAccessor.HttpContext.GetUserId();

            await _provider.SaveAsync();

            return true;
        }

        public Task<List<DbUniversity>> FindAllAsync()
        {
            return _provider.Universities;
        }
    }
}
