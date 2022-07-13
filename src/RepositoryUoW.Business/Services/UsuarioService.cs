using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Models;

namespace RepositoryUoW.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await repository.ObterPorId(id);
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            var usuarios = await repository.Buscar(x => x.Email == email);
            return usuarios.FirstOrDefault();
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await repository.ObterTodos();
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            repository.Adicionar(usuario);
            return await repository.UnitOfWork.Commit();
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            repository.Atualizar(usuario);
            return await repository.UnitOfWork.Commit();
        }

        public async Task<bool> Remover(Guid id)
        {
            repository.Remover(id);
            return await repository.UnitOfWork.Commit();
        }
    }
}
