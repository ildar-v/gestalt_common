namespace Gestalt.Common.DAL.MongoDBImpl
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public interface IIdentifiable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}