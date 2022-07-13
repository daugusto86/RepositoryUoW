using Microsoft.EntityFrameworkCore;
using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Models;

namespace RepositoryUoW.Data.Context
{
    public class RepositoryUoWContext : DbContext, IUnitOfWork
    {
        public RepositoryUoWContext(DbContextOptions<RepositoryUoWContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
