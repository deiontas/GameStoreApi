using GameStore.Api.EndPoints;
using GameStore.Api.Repositories;




var builder = WebApplication.CreateBuilder(args); //declare the builder
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var app = builder.Build(); //builds web application

app.MapGamesEndpoints(); //define the endpoints

app.Run(); //run the application to start server request
