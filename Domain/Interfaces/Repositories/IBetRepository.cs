using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IBetRepository
{
    Task CreateAsync(ModelBet modelBet);

    Task UpdateAsync(ModelBet modelBet);

    Task Delete(ModelBet modelBet);

    Task<ModelBet?> FindById(Guid id);

    Task<ICollection<ModelBet>> FindAllInMatch(Guid Id);

    Task<ICollection<ModelBet>> FindAll(Guid Id);
}
