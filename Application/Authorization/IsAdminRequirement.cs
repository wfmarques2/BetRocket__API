using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;

public class IsAdminRequirement : IAuthorizationRequirement
{
    public readonly bool isAdmin = true;
}
