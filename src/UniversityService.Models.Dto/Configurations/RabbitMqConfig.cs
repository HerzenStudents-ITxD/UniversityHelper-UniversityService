using UniversityHelper.Core.BrokerSupport.Attributes;
using UniversityHelper.Core.BrokerSupport.Configurations;
using UniversityHelper.Models.Broker.Common;
using UniversityHelper.Models.Broker.Requests.Auth;
using UniversityHelper.Models.Broker.Requests.Company;
using UniversityHelper.Models.Broker.Requests.Department;
using UniversityHelper.Models.Broker.Requests.Email;
using UniversityHelper.Models.Broker.Requests.Image;
using UniversityHelper.Models.Broker.Requests.Office;
using UniversityHelper.Models.Broker.Requests.Position;
using UniversityHelper.Models.Broker.Requests.Rights;
using UniversityHelper.Models.Broker.Requests.TextTemplate;
using UniversityHelper.Models.Broker.Requests.User;

namespace UniversityHelper.UniversityService.Models.Dto.Configurations
{
  public class RabbitMqConfig : ExtendedBaseRabbitMqConfig
  {
    public string CreateUniversityUserEndpoint { get; set; }
    public string GetUniversitiesEndpoint { get; set; }
    public string DisactivateUniversityUserEndpoint { get; set; }
    public string ActivateUniversityUserEndpoint { get; set; }


    // user

    [AutoInjectRequest(typeof(IGetUsersDataRequest))]
    public string GetUsersDataEndpoint { get; set; }

    [AutoInjectRequest(typeof(ICheckUsersExistence))]
    public string CheckUsersExistenceEndpoint { get; set; }

    // image

    [AutoInjectRequest(typeof(IGetImagesRequest))]
    public string GetImagesEndpoint { get; set; }
  }
}
