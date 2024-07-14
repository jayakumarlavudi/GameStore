using GameStore.Api;
using GameStore.Api.Data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");
//Dependency Injection
// This register the context in the service container
builder.Services.AddSqlite<GameStoreContext>(connectionString);

var app = builder.Build();

//Build builds the instance of the application. 
//It setup Kestral as inprocess web Server that comes in with Asp.Net Core

app.MapGamesEndPoints();

app.MapGenreEndPoints();

await app.MigrateDbAsync();

app.Run();
 