
using MedicalBillingApi.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalBillingApi.Auth
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}
