using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task CreateAsync(ModelPlayer modelPlayer);

    Task<ModelPlayer> UpdateAsync(ModelPlayer modelPlayer);

    Task Delete(ModelPlayer modelPlayer);

    Task<ModelPlayer?> FindById(Guid id);

    Task<ICollection<ModelPlayer>> FindAll();
}
