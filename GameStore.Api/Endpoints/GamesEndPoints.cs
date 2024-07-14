using GameStore.Api.Contracts;
using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;
namespace GameStore.Api.EndPoints;

public static class GamesEndPoints
{  
 
 public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
 {

    var group = app.MapGroup("games").WithParameterValidation();

    //Get /games
        group.MapGet("/",async (GameStoreContext dbContext) => 
        await dbContext.games
                .Include(game => game.Genre)
                .Select(game => game.FromEntityToContract())
                .AsNoTracking()
                .ToListAsync()); // Dont track the entities.

    //Get /games/id
        group.MapGet("/{id}",async (int id,GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.games.FindAsync(id);
            return game is null ?
                Results.NotFound():Results.Ok(game.ToGameDetailsContractDto());
        })
        .WithName("GetGame");

    //POST /games
        group.MapPost("/",async (CreateGameDto newGame,GameStoreContext dbContext) =>
        { 
           Game game = newGame.DtoToEntity();

          // game.Genre = dbContext.genre.Find(newGame.GenreId);

               dbContext.games.Add(game);
              await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    "GetGame",
                    new {id = game.Id},
                    game.ToGameDetailsContractDto());
        }).WithParameterValidation();

    // PUT /games
        group.MapPut("/{id}",async (int id,UpdateGameDto updateGameDto,GameStoreContext dbContext)=>
        {
            var gameInfo =await dbContext.games.FindAsync(id);

            if(gameInfo is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(gameInfo)
            .CurrentValues
            .SetValues(updateGameDto.DtoToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

    //DELETE /game/1
        group.MapDelete("/{id}",async (int id,GameStoreContext dbContext)=>{

            var gameInfo =await dbContext.games
                            .Where(game => game.Id == id).ExecuteDeleteAsync();
         
        return Results.NoContent();
        });

    return group;
 }
 
}
