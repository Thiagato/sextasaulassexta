using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Produto produto = new Produto();
// produto.Nome = "BOOLacha";

List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto("Celular", "IOS", 6969));
produtos.Add(new Produto("Celular", "Android", 2023));
produtos.Add(new Produto("Televisão", "LG", 2424));
produtos.Add(new Produto("Notebook", "Avell", 1205));

//EndPoints - Funcionalidades
//GET: http://localhost:5225/
app.MapGet("/", () => "Minha primeira API em C# com watch");

//GET: http://localhost:5225/api/produto/listar
app.MapGet("/api/produto/listar", () => produtos);

//GET: http://localhost:5225/api/produto/buscar/id_do_produto
app.MapGet("/api/produto/buscar/{id}", (string id) => {

    foreach(Produto p in produtos){
        if(id == p.Id){
            return Results.Ok(p);
        }
    }

    return Results.NotFound("DEU NAO KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
    
});

//POST: http://localhost:5225/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", () => "Cadastro de produtos");

app.Run();

