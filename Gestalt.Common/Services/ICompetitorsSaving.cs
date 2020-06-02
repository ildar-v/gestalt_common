namespace Gestalt.Common.Services
{
    using System.Threading.Tasks;
    using Gestalt.Common.Models;

    public interface IRequestsService
    {
        Task<bool> SaveAsync(MainResponse model);

        Task<MainResponse> GetAsync(string maxId);
    }
}
