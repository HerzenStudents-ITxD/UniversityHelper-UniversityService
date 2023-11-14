using System;
using UniversityHelper.Models.Broker.Enums;

namespace UniversityHelper.UniversityService.Models.Dto.Requests.CompanyUser
{
  public class CreateUniversityUserRequest
  {
    public Guid UserId { get; set; }
    public Guid UniversityId { get; set; }
  }
}
