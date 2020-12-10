using AuthSample.Request;
using AuthSample.Response;
using System;
using System.Threading.Tasks;

namespace AuthSample.Services
{
    public class UserService : IUserService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
