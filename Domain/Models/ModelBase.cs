namespace Domain.Models;

public abstract class ModelBase
{
    public Guid Id { get; set; }

    public ModelBase()
    {
        Id = Guid.NewGuid();
    }
}
