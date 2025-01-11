using MongoDB.Driver;

public class PokemonService : IPokemonService
{
    private readonly IMongoCollection<Pokemon>? _pokemonCollection;
    public PokemonService(IConfiguration configuration){
        var client = new MongoClient(configuration["DBSettings:ConString"]);
        var database = client.GetDatabase(configuration["DBSettings:DatabaseName"]);
        _pokemonCollection = database.GetCollection<Pokemon>(configuration["DBSettings:CollectionName"]);
    }

    public async Task<List<Pokemon>> GetPokemons(){
        try{
            var pokemons = await _pokemonCollection.Find(_ => true).ToListAsync();
            if(pokemons != null){
                return pokemons;
            }
            throw new Exception();
        }catch(Exception){
            return null!;
        }
    }

    public async Task<Pokemon> GetPokemon(string id){
        try{
            var pokemon = await _pokemonCollection.Find(pok => pok.ID == id).FirstOrDefaultAsync();
            if(pokemon != null){
                return pokemon;
            } throw new Exception();
        } catch(Exception){
            return null!;
        }
    }

    public async Task<bool> AddPokemon(Pokemon pokemon){
        try{
            pokemon.ID = null;
            await _pokemonCollection?.InsertOneAsync(pokemon)!;
            return true;
        } catch(Exception){
            return false;
        }
    }

    public async Task<bool> UpdatePokemon(string id, Pokemon pokemon){
        try{
            pokemon.ID = id;
            var status = await _pokemonCollection.ReplaceOneAsync(pok => pok.ID == id, pokemon);
            if(status.ModifiedCount == 0){
                throw new Exception();
            }

            return true;
        } catch(Exception){
            return false;
        }
    }

    public async Task<bool> DeletePokemon(string id){
        try{
            var status = await _pokemonCollection.DeleteOneAsync(pok => pok.ID == id);
            if(status.DeletedCount == 0){
                throw new Exception();
            }
            return true;
        } catch(Exception){
            return false;
        }
    }
}