using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DatabaseCommunication;

namespace DataLayer
{
    public class MestoDao : IMestoDao
    {
        private Context Context { get; set; }

        public MestoDao(Context context)
        {
            Context = context;
        }

        public async Task<List<Mesto>> PreuzmiZauzetaMestaCitaonice(int citaonicaId)
        {
            try
            {
                return await Context.Mesta
                                    .Include(m => m.Citaonica)
                                    .Include(m => m.Citanja)
                                    .Where(m => m.Zauzeto == true && m.Citaonica.Id == citaonicaId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Mesto>> PreuzmiMestaCitaonice(int citaonicaId)
        {
            try
            {
                return await Context.Mesta
                                    .Include(m => m.Citaonica)
                                    .Include(m => m.Citanja)
                                    .Where(m => m.Citaonica.Id == citaonicaId)
                                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Mesto> PreuzmiMestoPoId(int mestoId)
        {
            try
            {
                return await Context.Mesta
                                    .Include(m => m.Citaonica)
                                    .Where(m => m.Id == mestoId)
                                    .Include(m => m.Citanja)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Mesto> DodajMesto(Mesto mesto)
        {
            try
            {
                Context.Mesta.Add(mesto);
                await Context.SaveChangesAsync();
                return mesto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Mesto> SacuvajIzmeneMesta(Mesto mesto)
        {
            try
            {
                Context.Mesta.Update(mesto);
                await Context.SaveChangesAsync();
                return mesto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ObrisiMesto(Mesto mesto)
        {
            try
            {
                Context.Mesta.Remove(mesto);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Mesto> PreuzmiMestoUCitaoniciNaLokaciji(int citaonicaId, int x, int y)
        {
            try
            {
                return await Context.Mesta
                                    .Include(m => m.Citaonica)
                                    .Include(m => m.Citanja)
                                    .Where(m => m.Citaonica.Id == citaonicaId && m.X == x && m.Y == y)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}