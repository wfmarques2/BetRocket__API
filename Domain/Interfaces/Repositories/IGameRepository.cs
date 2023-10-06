using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IGameRepository
{
    Task CreateAsync(ModelGame modelGame);

    Task<ModelGame> UpdateAsync(ModelGame modelGame);

    Task Delete(ModelGame modelGame);

    Task<ModelGame?> FindById(Guid id);

    Task<ICollection<ModelGame>> FindAll();
}
