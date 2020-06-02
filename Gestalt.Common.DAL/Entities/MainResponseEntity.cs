namespace Gestalt.Common.DAL.Entities
{
    using Gestalt.Common.DAL.MongoDBImpl;
    using Gestalt.Common.Models;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MainResponseEntity : MainResponse, IIdentifiable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
