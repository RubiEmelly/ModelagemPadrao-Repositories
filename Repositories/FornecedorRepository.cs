using RepositorySolucao.Data;
using RepositorySolucao.Repositories.Interfaces;

namespace RepositorySolucao.Repositories
{
    public class FornecedorRepository: Repository, IFornecedorRepository
    {
        public FornecedorRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
