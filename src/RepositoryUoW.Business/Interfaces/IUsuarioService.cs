using RepositoryUoW.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUoW.Business.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterPorId(Guid id);
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> ObterPorEmail(string email);
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(Guid id);
    }
}
