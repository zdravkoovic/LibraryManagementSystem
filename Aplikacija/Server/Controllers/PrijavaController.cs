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
    public class PrijavaController : ControllerBase
    {
        private IPrijavaService PrijavaService { get; set; }

        public PrijavaController(IPrijavaService prijavaService)
        {
            PrijavaService = prijavaService;
        }

        [HttpGet]
        [Route("PreuzmiPrijaveRadnika")]
        public async Task<ActionResult> PreuzmiPrijaveRadnika(int radnikId)
        {
            try
            {
                List<PrijavaPrikaz> result = await PrijavaService.PreuzmiPrijaveRadnika(radnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("PrijavaRadnika")]
        public async Task<ActionResult> PrijavaRadnika([FromBody] PrijavaParametri prijavaParametri)
        {
            try
            {
                PrijavaPrikaz result = await PrijavaService.PrijavaRadnika(prijavaParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("PrijavaKorisnika")]
        public async Task<ActionResult> PrijavaKorisnika([FromBody] PrijavaParametri prijavaParametri)
        {
            try
            {   
                KorisnikPrikaz result = await PrijavaService.PrijavaKorisnika(prijavaParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("OdjavaRadnika")]
        public async Task<ActionResult> OdjavaRadnika(int prijavaId)
        {
            try
            {
                bool result = await PrijavaService.OdjavaRadnika(prijavaId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}