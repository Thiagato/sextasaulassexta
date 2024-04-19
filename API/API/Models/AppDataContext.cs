using Microsoft.EntityFrameworkCore;

namespace API.Models;

//classe que representa o EF dentro do projeto  
public class AppDataContext : DbContext{

//classe que vao representar as tabelas no banco de dados
    public DbSet<Produto> TabelaProdutos {get; set;}
    //override == toString
    //configurando qual banco de dados vai ser utilizado
    //configurando a string de conexao
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

}