using BlazorWasm.Compartilhado.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWasmServer.Server.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PokemonController(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region Teste
        //[HttpGet("teste/{nome}")]
        //public async Task<ActionResult<int>> Teste(string Nome)
        //{
        //    Pokemon pokemon = new Pokemon();
        //    pokemon.Nome = Nome;
        //    context.Pokemons.Add(pokemon);
        //    await context.SaveChangesAsync();
        //    return pokemon.Id;
        //}
        #endregion

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> Get()
        {
            return await context.Pokemons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            var resp = await context.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
            if (resp == null) { return NotFound(); }
            return resp;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Pokemon pokemon)
        {
            context.Pokemons.Add(pokemon);
            await context.SaveChangesAsync();
            return pokemon.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Pokemon pokemon)
        {
            context.Attach(pokemon).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pokemon = await context.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            context.Remove(pokemon);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
