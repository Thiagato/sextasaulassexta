var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//endpoints - funcionalidades

//GET:localhost/x/
app.MapGet("/", () => "jEAN NO HAIR");
//GET:localhost/x/api
app.MapGet("/api", () => "ola");
//POST;localhost/x/api/taligas
app.MapPost("/api/taligas/", () => "tilgas");

app.Run();
