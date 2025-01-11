using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService? _pokemonService;
    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult> GetPokemons()
    {
        try
        {
            var pokemons = await _pokemonService?.GetPokemons()!;
            if (pokemons != null)
            {
                return Ok(pokemons);
            }
            throw new Exception("There are No Pokemons in the database at the moment");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPokemonById(string id)
    {
        try
        {
            var pokemon = await _pokemonService?.GetPokemon(id)!;
            if (pokemon != null)
            {
                return Ok(pokemon);
            }
            throw new Exception($"There is No Pokemon with id: {id}");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddPokemon(Pokemon pokemon)
    {
        try
        {
            if (await _pokemonService?.AddPokemon(pokemon)! == true)
            {
                return Ok("Successfully added Pokemon");
            }
            throw new Exception("Failed to Add Pokemon to Database");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePokemon(string id, Pokemon pokemon)
    {
        try
        {
            if (await _pokemonService?.UpdatePokemon(id, pokemon)! == true)
            {
                return Ok("Pokemon Updated Successfully");
            }
            throw new Exception($"Could not find a pokemon with id => {id} to Update!");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePokemon(string id)
    {
        try
        {
            if (await _pokemonService?.DeletePokemon(id)! == true)
            {
                return Ok("Successfully Deleted Pokemon!");
            }
            throw new Exception($"Could not find a pokemon with id => {id} to delete");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}