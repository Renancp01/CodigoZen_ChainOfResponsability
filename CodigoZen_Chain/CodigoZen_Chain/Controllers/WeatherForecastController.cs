using CodigoZen_Chain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CodigoZen_Chain.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IEnumerable<IOrderHandler> _handlers;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IEnumerable<IOrderHandler> handlers)
    {
        _handlers = handlers;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        var handler = _handlers.SingleOrDefault(h => h.CanHandle(order.Fornecedor));

        if (handler == null)
        {
            return BadRequest("No handler available for the specified fornecedor type.");
        }

        handler.Handle(order);

        return Ok(new
        {
            order.Id,
            order.ValorTotal,
            order.IsValid,
            order.Desconto,
            order.NotificacaoEnviada,
            order.IofAmount
        });
    }
}