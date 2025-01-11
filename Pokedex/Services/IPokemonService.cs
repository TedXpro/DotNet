public interface IPokemonService{
    public Task<List<Pokemon>> GetPokemons();
    public Task<Pokemon> GetPokemon(string id);
    public Task<bool> AddPokemon(Pokemon pokemon);
    public Task<bool> UpdatePokemon(string id, Pokemon pokemon);
    public Task<bool> DeletePokemon(string id);
}