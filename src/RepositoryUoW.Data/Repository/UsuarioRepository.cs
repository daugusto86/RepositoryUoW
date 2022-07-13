using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Models;
using RepositoryUoW.Data.Context;

namespace RepositoryUoW.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryUoWContext context) : base(context)
        {
            
        }
    }
}
