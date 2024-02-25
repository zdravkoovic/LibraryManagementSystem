using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Parameters;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {
        private IKorisnikService KorisnikService { get; set; }

        public KorisnikController(IKorisnikService korisnikService)
        {
            KorisnikService = korisnikService;
        }

        [HttpGet]
        [Route("PretraziKorisnike")]
        public async Task<ActionResult> PretraziKorisnike(string pretraga)
        {
            try
            {
                List<KorisnikPrikaz> result = await KorisnikService.PretraziKorisnike(pretraga);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiKorisnikaPoId")]
        public async Task<ActionResult> PreuzmiKorisnikaPoId(int korisnikId)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.PreuzmiKorisnikaPoId(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajKorisnika")]
        public async Task<ActionResult> DodajKorisnika([FromBody] KorisnikParametri korisnikParametri)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.DodajKorisnika(korisnikParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("IzmeniLozinkuKorisnika")]
        public async Task<ActionResult> IzmeniLozinkuKorisnika(int korisnikId, [FromBody] LozinkaParametri lozinkaParametri)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.IzmeniLozinkuKorisnika(korisnikId, lozinkaParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniKorisnika")]
        public async Task<ActionResult> IzmeniKorisnika(int korisnikId, [FromBody] KorisnikParametri korisnikParametri)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.IzmeniKorisnika(korisnikId, korisnikParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiKorisnika")]
        public async Task<ActionResult> ObrisiKorisnika(int korisnikId)
        {
            try
            {
                await KorisnikService.ObrisiKorisnika(korisnikId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("PlatiClanarinuKorisnika")]
        public async Task<ActionResult> PlatiClanarinuKorisnika(int korisnikId)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.PlatiClanarinuKorisnika(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmiriDugovanjaKorisnika")]
        public async Task<ActionResult> IzmiriDugovanjaKorisnika(int korisnikId)
        {
            try
            {
                KorisnikPrikaz result = await KorisnikService.IzmiriDugovanjaKorisnika(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}