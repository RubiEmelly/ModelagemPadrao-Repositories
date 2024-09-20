using RepositorySolucao.Models;

namespace RepositorySolucao.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository
    {
        Cliente GetByCPF(string CPF);
    }
}
