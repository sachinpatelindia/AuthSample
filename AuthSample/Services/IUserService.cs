using AuthSample.Request;
using AuthSample.Response;
using System.Threading.Tasks;

namespace AuthSample.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
