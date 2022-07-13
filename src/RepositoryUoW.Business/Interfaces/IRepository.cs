using RepositoryUoW.Business.Models;
using System.Linq.Expressions;

namespace RepositoryUoW.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
