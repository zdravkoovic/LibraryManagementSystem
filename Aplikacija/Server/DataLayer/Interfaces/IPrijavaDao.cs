using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataLayer.Interfaces
{
    public interface IPrijavaDao
    {
        public Task<List<Prijava>> PreuzmiPrijaveRadnika(int radnikId);
        public Task<Prijava> DodajPrijavu(Prijava prijava);
        public Task<Prijava> PreuzmiPrijavuPoId(int prijavaId);
        public Task<Prijava> SacuvajIzmenePrijave(Prijava prijava);
        public Task<Prijava> PreuzmiTrenutnuPrijavuRadnika(int radnikId);
    }
}