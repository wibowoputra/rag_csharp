using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) { _mediator = mediator; }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Application.Orders.Commands.CreateOrderCommand cmd)
    {
        var id = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(Get), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var dto = await _mediator.Send(new Application.Orders.Queries.GetOrderQuery(id));
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}