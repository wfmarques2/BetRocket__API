using Microsoft.AspNetCore.Authorization;


namespace Application.Authorization;

public class IsAdminAuthorization : AuthorizationHandler<IsAdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
    {
        var isAdminClaim = context.User.FindFirst("isAdmin");

        if (isAdminClaim is null)
            throw new Exception("Houve um erro");

        var isAdmin = Convert.ToBoolean(isAdminClaim.Value);

        if (!isAdmin)
            throw new Exception("Houve um erro");

        context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
