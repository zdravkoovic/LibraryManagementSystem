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
    public class MestoController : ControllerBase   
    {
        private IMestoService MestoService { get; set; }
        
        public MestoController(IMestoService mestoService)
        {
            MestoService = mestoService;
        }

        [HttpGet]
        [Route("PreuzmiMestaCitaonice")]
        public async Task<ActionResult> PreuzmiMestaCitaonice(int citaonicaId)
        {
            try
            {
                List<MestoPrikaz> result = await MestoService.PreuzmiMestaCitaonice(citaonicaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiMestoPoId")]
        public async Task<ActionResult> PreuzmiMestoPoId(int mestoId)
        {
            try
            {
                MestoPrikaz result = await MestoService.PreuzmiMestoPoId(mestoId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajMesto")]
        public async Task<ActionResult> DodajMesto([FromBody] MestoParametri mestoParametri)
        {
            try
            {
                MestoPrikaz result = await MestoService.DodajMesto(mestoParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniMesto")]
        public async Task<ActionResult> IzmeniMesto(int mestoId, [FromBody] MestoParametri mestoParametri)
        {
            try
            {
                MestoPrikaz result = await MestoService.IzmeniMesto(mestoId, mestoParametri);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiMesto")]
        public async Task<ActionResult> ObrisiMesto(int mestoId)
        {
            try
            {
                await MestoService.ObrisiMesto(mestoId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}