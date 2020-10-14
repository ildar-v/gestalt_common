using System.Threading.Tasks;

namespace Gestalt.Common.Services
{
    public interface IDataService
    {
        Task WriteToFileFromApi();

        Task ReadFromFile();
    }
}