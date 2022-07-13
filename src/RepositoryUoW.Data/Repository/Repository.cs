using Microsoft.EntityFrameworkCore;
using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Models;
using RepositoryUoW.Data.Context;
using System.Linq.Expressions;

namespace RepositoryUoW.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly RepositoryUoWContext context;
        protected readonly DbSet<TEntity> DbSet;
        public IUnitOfWork UnitOfWork => context;

        public Repository(RepositoryUoWContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public void Dispose() => context?.Dispose();
    }
}
