using AuthSample.Helpers;
using AuthSample.Model;
using AuthSample.Request;
using AuthSample.Response;
using System;
using System.Threading.Tasks;

namespace AuthSample.Services
{
    public class UserService : IUserService
    {
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = GetUser();
            if (user == null)
                return null;
            // var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password,);
            var token = await Task.Run(() => TokenHelper.GenerateTokern(user));
            return new LoginResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                UserName = user.UserName
            };
        }

        private UserModel GetUser()
        {
            return new UserModel
            {
                IsBlocked = false,
                UserId = 1,
                Password = "Sachin@123",
                UserName = "sachin@example.com",
                FirstName = "Sachin",
                LastName = "Patel"
            };
        }
    }
}
