using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
{
    new Game()
    {
        Id =  1,
        Name = "Maximum Carnage",
        Genre = "Melee",
        ReleaseDate = new DateTime(1992, 01, 05),
        ImageUri = "https://placehold.co/200"
    },

     new Game()
    {
        Id =  2,
        Name = "NBA Streets",
        Genre = "Sports",
        ReleaseDate = new DateTime(2006, 03, 05),
        ImageUri = "https://placehold.co/200"
    },

     new Game()
    {
        Id =  3,
        Name = "Spawn",
        Genre = "RolePlaying",
        ReleaseDate = new DateTime(2010, 01, 05),
        ImageUri = "https://placehold.co/200"
    },

  };
    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)

    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}