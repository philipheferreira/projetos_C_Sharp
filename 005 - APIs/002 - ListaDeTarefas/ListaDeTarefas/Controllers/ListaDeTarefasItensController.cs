using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers;

[ApiController]
[Route("api/[controller]")] // rota: api/tarefas
public class TarefasController : ControllerBase
{
    private static readonly List<Tarefa> _tarefas = new()
    {
        new Tarefa { Id = 1, Titulo = "Estudar C# e .NET", Concluida = false, DataCriacao = DateTime.Now },
        new Tarefa { Id = 2, Titulo = "Criar testes no Postman", Concluida = false, DataCriacao = DateTime.Now },
        new Tarefa { Id = 3, Titulo = "Configurar o ambiente", Concluida = true, DataCriacao = DateTime.Now }
    };

    // ⚠️ Começa em 4, porque os IDs 1, 2 e 3 já estão ocupados!
    private static int _proximoId = 4;

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Listar() => Ok(_tarefas);

    [HttpGet("{id}")]
    public ActionResult<Tarefa> BuscarPorId(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        return tarefa is null ? NotFound() : Ok(tarefa);
    }

    [HttpPost]
    public ActionResult<Tarefa> Criar(Tarefa tarefa)
    {
        tarefa.Id = _proximoId++;
        tarefa.DataCriacao = DateTime.Now;
        _tarefas.Add(tarefa);
        return CreatedAtAction(nameof(BuscarPorId), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Tarefa tarefaAtualizada)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa is null) return NotFound();

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Concluida = tarefaAtualizada.Concluida;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa is null) return NotFound();

        _tarefas.Remove(tarefa);
        return NoContent();
    }
}