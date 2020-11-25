
namespace MedicalBillingApi.Interfaces
{
    public interface ITokenFactory
    {
        string GenerateToken(int size= 32);
    }
}
