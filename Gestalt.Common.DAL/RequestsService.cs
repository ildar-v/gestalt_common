namespace Gestalt.Common.DAL
{
    using System.Threading.Tasks;
    using Gestalt.Common.DAL.Entities;
    using Gestalt.Common.DAL.MongoDBImpl;
    using Gestalt.Common.Models;
    using Gestalt.Common.Services;
    using Newtonsoft.Json;

    public class RequestsService : IRequestsService
    {
        private readonly IMongoRepository<MainResponseEntity> _savingSchemeRepository;

        public RequestsService(IMongoRepository<MainResponseEntity> savingSchemeRepository)
        {
            _savingSchemeRepository = savingSchemeRepository;
        }

        public async Task<bool> SaveAsync(MainResponse model)
        {
            var entity = new MainResponseEntity();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(model), entity);

            await _savingSchemeRepository.AddAsync(entity);
            return true;
        }

        public async Task<MainResponse> GetAsync(string maxId)
        {
            return await _savingSchemeRepository.GetAsync(x => x.max_id == maxId);
        }
    }
}
