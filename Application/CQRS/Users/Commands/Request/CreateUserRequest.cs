using Application.CQRS.Users.Commands.Response;
using Domain.Models;
using Infra.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Users.Commands.Request;

public class CreateUserRequest : CreateRequest, IRequest<CreateUserResponse>
{


    public static implicit operator ModelUser(CreateUserRequest request)
    {
        return new ModelUser(
            username: request.Username,
            password: request.Password,
            birthDate: request.BirthDate
            );
    }

    public static implicit operator EntityUser(CreateUserRequest request)
    {
        return new EntityUser
        {
            UserName = request.Username,
            BirthDate = request.BirthDate,
        };
    }
}
