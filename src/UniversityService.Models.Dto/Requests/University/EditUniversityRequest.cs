using UniversityHelper.UniversityService.Models.Dto.Models;

namespace UniversityHelper.UniversityService.Models.Dto.Requests.Company
{
  public record EditUniversityRequest
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Tagline { get; set; }
    public string Contacts { get; set; }
    public ImageConsist Logo { get; set; }
  }
}
