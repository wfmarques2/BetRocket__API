namespace Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
    public Task Rollback();
}
