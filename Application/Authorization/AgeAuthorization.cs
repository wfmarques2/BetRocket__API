using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Application.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinAgeRequirement>
{
    protected override Task HandleRequirementAsync
       (AuthorizationHandlerContext context,
       MinAgeRequirement requirement)
    {
        var BirhDateClaim = context.User.FindFirst(claim =>
        claim.Type is ClaimTypes.DateOfBirth);

        if (BirhDateClaim is null)
            return Task.CompletedTask;

        var BirthDate = Convert
            .ToDateTime(BirhDateClaim.Value);

        var userAge = DateTime.Today.Year - BirthDate.Year;

        if (BirthDate >
            DateTime.Today.AddYears(-userAge))
            userAge--;

        //Arrumar dps
        if (userAge < requirement.age)
            throw new Exception();

        context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
