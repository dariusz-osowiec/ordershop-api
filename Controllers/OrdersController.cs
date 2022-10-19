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

    IOrderOperable service;

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Konstruktor.
    ///

    public OrdersController(IOrderOperable service)
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
            string body = service.ProcessOrderBody(order);
            if(!service.SendOrder(order.Customer, body))
            {
                return new StatusCodeResult(500);
            }
            if(!service.SendConfirmation(order.Customer, body))
            {
                return new StatusCodeResult(500);
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
