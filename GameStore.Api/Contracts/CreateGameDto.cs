using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Contracts;

    public record class CreateGameDto( 
    [Required] [StringLength(50)] string Name,
    int GenreId,
    [Required] [Range(1,250)]decimal Price,
    [Required] DateOnly ReleaseDate);
    

