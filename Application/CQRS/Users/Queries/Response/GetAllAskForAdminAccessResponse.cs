using Domain.Models;
using Infra.Entities;

namespace Application.CQRS.Users.Queries.Response;

public class GetAllAskForAdminAccessResponse
{
    public ICollection<ModelAskForAdminAccess> AdminAccessRequests { get; set; }
}
