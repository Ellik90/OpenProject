using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenProject.Models;
using Dapper;
using MySqlConnector;


namespace OpenProject.Controllers;

[Route("/")]
[ApiController]
public class OpenProjectItemsController : ControllerBase
{
    private readonly    ILogger<OpenProjectItemsController> _logger;

    public OpenProjectItemsController(ILogger<OpenProjectItemsController> logger)
    {
        _logger = logger;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OpenProjectItem>>> GetTodoItems()
    {
        // var items = await _context.OpenProjectItems.ToListAsync();
        // return Ok(items.Select(x => ItemToDTO(x)));
        try
        {
        using MySqlConnection con = new ("Server=localhost;Database=API_datab;User=root;Password=;");
        string query = "SELECT id AS 'Id', name AS 'Name', is_complete AS 'IsComplete', secret AS 'Secret' FROM item;";
        var items = con.Query<OpenProjectItem>(query).ToList();
        return Ok(items);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An eroor is here");
            throw;
        }


    }


    // // GET: api/OpenProjectItems/5
    // // <snippet_GetByID>
    // [HttpGet("{id}")]
    // public async Task<ActionResult<OpenProjectDTO>> GetTodoItem(long id)
    // {
    //     var todoItem = await _context.OpenProjectItems.FindAsync(id);

    //     if (todoItem == null)
    //     {
    //         return NotFound();
    //     }

    //     return ItemToDTO(todoItem);
    // }
    // // </snippet_GetByID>

    // // PUT: api/TodoItems/5
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // // <snippet_Update>
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutTodoItem(long id, OpenProjectDTO todoDTO)
    // {
    //     if (id != todoDTO.Id)
    //     {
    //         return BadRequest();
    //     }

    //     var todoItem = await _context.OpenProjectItems.FindAsync(id);
    //     if (todoItem == null)
    //     {
    //         return NotFound();
    //     }

    //     todoItem.Name = todoDTO.Name;
    //     todoItem.IsComplete = todoDTO.IsComplete;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
    //     {
    //         return NotFound();
    //     }

    //     return NoContent();
    // }
    // // </snippet_Update>

    // // POST: api/TodoItems
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // // <snippet_Create>
    // [HttpPost]
    // public async Task<ActionResult<OpenProjectDTO>> PostTodoItem(OpenProjectDTO todoDTO)
    // {
    //     var todoItem = new OpenProjectItem
    //     {
    //         IsComplete = todoDTO.IsComplete,
    //         Name = todoDTO.Name
    //     };

    //     _context.OpenProjectItems.Add(todoItem);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(
    //         nameof(GetTodoItem),
    //         new { id = todoItem.Id },
    //         ItemToDTO(todoItem));
    // }
    // // </snippet_Create>

    // // DELETE: api/TodoItems/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteTodoItem(long id)
    // {
    //     var todoItem = await _context.OpenProjectItems.FindAsync(id);
    //     if (todoItem == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.OpenProjectItems.Remove(todoItem);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

    // private bool TodoItemExists(long id)
    // {
    //     return _context.OpenProjectItems.Any(e => e.Id == id);
    // }

    // private static OpenProjectDTO ItemToDTO(OpenProjectItem todoItem) =>
    //    new OpenProjectDTO
    //    {
    //        Id = todoItem.Id,
    //        Name = todoItem.Name,
    //        IsComplete = todoItem.IsComplete
    //    };
}