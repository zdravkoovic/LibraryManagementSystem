using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISlikaService
    {
        public Task<bool> ObrisiSliku(string link);
        public Task<bool> ObrisiSlike(List<string> linkovi);
    }
}