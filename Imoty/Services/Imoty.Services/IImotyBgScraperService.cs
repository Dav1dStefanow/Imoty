namespace Imoty.Services
{
    using System.Threading.Tasks;

    public interface IImotyBgScraperService
    {
        Task PopulateDbWithProperiesAsync(string link);
    }
}
