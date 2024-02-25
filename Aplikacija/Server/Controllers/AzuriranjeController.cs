using System;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzuriranjeController : ControllerBase
    {
        private IAzuriranjeService AzuriranjeService { get; set; }

        public AzuriranjeController(IAzuriranjeService azuriranjeService)
        {
            AzuriranjeService = azuriranjeService;
        }

        [HttpGet]
        [Route("Azuriraj")]
        public async Task<ActionResult> Azuriraj()
        {
            try
            {
                await AzuriranjeService.AzurirajStanje();
                Console.WriteLine($"Azuriranje... :: {DateTime.Now}");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}