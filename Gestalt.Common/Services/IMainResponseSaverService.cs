namespace Gestalt.Common.Services
{
    using System.Threading.Tasks;
    using Gestalt.Common.Models;

    public interface IMainResponseSaverService
    {
        Task SaveMainResponse(MainResponse model);
    }
}