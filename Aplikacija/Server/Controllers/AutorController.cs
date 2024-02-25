using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Parameters;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        public IAutorService AutorService { get; set; }

        public AutorController(IAutorService autorService)
        {
            AutorService = autorService;
        }

        [HttpGet]
        [Route("PreuzmiAutore")]
        public async Task<ActionResult> PreuzmiAutore(int page)
        {
            try
            {
                AutorSaStranama result = await AutorService.PreuzmiAutore(page);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PretraziAutore")]
        public async Task<ActionResult> PretraziAutore(string pretraga, int page)
        {
            try
            {
                AutorSaStranama result = await AutorService.PretraziAutore(pretraga, page);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiAutoraPoId")]
        public async Task<ActionResult> PreuzmiAutoraPoId(int autorId)
        {
            try
            {
                AutorPrikaz result = await AutorService.PreuzmiAutoraPoId(autorId);

                return Ok(result);
            }   
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajAutora")]
        public async Task<ActionResult> DodajAutora([FromForm] AutorParametri autorParametri)
        {
            try
            {
                AutorPrikaz result = await AutorService.DodajAutora(autorParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniAutora")]
        public async Task<ActionResult> IzmeniAutora(int autorId, [FromBody] AutorParametri autorParametri)
        {
            try
            {
                AutorPrikaz result = await AutorService.IzmeniAutora(autorId, autorParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiAutora")]
        public async Task<ActionResult> ObrisiAutora(int autorId)
        {
            try
            {
                await AutorService.ObrisiAutora(autorId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajSlikuAutoru")]
        public async Task<ActionResult> DodajSlikuAutoru(int autorId, [FromForm] SlikaParametar slika)
        {
            try
            {
                AutorPrikaz result = await AutorService.DodajSlikuAutoru(autorId, slika);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}