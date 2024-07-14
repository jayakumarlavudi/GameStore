using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api;

public static class GenreEndPoints
{
    public static RouteGroupBuilder MapGenreEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("genre").WithParameterValidation();

        //Get /games
        group.MapGet("/",async (GameStoreContext dbContext) => 
        await dbContext.genre
                .Select(genre => genre.ToDto())
                .AsNoTracking()
                .ToListAsync()); // Dont track the entities.

    return group;
    }
}
