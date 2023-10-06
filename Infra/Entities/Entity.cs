using System.ComponentModel.DataAnnotations;

namespace Infra.Entities;

public abstract class Entity
{
    [Required]
    public Guid Id { get; set; }

    public Entity()
    {
        
    }
}
