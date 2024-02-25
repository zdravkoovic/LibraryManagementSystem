using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModels.Prikaz;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlikaController : ControllerBase
    {

        private ISlikaService SlikaService { get; set; }

        public SlikaController(ISlikaService slikaService)
        {
            SlikaService = slikaService;
        }

        [HttpDelete]
        [Route("ObrisiSliku")]
        public async Task<ActionResult> ObrisiSliku(string link)
        {
            try
            {
                var result = await SlikaService.ObrisiSliku(link);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiSlike")]
        public async Task<ActionResult> ObrisiSlike(List<string> linkovi)
        {
            try
            {
                var result = await SlikaService.ObrisiSlike(linkovi);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}