
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> gameStoreOptions)
 : DbContext(gameStoreOptions)
{
    public DbSet<Game> games =>Set<Game>();

    public DbSet<Genre> genre =>Set<Genre>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {Id =1,Name = "Fighting"},
            new {Id =2,Name = "RolePlay"},
            new {Id =3,Name = "Sports"},
            new {Id =4,Name = "Racing"},
            new {Id =5,Name = "Kids"}

        );
    }
}
