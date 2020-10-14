using System;
using System.Collections.Generic;
using Gestalt.Common.DAL.Entities;
using Gestalt.Common.DAL.MongoDBImpl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Gestalt.Common.DAL
{
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

            var requestListCollectionName =
                configuration["Environment:REQUESTLIST_COLLECTION_NAME"]
                ?? Environment.GetEnvironmentVariable("REQUESTLIST_COLLECTION_NAME")
                ?? "requestlist";
            var requestListMongoSettings = new MongoSettings<RequestListEntity>()
            {
                ConnectionString = url,
                CollectionName = requestListCollectionName,
                DatabaseName = databaseName
            };
            services.AddSingleton(requestListMongoSettings);
            services.AddSingleton<IMongoRepository<RequestListEntity>, MongoRepository<RequestListEntity>>();

            var requestCollectionName =
                configuration["Environment:REQUEST_COLLECTION_NAME"]
                ?? Environment.GetEnvironmentVariable("REQUEST_COLLECTION_NAME")
                ?? "request";
            var requestMongoSettings = new MongoSettings<RequestEntity>()
            {
                ConnectionString = url,
                CollectionName = requestCollectionName,
                DatabaseName = databaseName
            };
            services.AddSingleton(requestMongoSettings);
            services.AddSingleton<IMongoRepository<RequestEntity>, MongoRepository<RequestEntity>>();
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