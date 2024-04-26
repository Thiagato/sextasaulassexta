using API.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

//registrar o serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();

//todo parametro de endpoit precisa de algo do appdatacontext
//ex linha 47

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
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{

    if (ctx.TabelaProdutos.Any())
    {

        return Results.Ok(ctx.TabelaProdutos.ToList());
    }
    return Results.NotFound("tabela vaziadaza");


});

//GET: http://localhost:5225/api/produto/buscar/id_do_produto
//GET: http://localhost:5225/api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", (int id, [FromServices] AppDataContext ctx) => {

    var produtoEncontrado = ctx.TabelaProdutos.Find(id);

    if (produtoEncontrado != null)
    {
        return Results.Ok(produtoEncontrado);
    }

    return Results.NotFound($"Produto com o ID '{id}' não encontrado.");
});



//POST: http://localhost:5225/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar/",
    ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
    {



        //Adicionar o produto dentro da lista
        //ctx.pro


        //returnar o resultado do produto

        //produtos.Add(produto);
        ctx.TabelaProdutos.Add(produto);
        ctx.SaveChanges();
        return Results.Created("", produto);

    });

// Endpoint para atualizar um produto existente
app.MapPut("/api/produto/atualizar/{id}", (string id, Produto pAtualizado) =>
{


    foreach (Produto pExiste in produtos)
    {
        if (pExiste.Id == id)
        {
            // Atualiza os dados do produto existente com os dados do produto atualizado
            pExiste.Nome = pAtualizado.Nome;
            pExiste.Descricao = pAtualizado.Descricao;
            pExiste.Valor = pAtualizado.Valor;

            return Results.Ok(pExiste);
        }
    }

    return Results.NotFound();
});


app.MapDelete("/api/produto/deletar/{id}", (string id) =>
{
    foreach (var produto in produtos)
    {

        if (produto.Id == id)
        {
            produtos.Remove(produto);


            return Results.Ok(produtos);
        }
    }
    return Results.Ok();
});




app.Run();

