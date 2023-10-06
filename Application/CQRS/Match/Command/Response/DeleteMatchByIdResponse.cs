using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;

namespace Application.CQRS.Match.Command.Response;

public class DeleteMatchByIdResponse
{
    public bool Succeed { get; set; }
}
