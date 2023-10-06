using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;

public class MinAgeRequirement : IAuthorizationRequirement
{
    public readonly int age = 18;
}
