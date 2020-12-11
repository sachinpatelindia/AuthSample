using AuthSample.Helpers;
using AuthSample.Requirement;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace AuthSample.Handlers
{
    public class CustomAuthHandler : AuthorizationHandler<CustomAuthStatusRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthStatusRequirement requirement)
        {
            var claim = context.User.FindFirst(u => u.Type == "IsBlocked" && u.Issuer == TokenHelper.Issuer);
            if (!context.User.HasClaim(u => u.Type == "IsBlocked" && u.Issuer == TokenHelper.Issuer))
                return Task.CompletedTask;
            string value = claim.Value;
            var userblocked = Convert.ToBoolean(value);
            if (userblocked == requirement.IsBlocked)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
