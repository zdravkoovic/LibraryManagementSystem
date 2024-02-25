using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAzuriranjeService
    {
        public Task<bool> AzurirajStanje();
    }
}