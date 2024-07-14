using GameStore.Api.Contracts;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;


public static class GameMapping
{
    public static Game DtoToEntity(this CreateGameDto createGameDto)
    {
         return new Game()
            {
               Name = createGameDto.Name,              
               GenreId = createGameDto.GenreId,
               Price = createGameDto.Price,
               ReleaseDate = createGameDto.ReleaseDate
            };
    }

    public static GameSummaryDto FromEntityToContract(this Game game)
    {
       return  new (
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

     public static GameDetailsDto ToGameDetailsContractDto(this Game game)
    {
       return  new (
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }

    public static Game DtoToEntity(this UpdateGameDto updateGameDto, int id)
    {
         return new Game()
            {
               Id = id,
               Name = updateGameDto.Name,              
               GenreId = updateGameDto.GenreId,
               Price = updateGameDto.Price,
               ReleaseDate = updateGameDto.ReleaseDate
            };
    }
}
