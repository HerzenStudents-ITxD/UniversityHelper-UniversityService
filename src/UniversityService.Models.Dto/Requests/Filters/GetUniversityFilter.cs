using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.UniversityService.Models.Dto.Requests.Filters;

public record GetUniversityFilter
{
  [FromQuery(Name = "includenotactive")]
  public bool IncludeNotActive { get; set; } = false;
  [FromQuery(Name = "includedeveloped")]
  public bool IncludeDeveloped { get; set; } = false;
}
