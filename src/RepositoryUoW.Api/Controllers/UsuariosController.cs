using Microsoft.AspNetCore.Mvc;
using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Models;

namespace RepositoryUoW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService service;

        public UsuariosController(IUsuarioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            return Ok( await service.ObterTodos());
        }

        [HttpGet("buscar-por-email/{email}")]
        public async Task<ActionResult> ObterPorEmail(string email)
        {
            return Ok(await service.ObterPorEmail(email));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return Ok(await service.ObterPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(Usuario usuario)
        {
            await service.Adicionar(usuario);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            await service.Atualizar(usuario);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            await service.Remover(id);
            return Ok();
        }
    }
}
