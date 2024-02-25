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
    public class VestController : ControllerBase
    {
        public IVestService VestService { get; set; }

        public VestController(IVestService vestService)
        {
            VestService = vestService;
        }

        [HttpGet]
        [Route("PreuzmiVesti")]
        public async Task<ActionResult> PreuzmiVesti(int page)
        {
            try
            {
                VestSaStranama result = await VestService.PreuzmiVesti(page);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiVestPoId")]
        public async Task<ActionResult> PreuzmiVestPoId(int vestId)
        {
            try
            {
                VestPrikaz result = await VestService.PreuzmiVestPoId(vestId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajVest")]
        public async Task<ActionResult> DodajVest([FromForm] VestParametri vestParametri)
        {
            try
            {
                VestPrikaz result = await VestService.DodajVest(vestParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniVest")]
        public async Task<ActionResult> IzmeniVest(int vestId, [FromBody] VestParametri vestParametri)
        {
            try
            {
                VestPrikaz result = await VestService.IzmeniVest(vestId, vestParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiVest")]
        public async Task<ActionResult> ObrisiVest(int vestId)
        {
            try
            {
                await VestService.ObrisiVest(vestId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajSlikeVesti")]
        public async Task<ActionResult> DodajSlikeVesti(int vestId, [FromForm] List<SlikaParametar> slike)
        {
            try
            {
                VestPrikaz result = await VestService.DodajSlikeVesti(vestId, slike);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}