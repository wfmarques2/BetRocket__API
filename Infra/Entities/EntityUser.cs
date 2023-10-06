using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infra.Entities;

public class EntityUser : IdentityUser
{
    public DateTime BirthDate { get; set; }

    public decimal Balance { get; set; }

    public bool IsAdmin { get; set; }

    public ICollection<EntityBet> Bets { get; set; }
         
    public EntityUser() : base()
    {
        Bets = new List<EntityBet>();
    }

    public static implicit operator EntityUser(ModelUser modelUser)
    {
        return new EntityUser
        {
            Id = modelUser.Id.ToString(),
            UserName = modelUser.Username,
            PasswordHash = modelUser.Password,
            BirthDate = modelUser.BirthDate,
            Balance = modelUser.Balance,
            IsAdmin = modelUser.IsAdmin
        };
    }

    public static implicit operator ModelUser(EntityUser entityUser)
    {
        return new ModelUser
            (
            username: entityUser.UserName,
            birthDate: entityUser.BirthDate,
            password: entityUser.PasswordHash
            )
        {
            Id = Guid.Parse(entityUser.Id),
            Password = entityUser.PasswordHash,
            BirthDate = entityUser.BirthDate,
            Balance = entityUser.Balance,
            IsAdmin = entityUser.IsAdmin
        };
    }
}

