using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface ISquadRepository
{
    Task CreateAsync(ModelSquad modelSquad);

    Task<ModelSquad> UpdateAsync(ModelSquad modelSquad);

    Task Delete(ModelSquad modelSquad);

    Task<ModelSquad?> FindById(Guid id);

    Task<ICollection<ModelSquad>> FindAll();
}
