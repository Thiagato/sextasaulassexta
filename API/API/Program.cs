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
app.MapPost("/api/produto/cadastrar/", 
    (Produto produto) => {

        

        //Adicionar o produto dentro da lista
        produtos.Add(produto);
        //returnar o resultado do produto


        return Results.Created("", produto);
        
    });

// Endpoint para atualizar um produto existente
app.MapPut("/api/produto/atualizar/{id}", (string id, Produto pAtualizado) => {
    
    
        foreach(Produto pExiste in produtos)
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


app.MapDelete("/api/produto/deletar/{id}", (string id) => {
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

