using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PedeAI.Domain.Entities.Base;

public abstract class BaseEntity
{
    [BsonElement("Id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    public virtual string? Id { get; private set; }

    public void SetId(string id) =>
        Id = id;
}