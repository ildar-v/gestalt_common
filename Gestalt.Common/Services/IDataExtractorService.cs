namespace Gestalt.Common.Services
{
    using System.Threading.Tasks;

    public interface IDataExtractorService
    {
        Task WriteToFileFromApi();

        Task ReadFromFile();
    }
}