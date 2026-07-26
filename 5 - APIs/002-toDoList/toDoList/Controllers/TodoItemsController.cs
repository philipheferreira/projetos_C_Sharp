using Microsoft.AspNetCore.Mvc;
using toDoList.Models;

namespace toDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        // Nossa lista simulando o banco de dados em memória
        private static List<TodoItem> _tarefas = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Estudar C#", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Configurar VS 2022", IsCompleted = true }
        };

        // GET: api/todoitems
        [HttpGet]
        public ActionResult<List<TodoItem>> GetTodasTarefas()
        {
            return Ok(_tarefas);
        }

        // POST: api/todoitems
        [HttpPost]
        public ActionResult<TodoItem> CriarTarefa(TodoItem novaTarefa)
        {
            novaTarefa.Id = _tarefas.Any() ? _tarefas.Max(t => t.Id) + 1 : 1;
            _tarefas.Add(novaTarefa);

            return CreatedAtAction(nameof(GetTodasTarefas), new { id = novaTarefa.Id }, novaTarefa);
        }
    }
}