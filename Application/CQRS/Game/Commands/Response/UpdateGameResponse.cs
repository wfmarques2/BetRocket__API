using Domain.Models;

namespace Application.CQRS.Game.Commands.Response;

public class UpdateGameResponse
{
    public ModelGame Game { get; set; } 
}