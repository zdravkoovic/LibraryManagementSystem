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
    public class IznajmljivanjeController : ControllerBase
    {
        private IIznajmljivanjeService IznajmljivanjeService { get; set; }
        
        public IznajmljivanjeController(IIznajmljivanjeService iznajmljivanjeService)
        {
            IznajmljivanjeService = iznajmljivanjeService;
        }

        [HttpGet]
        [Route("PreuzmiIznajmljivanjaKorisnika")]
        public async Task<ActionResult> PreuzmiIznajmljivanjaKorisnika(int korisnikId)
        {
            try
            {
                List<IznajmljivanjePrikaz> result = await IznajmljivanjeService.PreuzmiIznajmljivanjaKorisnika(korisnikId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiIstorijuIznajmljivanjaKnjige")]
        public async Task<ActionResult> PreuzmiIstorijuIznajmljivanjaKnjige(int knjigaId)
        {
            try
            {
                List<IznajmljivanjePrikaz> result = await IznajmljivanjeService.PreuzmiIstorijuIznajmljivanjaKnjige(knjigaId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajIznajmljivanje")]
        public async Task<ActionResult> DodajIznajmljivanje(IznajmljivanjeParametri iznajmljivanjeParametri)
        {
            try
            {
                IznajmljivanjePrikaz result = await IznajmljivanjeService.DodajIznajmljivanje(iznajmljivanjeParametri);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPut]
        [Route("VratiIznajmljenuKnjigu")]
        public async Task<ActionResult> VratiIznajmljenuKnjigu(int iznajmljivanjeId)
        {
            try
            {
                IznajmljivanjePrikaz result = await IznajmljivanjeService.VratiIznajmljenuKnjigu(iznajmljivanjeId);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}