using System;
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
    public class FizickaKnjigaController : ControllerBase
    {
        private IFizickaKnjigaService FizickaKnjigaService { get; set; }

        public FizickaKnjigaController(IFizickaKnjigaService fizickaKnjigaService)
        {
            FizickaKnjigaService = fizickaKnjigaService;
        }

        [HttpGet]
        [Route("PreuzmiFizickeKnjige")]
        public async Task<ActionResult> PreuzmiFizickeKnjige(int knjigaId, int ogranakBibliotekeId)
        {
            try
            {
                var fizickeKnjige = await FizickaKnjigaService.PreuzmiFizickeKnjige(knjigaId, ogranakBibliotekeId);
                return Ok(fizickeKnjige);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiFizickuKnjiguPoId")]
        public async Task<ActionResult> PreuzmiFizickuKnjiguPoId(int fizickaKnjigaId)
        {
            try
            {
                var fizickaKnjiga = await FizickaKnjigaService.PreuzmiFizickuKnjiguPoId(fizickaKnjigaId);
                return Ok(fizickaKnjiga);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpGet]
        [Route("PreuzmiFizickuKnjiguPoSifri")]
        public async Task<ActionResult> PreuzmiFizickuKnjiguPoSifri(string fizickaKnjigaSifra)
        {
            try
            {
                var fizickaKnjiga = await FizickaKnjigaService.PreuzmiFizickuKnjiguPoSifri(fizickaKnjigaSifra);
                return Ok(fizickaKnjiga);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpPost]
        [Route("DodajFizickeKnjige")]
        public async Task<ActionResult> DodajFizickeKnjige([FromBody] FizickaKnjigaParametri fizickaKnjigaParametri)
        {
            try
            {
                var fizickeKnjige = await FizickaKnjigaService.DodajFizickeKnjige(fizickaKnjigaParametri);
                return Ok(fizickeKnjige);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.InnerException.Message));
            }
        }

        [HttpPut]
        [Route("IzmeniFizickuKnjigu")]
        public async Task<ActionResult> IzmeniFizickuKnjigu(int fizickaKnjigaId, [FromBody] FizickaKnjigaParametri fizickaKnjigaParametri)
        {
            try
            {
                var fizickaKnjiga = await FizickaKnjigaService.IzmeniFizickuKnjigu(fizickaKnjigaId, fizickaKnjigaParametri);
                return Ok(fizickaKnjiga);
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }

        [HttpDelete]
        [Route("ObrisiFizickuKnjigu")]
        public async Task<ActionResult> ObrisiFizickuKnjigu(int fizickaKnjigaId)
        {
            try
            {
                var result = await FizickaKnjigaService.ObrisiFizickuKnjigu(fizickaKnjigaId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Poruka(e.Message));
            }
        }
    }
}