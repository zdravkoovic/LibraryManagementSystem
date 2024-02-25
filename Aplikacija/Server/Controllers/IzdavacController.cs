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
    public class IzdavacController : ControllerBase
    {
        public IIzdavacService IzdavacService { get; set; }

        public IzdavacController(IIzdavacService izdavacService)
        {
            IzdavacService = izdavacService;
        }

        [HttpGet]
        [Route("PreuzmiIzdavace")]
        public async Task<ActionResult> PreuzmiIzdavace(int page)
        {
            try
            {
                List<IzdavacPrikaz> result = await IzdavacService.PreuzmiIzdavace(page);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PretraziIzdavace")]
        public async Task<ActionResult> PretraziIzdavace(string pretraga, int page)
        {
            try
            {
                List<IzdavacPrikaz> result = await IzdavacService.PretragaIzdavaca(pretraga, page);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiIzdavacaPoId")]
        public async Task<ActionResult> PreuzmiIzdavacaPoId(int izdavacId)
        {
            try
            {
                IzdavacPrikaz result = await IzdavacService.PreuzmiIzdavacaPoId(izdavacId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajIzdavaca")]
        public async Task<ActionResult> DodajIzdavaca([FromBody] IzdavacParametri izdavacParametri)
        {
            try
            {
                IzdavacPrikaz result = await IzdavacService.DodajIzdavaca(izdavacParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniIzdavaca")]
        public async Task<ActionResult> IzmeniIzdavaca(int izdavacId, [FromBody] IzdavacParametri izdavacParametri)
        {
            try
            {
                IzdavacPrikaz result = await IzdavacService.IzmeniIzdavaca(izdavacId, izdavacParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiIzdavaca")]
        public async Task<ActionResult> ObrisiIzdavaca(int izdavacId)
        {
            try
            {
                await IzdavacService.ObrisiIzdavaca(izdavacId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}