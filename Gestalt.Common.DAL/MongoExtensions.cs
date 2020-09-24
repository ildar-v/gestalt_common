namespace Gestalt.Common.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Gestalt.Common.DAL.Entities;
    using Gestalt.Common.DAL.MongoDBImpl;
    using Gestalt.Common.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public static class MongoExtension
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var port =
                configuration["Environment:MONGO_PORT"]
                ?? Environment.GetEnvironmentVariable("MONGO_PORT")
                ?? "27017";
            var imageName =
                configuration["Environment:MONGO_HOST_NAME"]
                ?? Environment.GetEnvironmentVariable("MONGO_HOST_NAME")
                ?? "localhost";
            var databaseName =
                configuration["Environment:MONGO_DATABASE_NAME"]
                ?? Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME")
                ?? "gestalt";
            var username =
                configuration["Environment:MONGO_USERNAME"]
                ?? Environment.GetEnvironmentVariable("MONGO_USERNAME")
                ?? "root";
            var password =
                configuration["Environment:MONGO_PASSWORD"]
                ?? Environment.GetEnvironmentVariable("MONGO_PASSWORD")
                ?? "root";
            var url = $"mongodb://{username}:{password}@{imageName}:{port}";

            var requestsCollectionName =
                configuration["Environment:REQUESTS_COLLECTION_NAME"]
                ?? Environment.GetEnvironmentVariable("REQUESTS_COLLECTION_NAME")
                ?? "requests";
            var requestsMongoSettings = new MongoSettings<MainResponseEntity>()
            {
                ConnectionString = url,
                CollectionName = requestsCollectionName,
                DatabaseName = databaseName
            };
            services.AddSingleton(requestsMongoSettings);
            services.AddSingleton<IMongoRepository<MainResponseEntity>, MongoRepository<MainResponseEntity>>();

            var queriesCollectionName =
                configuration["Environment:QUERIES_COLLECTION_NAME"]
                ?? Environment.GetEnvironmentVariable("QUERIES_COLLECTION_NAME")
                ?? "requests";
            var queriesSettings = new MongoSettings<QueryEntity>()
            {
                ConnectionString = url,
                CollectionName = queriesCollectionName,
                DatabaseName = databaseName
            };
            services.AddSingleton(queriesSettings);
            services.AddSingleton<IMongoRepository<QueryEntity>, MongoRepository<QueryEntity>>();
            return services;
        }

        public static TEntity ToEntity<TEntity, T>(this T model) where TEntity : T, IIdentifiable, new()
        {
            var entity = new TEntity();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(model), entity);
            return entity;
        }

        public static IEnumerable<TEntity> ToEntities<TEntity, T>(this IEnumerable<T> models)
            where TEntity : T, IIdentifiable, new()
        {
            var entities = new List<TEntity>();
            foreach (var model in models)
            {
                var entity = new TEntity();
                JsonConvert.PopulateObject(JsonConvert.SerializeObject(model), entity);
                entities.Add(entity);
            }

            return entities;
        }
    }
}