namespace RepositorySolucao.Repositories.Interfaces
{
    public interface IRepository
    {
            IEnumerable<T> Get<T>() where T : class;
            T GetById<T>(int id) where T : class;
            void Adicionar<T>(T entity) where T : class;
            void Atualizar<T>(T entity) where T : class;
            void Remover<T>(T entity) where T : class;
            bool SaveChanges();
        }
    }

