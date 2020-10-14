using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gestalt.Common.DAL.MongoDBImpl
{
    public interface IIdentifiable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId EntityId { get; set; }
    }
}