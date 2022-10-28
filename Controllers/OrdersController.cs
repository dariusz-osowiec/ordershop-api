namespace OrderShopApi.Controllers;

/// <summary>
/// Kontroler obsługi zamówień.
/// </summary>
[ApiController]
[Route("orders")]
public class OrdersController
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Zmienne.
    ///

    IOrderRepository service;

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Konstruktor.
    ///

    public OrdersController(IOrderRepository service)
    {
        this.service = service;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Metody kontrollera.
    ///

    /// <summary>
    /// Przyjęcie zamówienia i wysłanie maili.
    /// </summary>
    [HttpPost("place")]
    public async Task<IActionResult> ReceiveOrder(Order order)
    {
        try
        {
            if(order == null)
            { 
                return new BadRequestResult();
            }
            return new OkResult();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            return new ObjectResult(e.Message)
            {
                StatusCode = 500
            };
        }
    }
}
