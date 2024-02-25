using System;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatistikaController : ControllerBase
    {
        private IStatistikaService StatistikaService { get; set; }

        public StatistikaController(IStatistikaService statistikaService)
        {
            StatistikaService = statistikaService;
        }

        [HttpGet]
        [Route("PreuzmiStatistiku")]
        public async Task<ActionResult> PreuzmiStatistiku()
        {
            try
            {
                StatistikaPrikaz result = await StatistikaService.PreuzmiStatistiku();
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}