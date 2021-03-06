using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumanitarianAssistance.WebApi.Auth
{
    public interface IJwtFactory
    {
    Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
    ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
  }
}
