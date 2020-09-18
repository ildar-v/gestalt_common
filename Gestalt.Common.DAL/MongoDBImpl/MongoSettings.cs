namespace Gestalt.Common.DAL.MongoDBImpl
{
    public class MongoSettings<T> where T : IIdentifiable
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}