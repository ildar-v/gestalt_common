namespace Gestalt.Common.DAL.MongoDBImpl
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public interface IIdentifiable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId MyId { get; set; }
    }
}