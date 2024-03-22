var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>(); 
produtos.Add(new Produto("Celular", "XIOAMI"));
produtos.Add(new Produto("Celular", "IOS"));
produtos.Add(new Produto("Celular", "SANSUNG"));
produtos.Add(new Produto("Celular", "SLA"));
produtos.Add(new Produto("Celular", "ANDROID"));

//endpoints - funcionalidades

//GET:localhost/x/
app.MapGet("/", () => "jEAN NO HAIR");
//GET:localhost/x/api
app.MapGet("/api/produto", () => produtos);
//POST;localhost/x/api/taligas
app.MapPost("/api/produto/lisar", () => "tilgas");

app.Run();

record Produto(string Nome, string Descricao);