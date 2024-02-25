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
    public class CitanjeController : ControllerBase
    {
        private ICitanjeService CitanjeService { get; set; }
    
        public CitanjeController(ICitanjeService citanjeService)
        {
            CitanjeService = citanjeService;
        }

        [HttpGet]
        [Route("PreuzmiCitanjaKorisnika")]
        public async Task<ActionResult> PreuzmiCitanjaKorisnika(int korisnikId)
        {
            try
            {
                List<CitanjePrikaz> result = await CitanjeService.PreuzmiCitanjaKorisnika(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiTrenutnaCitanjaUCitaonici")]
        public async Task<ActionResult> PreuzmiTrenutnaCitanjaUCitaonici(int citaonicaId)
        {
            try
            {
                List<CitanjePrikaz> result = await CitanjeService.PreuzmiTrenutnaCitanjaUCitaonici(citaonicaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiCitanjaNaMestu")]
        public async Task<ActionResult> PreuzmiCitanjaNaMestu(int mestoId)
        {
            try
            {
                List<CitanjePrikaz> result = await CitanjeService.PreuzmiCitanjaNaMestu(mestoId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiCitanjePoId")]
        public async Task<ActionResult> PreuzmiCitanjePoId(int citanjeId)
        {
            try
            {
                CitanjePrikaz result = await CitanjeService.PreuzmiCitanjePoId(citanjeId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajCitanje")]
        public async Task<ActionResult> DodajCitanje([FromBody] CitanjeParametri citanjeParametri)
        {
            try
            {
                CitanjePrikaz result = await CitanjeService.DodajCitanje(citanjeParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("VratiKnjigu")]
        public async Task<ActionResult> VratiKnjigu(int citanjeId)
        {
            try
            {
                CitanjePrikaz result = await CitanjeService.VratiKnjigu(citanjeId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}