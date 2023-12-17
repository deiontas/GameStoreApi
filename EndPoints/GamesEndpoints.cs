using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.EndPoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";


    public static RouteGroupBuilder MapGamesEndpoints( this IEndpointRouteBuilder routes)
     {
        InMemGamesRepository repository = new();

        var group = routes.MapGroup("/games")
            .WithParameterValidation();

group.MapGet("/", (IGamesRepository repository) => repository.GetAll ); //EndPoint Get games by sending to server then gets  response

group.MapGet("/{id}",(IGamesRepository repository,int id) => 
{

    Game? game = repository.Get(id);
    return game is not null ? Results.Ok(game) : Results.NotFound();
    

})

.WithName("GetGame");//Define Endpoint by Id


group.MapPost("/", (IGamesRepository repository,Game game) =>
{
    repository.Create(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.Id}, game);
});


group.MapPut("/{id}", (IGamesRepository repository,int id, Game updatedGame) =>
{
    Game? existingGame = repository.Get(id);
    
    if(existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    repository.Update(existingGame);

    return Results.NoContent();

});

group.MapDelete("/{id}", (IGamesRepository repository,int id) =>
{
    Game? game = repository.Get(id);
    
    if(game is not null)
    {
        repository.Delete(id);
    }
     return Results.NoContent();

});

    return group;
    }
}