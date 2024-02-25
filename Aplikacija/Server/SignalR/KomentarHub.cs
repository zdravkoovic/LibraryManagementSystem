using System.Threading.Tasks;
using DataLayer.Interfaces;
using Mappers;
using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class KomentarHub : Hub
    {
        private IKomentarDao KomentarDao { get; set; }

        public KomentarHub(IKomentarDao komentarDao)
        {
            KomentarDao = komentarDao;
        }

        public async Task NoviKomentar(int komentarId)
        {
            var komentar = await KomentarDao.PreuzmiKomentarPoId(komentarId);
            await Clients.All.SendAsync("noviKomentar", new { KomentarPrikaz = KomentarMapper.KomentarToKomentarPrikaz(komentar) });
        }

        public async Task IzmenjenKomentar(int komentarId)
        {
            var komentar = await KomentarDao.PreuzmiKomentarPoId(komentarId);
            await Clients.All.SendAsync("izmenjenKomentar", new { KomentarPrikaz = KomentarMapper.KomentarToKomentarPrikaz(komentar) });
        }

        public async Task ObrisanKomentar(int knjigaId, int komentarId)
        {
            await Clients.All.SendAsync("obrisanKomentar", new { KnjigaId = knjigaId, KomentarId = komentarId }); 
        }
    }
}