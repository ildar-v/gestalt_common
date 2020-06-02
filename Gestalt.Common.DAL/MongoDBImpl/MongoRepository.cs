namespace Gestalt.Common.DAL.MongoDBImpl
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    public class MongoRepository<T> : IMongoRepository<T> where T : IIdentifiable
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(MongoSettings settings)
        {
            Console.WriteLine("Trying to connect mongo...");
            var client = new MongoClient(settings.ConnectionString);
            Console.WriteLine("Client created.");
            var database = client.GetDatabase(settings.DatabaseName);
            Console.WriteLine("Database getted.");
            _collection = database.GetCollection<T>(settings.CollectionName);
            Console.WriteLine("Collection getted.");
        }

        public async Task<T> GetAsync(string id)
            => await GetAsync(e => e.Id == id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await _collection.Find(predicate).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _collection.Find(predicate).ToListAsync();

        public async Task<IEnumerable<T>> FindAsync()
            => await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();

        public async Task AddAsync(T entity)
            => await _collection.InsertOneAsync(entity);

        public async Task AddAsync(IEnumerable<T> entity)
            => await _collection.InsertManyAsync(entity);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
            => await _collection.Find(predicate).AnyAsync();

        public async Task UpdateAsync(T agreement)
            => await _collection.ReplaceOneAsync(a => a.Id == agreement.Id, agreement);

        public async Task DropCollection()
            => await _collection.Database.DropCollectionAsync(_collection.CollectionNamespace.CollectionName);
    }
}