using Microsoft.AspNetCore.Authorization;

namespace AuthSample.Requirement
{
    public class CustomAuthStatusRequirement:IAuthorizationRequirement
    {
        public bool IsBlocked { get; set; }

        public CustomAuthStatusRequirement(bool isBlocked)
        {
            IsBlocked = isBlocked;
        }
    }
}
