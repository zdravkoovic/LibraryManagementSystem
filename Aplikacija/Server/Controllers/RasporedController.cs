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
    public class RasporedController : ControllerBase
    {
        private IRasporedService RasporedService { get; set; }

        public RasporedController(IRasporedService rasporedService)
        {
            RasporedService = rasporedService;
        }

        [HttpGet]
        [Route("PreuzmiRasporedRadnika")]
        public async Task<ActionResult> PreuzmiRasporedRadnika(int radnikId)
        {
            try
            {
                RasporedPrikaz result = await RasporedService.PreuzmiRasporedRadnika(radnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiRasporede")]
        public async Task<ActionResult> PreuzmiRasporede()
        {
            try
            {
                List<RasporedPrikaz> result = await RasporedService.PreuzmiRasporede();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniRaspored")]
        public async Task<ActionResult> IzmeniRaspored(int rasporedId, [FromBody] RasporedParametri rasporedParametri)
        {
            try
            {
                RasporedPrikaz result = await RasporedService.IzmeniRaspored(rasporedId, rasporedParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}