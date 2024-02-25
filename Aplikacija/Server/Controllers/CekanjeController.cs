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
    public class CekanjeController : ControllerBase
    {
        public ICekanjeService CekanjeService { get; set; }

        public CekanjeController(ICekanjeService cekanjeService)
        {
            CekanjeService = cekanjeService;
        }

        [HttpGet]
        [Route("PreuzmiBrojKorisnikaKojiCekajuKnjigu")]
        public async Task<ActionResult> PreuzmiBrojKorisnikaKojiCekajuKnjigu(int knjigaId)
        {
            try
            {
                int result = await CekanjeService.PreuzmiBrojKorisnikaKojiCekajuKnjigu(knjigaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiCekanjaKorisnika")]
        public async Task<ActionResult> PreuzmiCekanjaKorisnika(int korisnikId)
        {
            try
            {
                List<CekanjePrikaz> result = await CekanjeService.PreuzmiCekanjaKorisnika(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajCekanje")]
        public async Task<ActionResult> DodajCekanje([FromBody] CekanjeParametri cekanjeParametri)
        {
            try
            {
                bool result = await CekanjeService.DodajCekanje(cekanjeParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiCekanje")]
        public async Task<ActionResult> ObrisiCekanje(int cekanjeId)
        {
            try
            {
                bool result = await CekanjeService.ObrisiCekanje(cekanjeId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}