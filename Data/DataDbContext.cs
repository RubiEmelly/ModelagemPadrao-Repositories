using Microsoft.EntityFrameworkCore;
using RepositorySolucao.Models;

namespace RepositorySolucao.Data
{
    public class DataDbContext : DbContext
    {
            public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
            {
            }

            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Fornecedor> Fornecedores { get; set; }

            // Outros DbSets podem ser adicionados aqui
        }
}
