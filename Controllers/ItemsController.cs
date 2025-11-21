using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemService _service;

    public ItemsController(ItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Server error: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound("Item not found");

            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Server error: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newItem = _service.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Item item)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _service.Update(id, item);
            if (!updated)
                return NotFound("Item not found");

            return NoContent(); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Server error: {ex.Message}");
        }
    }
}
