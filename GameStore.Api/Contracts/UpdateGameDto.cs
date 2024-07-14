﻿using System.ComponentModel.DataAnnotations;



public record class UpdateGameDto( 
        [Required] [StringLength(50)] string Name,
        int GenreId,
        [Required] [Range(1,250)]decimal Price,
        [Required] DateOnly ReleaseDate);
