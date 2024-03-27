using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PortfolioProjets.API.Interfaces;
using PortfolioProjets.API.Models;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioProjets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetsController : ControllerBase
    {
        private readonly IProjetsServices _projetService;
        public ProjetsController(IProjetsServices projetService)
        {
            _projetService = projetService;
        }

        // GET: api/<ProjetsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _projetService.ObtenirProjets());
        }

        // GET api/<ProjetsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var projet = await _projetService.ObtenirProjetSelonId(id);
            return projet != null ? Ok(projet) : NotFound("Projet introuvable");
        }

        // POST api/<ProjetsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Projet projet)
        {
            if (ModelState.IsValid)
            {
                var projetAjoute = await _projetService.AjouterProjet(projet);
                return CreatedAtAction(nameof(Get), new { id = projet?.Id }, projet);
            }
            return BadRequest();
        }

        // PUT api/<ProjetsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Projet projet)
        {
            if (id != projet.Id)
                return BadRequest("Erreur");

            if (await _projetService.ObtenirProjetSelonId(projet.Id) == null)
                return NotFound("projet introuvable");

            if (ModelState.IsValid)
            {
                await _projetService.ModifierProjet(projet);
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/<ProjetsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _projetService.ObtenirProjetSelonId(id) == null)
                return NotFound("projet introuvable");

            await _projetService.SupprimerProjet(id);
            return NoContent();
        }
    }
}
