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
    public class KomentarController : ControllerBase
    {
        public IKomentarService KomentarService { get; set; }

        public KomentarController(IKomentarService komentarService)
        {
            KomentarService = komentarService;
        }

        [HttpGet]
        [Route("PreuzmiKomentareZaKnjigu")]
        public async Task<ActionResult> PreuzmiKomentareZaKnjigu(int knjigaId)
        {
            try
            {   
                List<KomentarPrikaz> result = await KomentarService.PreuzmiKomentareZaKnjigu(knjigaId);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajKomentar")]
        public async Task<ActionResult> DodajKomentar([FromBody] KomentarParametri komentarParametri)
        {
            try
            {
                KomentarPrikaz result = await KomentarService.DodajKomentar(komentarParametri);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniKomentar")]
        public async Task<ActionResult> IzmeniKomentar(int komentarId, [FromBody] KomentarParametri komentarParametri)
        {
            try
            {
                KomentarPrikaz result = await KomentarService.IzmeniKomentar(komentarId, komentarParametri);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiKomentar")]
        public async Task<ActionResult> ObrisiKomentar(int komentarId)
        {
            try
            {
                await KomentarService.ObrisiKomentar(komentarId);

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}