using API_CRUD_NET6.Models;
using API_CRUD_NET6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_NET6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() =>
            Ok(ProdutoRepository.ObterTodos());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = ProdutoRepository.ObterPorId(id);
            return produto is null ? NotFound() : Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            var novoProduto = ProdutoRepository.Criar(produto);
            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            var atualizado = ProdutoRepository.Atualizar(id, produto);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var removido = ProdutoRepository.Remover(id);
            return removido ? NoContent() : NotFound();
        }
    }
}
