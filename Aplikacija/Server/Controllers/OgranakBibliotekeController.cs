using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parameters;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OgranakBibliotekeController : ControllerBase
    {
        private IOgranakBibliotekeService OgranakBibliotekeService { get; set; }

        public OgranakBibliotekeController(IOgranakBibliotekeService ogranakBibliotekeService)
        {
            OgranakBibliotekeService = ogranakBibliotekeService;
        }

        [HttpGet]
        [Route("PreuzmiOgrankeBiblioteke")]
        public async Task<ActionResult> PreuzmiOgrankeBiblioteke()
        {
            try
            {
                List<OgranakBibliotekePrikaz> result = await OgranakBibliotekeService.PreuzmiOgrankeBiblioteke();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiOgrankeGdeSeNalaziKnjiga")]
        public async Task<ActionResult> PreuzmiOgrankeGdeSeNalaziKnjiga(int knjigaId)
        {
            try
            {
                List<OgranakBibliotekePrikaz> result = await OgranakBibliotekeService.PreuzmiOgrankeGdeSeNalaziKnjiga(knjigaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiOgranakBibliotekePoId")]
        public async Task<ActionResult> PreuzmiOgranakBibliotekePoId(int ogranakId)
        {
            try
            {
                OgranakBibliotekePrikaz result = await OgranakBibliotekeService.PreuzmiOgranakBibliotekePoId(ogranakId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajOgranakBiblioteke")]
        public async Task<ActionResult> DodajOgranakBiblioteke([FromForm] OgranakBibliotekeParametri ogranakBibliotekeParametri)
        {
            try
            {
                OgranakBibliotekePrikaz result = await OgranakBibliotekeService.DodajOgranakBiblioteke(ogranakBibliotekeParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniOgranakBiblioteke")]
        public async Task<ActionResult> IzmeniOgranakBiblioteke(int ogranakBibliotekeId, [FromBody] OgranakBibliotekeParametri ogranakBibliotekeParametri)
        {
            try
            {
                OgranakBibliotekePrikaz result = await OgranakBibliotekeService.IzmeniOgranakBiblioteke(ogranakBibliotekeId, ogranakBibliotekeParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiOgranakBiblioteke")]
        public async Task<ActionResult> ObrisiOgranakBiblioteke(int ogranakBibliotekeId)
        {
            try
            {
                await OgranakBibliotekeService.ObrisiOgranakBiblioteke(ogranakBibliotekeId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajSlikeOgrankuBiblioteke")]
        public async Task<ActionResult> DodajSlikeOgrankuBiblioteke(int ogranakBibliotekeId, [FromForm] List<SlikaParametar> slike)
        {
            try
            {
                OgranakBibliotekePrikaz result = await OgranakBibliotekeService.DodajSlikeOgrankuBiblioteke(ogranakBibliotekeId, slike);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}