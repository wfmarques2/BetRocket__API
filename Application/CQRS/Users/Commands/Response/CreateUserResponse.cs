using Application.CQRS.Users.Commands.Request;
using Domain.Models;

namespace Application.CQRS.Users.Commands.Response;

public class CreateUserResponse
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public DateTime BirthDate { get; set; }

    public decimal Balance { get; set; }

    public static implicit operator CreateUserResponse(ModelUser modelUser)
    {
        return new CreateUserResponse
        {
            Id = modelUser.Id,
            UserName = modelUser.Username,
            BirthDate = modelUser.BirthDate,
            Balance = modelUser.Balance
        };
    }
}
