using RepositorySolucao.Data;
using RepositorySolucao.Models;
using RepositorySolucao.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace RepositorySolucao.Repositories
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(DataDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente GetByCPF(string CPF)
        {
            return _dbContext.Set<Cliente>().AsNoTracking()
                .FirstOrDefault(c => c.CPF == CPF);
        }
    }
}

