using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Pokemon
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID { get; set; }
    public string? Name { get; set; }
    public string? Ability { get; set; }
    public string? Level { get; set; }
}