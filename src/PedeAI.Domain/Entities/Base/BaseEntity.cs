using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PedeAI.Domain.Entities.Base;

public abstract class BaseEntity
{
    public virtual string? Id { get; private set; }
    public DateTime CreatedAt { get; } = DateTime.Now;
    public void SetId(string id) =>
        Id = id;
}