namespace Gestalt.Common.DAL
{
    using System;
    using Gestalt.Common.DAL.Entities;
    using Gestalt.Common.DAL.MongoDBImpl;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class MongoExtension
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoPort =
                Environment.GetEnvironmentVariable("MONGO_PORT")
                ?? configuration["Environment:MONGO_PORT"]
                ?? "27017";
            var mongoImageName =
                Environment.GetEnvironmentVariable("MONGO_HOST_NAME")
                ?? configuration["Environment:MONGO_HOST_NAME"]
                ?? "localhost";
            var mongoCollectionName =
                Environment.GetEnvironmentVariable("MONGO_COLLECTION_NAME")
                ?? configuration["Environment:MONGO_COLLECTION_NAME"]
                ?? "schemes";
            var mongoDatabaseName =
                Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME")
                ?? configuration["Environment:MONGO_DATABASE_NAME"]
                ?? "competitors";
            var mongoUsername =
                Environment.GetEnvironmentVariable("MONGO_USERNAME")
                ?? configuration["Environment:MONGO_USERNAME"]
                ?? "root";
            var mongoPassword =
                Environment.GetEnvironmentVariable("MONGO_PASSWORD")
                ?? configuration["Environment:MONGO_PASSWORD"]
                ?? "root";

            var mongoUrl = $"mongodb://{mongoUsername}:{mongoPassword}@{mongoImageName}:{mongoPort}";
            var mongoSettings = new MongoSettings()
            {
                ConnectionString = mongoUrl,
                CollectionName = mongoCollectionName,
                DatabaseName = mongoDatabaseName
            };
            services.AddSingleton(mongoSettings);
            services.AddSingleton<IMongoRepository<MainResponseEntity>, MongoRepository<MainResponseEntity>>();
            return services;
        }
    }
}