using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IMatchRepository
{
    Task CreateAsync(ModelMatch modelMatch);

    Task<ModelMatch> UpdateAsync(ModelMatch modelMatch);

    Task Delete(ModelMatch modelMatch);

    Task<ModelMatch?> FindById(Guid id);

    Task<ICollection<ModelMatch>> FindAll();
}
