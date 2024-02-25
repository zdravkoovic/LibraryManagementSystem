using System.Threading.Tasks;
using ClientModels.Prikaz;

namespace Services.Interfaces
{
    public interface IStatistikaService
    {
        public Task<StatistikaPrikaz> PreuzmiStatistiku();
    }
}