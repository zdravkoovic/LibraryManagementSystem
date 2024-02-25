using System;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DatabaseCommunication;
using Parameters;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnjigaController : ControllerBase
    {
        private IKnjigaService KnjigaService { get; set; }

        public KnjigaController(IKnjigaService knjigaService)
        {
            KnjigaService = knjigaService;
        }

        [HttpGet]
        [Route("PreuzmiKnjiguPoId")]
        public async Task<ActionResult> PreuzmiKnjiguPoId(int knjigaId)
        {
            try
            {
                var result = await KnjigaService.PreuzmiKnjiguPoId(knjigaId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiKnjige")]
        public async Task<ActionResult> PreuzmiKnjige(string zanrovi, string rodovi, string vrste, string jezici, bool slobodna, int page, string pretraga)
        {
            try
            {
                var result = await KnjigaService.PreuzmiKnjige(zanrovi, rodovi, vrste, jezici, slobodna, page, pretraga);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PretraziKnjige")]
        public async Task<ActionResult> PretraziKnjige(string pretraga, int page)
        {
            try
            {
                var result = await KnjigaService.PretraziKnjige(pretraga, page);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));                
            }
        }

        [HttpGet]
        [Route("PreuzmiSveKnjigeAutora")]
        public async Task<ActionResult> PreuzmiSveKnjigeAutora(int autorId)
        {
            try
            {
                var result = await KnjigaService.PreuzmiSveKnjigeAutora(autorId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));                
            }
        }

        [HttpGet]
        [Route("PreuzmiKnjigeKojeCekaKorisnik")]
        public async Task<ActionResult> PreuzmiKnjigeKojeCekaKorisnik(int korisnikId)
        {
            try
            {
                var result = await KnjigaService.PreuzmiKnjigeKojeCekaKorisnik(korisnikId);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }


        [HttpPost]
        [Route("DodajKnjigu")]
        public async Task<ActionResult> DodajKnjigu([FromForm] KnjigaParametri knjigaParametri)
        {
            try
            {
                var result = await KnjigaService.DodajKnjigu(knjigaParametri);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));                
            }
        }

        [HttpPut]
        [Route("IzmeniKnjigu")]
        public async Task<ActionResult> IzmeniKnjigu(int knjigaId, KnjigaParametri knjigaParametri)
        {
            try
            {
                var result = await KnjigaService.IzmeniKnjigu(knjigaId, knjigaParametri);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));                
            }
        }

        [HttpDelete]
        [Route("ObrisiKnjigu")]
        public async Task<ActionResult> ObrisiKnjigu(int knjigaId)
        {
            try
            {
                var result = await KnjigaService.ObrisiKnjigu(knjigaId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));                
            }
        }

        [HttpPost]
        [Route("DodajSlikuKnjizi")]
        public async Task<ActionResult> DodajSlikuKnjizi(int knjigaId, [FromForm] SlikaParametar slika)
        {
            try
            {
                KnjigaPrikaz result = await KnjigaService.DodajSlikuKnjizi(knjigaId, slika);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}