using AuthSample.Requirement;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AuthSample.Handlers
{
    public class CustomAuthHandler : AuthorizationHandler<CustomAuthStatusRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthStatusRequirement requirement)
        {
            return Task.CompletedTask;
        }
    }
}
