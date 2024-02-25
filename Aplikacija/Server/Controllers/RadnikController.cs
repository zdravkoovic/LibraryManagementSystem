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
    public class RadnikController : ControllerBase
    {
        private IRadnikService RadnikService { get; set; }
        
        public RadnikController(IRadnikService radnikService)
        {
            RadnikService = radnikService;
        }

        [HttpGet]
        [Route("PreuzmiRadnike")]
        public async Task<ActionResult> PreuzmiRadnike()
        {
            try
            {
                List<RadnikPrikaz> radniciPrikaz = await RadnikService.PreuzmiRadnike();

                return Ok(radniciPrikaz);
             }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnikaPoId")]
        public async Task<ActionResult> PreuzmiRadnikaPoId(int radnikId)
        {
            try
            {
                RadnikPrikaz radnikPrikaz = await RadnikService.PreuzmiRadnikaPoId(radnikId);

                return Ok(radnikPrikaz);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PretraziRadnike")]
        public async Task<ActionResult> PretraziRadnike(string pretraga)
        {
            try
            {
                List<RadnikPrikaz> radniciPrikaz = await RadnikService.PretraziRadnike(pretraga);

                return Ok(radniciPrikaz);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajRadnika")]
        public async Task<ActionResult> DodajRadnika([FromBody] RadnikParametri radnikParametri)
        {
            try
            {
                RadnikPrikaz radnikPrikaz = await RadnikService.DodajRadnika(radnikParametri);

                return Ok(radnikPrikaz);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("IzmeniLozinkuRadnika")]
        public async Task<ActionResult> IzmeniLozinkuRadnika(int radnikId, [FromBody] LozinkaParametri lozinkaParametri)
        {
            try
            {
                RadnikPrikaz radnikPrikaz = await RadnikService.IzmeniLozinkuRadnika(radnikId, lozinkaParametri);

                return Ok(radnikPrikaz);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniRadnika")]
        public async Task<ActionResult> IzmeniRadnika(int radnikId, [FromBody] RadnikParametri radnikParametri)
        {
            try
            {
                RadnikPrikaz radnikPrikaz = await RadnikService.IzmeniRadnika(radnikId, radnikParametri);

                return Ok(radnikPrikaz);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}