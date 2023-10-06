using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities;

[Table("AccessRequest")]
public class EntityAdministrativeAccessRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public ModelAskForAdminAccess User { get; set; }

    public EntityAdministrativeAccessRequest()
    {
        User = new ModelAskForAdminAccess();
    }

    public static implicit operator EntityAdministrativeAccessRequest(ModelAskForAdminAccess request)
    {
        return new EntityAdministrativeAccessRequest
        {
            Id = request.Id,
            User = new ModelAskForAdminAccess(
                request.Username,
                request.BirthDate,
                request.Password
                )
        };
    }

    public static implicit operator ModelAskForAdminAccess(EntityAdministrativeAccessRequest request)
    {
        return new ModelAskForAdminAccess
        {
            Id = request.Id,
            Username = request.User.Username,
            BirthDate = request.User.BirthDate,
            Password = request.User.Password
        };
    }
}
