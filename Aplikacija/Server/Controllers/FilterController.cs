using System;
using System.Text.Json;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DatabaseCommunication;
using Parameters;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : ControllerBase
    {
        private IFilterService FilterService { get; set; }

        public FilterController(IFilterService knjigaService)
        {
            FilterService = knjigaService;
        }

        [HttpGet]
        [Route("PreuzmiFiltere")]
        public async Task<ActionResult> PreuzmiFiltere()
        {
            try
            {
                var result = await FilterService.PreuzmiFiltere();
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiKnjizevneZanrove")]
        public async Task<ActionResult> PreuzmiKnjizevneZanrove()
        {
            try
            {
                var result = await FilterService.PreuzmiKnjizevneZanrove();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
        

        [HttpGet]
        [Route("PreuzmiKnjizevneRodove")]
        public async Task<ActionResult> PreuzmiKnjizevneRodove()
        {
            try
            {
                var result = await FilterService.PreuzmiKnjizevneRodove();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
        

        [HttpGet]
        [Route("PreuzmiKnjizevneVrste")]
        public async Task<ActionResult> PreuzmiKnjizevnevrste()
        {
            try
            {
                var result = await FilterService.PreuzmiKnjizevneVrste();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
        

        [HttpGet]
        [Route("PreuzmiJezike")]
        public async Task<ActionResult> PreuzmiJezike()
        {
            try
            {
                var result = await FilterService.PreuzmiJezike();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}