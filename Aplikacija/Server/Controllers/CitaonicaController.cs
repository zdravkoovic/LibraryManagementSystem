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
    public class CitaonicaController : ControllerBase
    {
        private ICitaonicaService CitaonicaService { get; set; }
        
        public CitaonicaController(ICitaonicaService citaonicaService)
        {
            CitaonicaService = citaonicaService;
        }

        [HttpGet]
        [Route("PreuzmiCitaoniceOgranka")]
        public async Task<ActionResult> PreuzmiCitaoniceOgrankaBiblioteke(int ogranakBibliotekeId)
        {
            try
            {
                List<CitaonicaPrikaz> result = await CitaonicaService.PreuzmiCitaoniceOgrankaBiblioteke(ogranakBibliotekeId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiCitaonicuPoId")]
        public async Task<ActionResult> PreuzmiCitaonicuPoId(int citaonicaId)
        {
            try
            {
                CitaonicaPrikaz result = await CitaonicaService.PreuzmiCitaonicuPoId(citaonicaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajCitaonicu")]
        public async Task<ActionResult> DodajCitaonicu(CitaonicaParametri citaonicaParametri)
        {
            try
            {
                CitaonicaPrikaz result = await CitaonicaService.DodajCitaonicu(citaonicaParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniCitaonicu")]
        public async Task<ActionResult> IzmeniCitaonicu(int citaonicaId, CitaonicaParametri citaonicaParametri)
        {
            try
            {
                CitaonicaPrikaz result = await CitaonicaService.IzmeniCitaonicu(citaonicaId, citaonicaParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiCitaonicu")]
        public async Task<ActionResult> ObrisiCitaonicu(int citaonicaId)
        {
            try
            {
                await CitaonicaService.ObrisiCitaonicu(citaonicaId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}