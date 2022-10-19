using Microsoft.AspNetCore.Mvc;

namespace OrderShopApi.Controllers;

/// <summary>
/// Kontroler zarządzania dostępem do DB.
/// </summary>
[ApiController]
[Route("db")]
public class DbController
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Zmienne.
    ///

    private readonly IDbOperable service;

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Konstruktor.
    ///

    public DbController(IDbOperable service)
    {
        this.service = service;
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Metody kontrollera.
    ///

    /// <summary>
    /// Wyciągnięcie wszystkich produktów z bazy.
    /// </summary>
    /// <returns></returns>
    [HttpGet("readall")]
    public async Task<IActionResult> ReadAll()
    {
        try
        {
            List<Product> products = service.ReadAll();
            if(products == null)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(products);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ObjectResult(e.Message)
            {
                StatusCode = 500
            };
        }
    }

    /// <summary>
    /// Wyciągnięcie wszystkich produktów z bazy.
    /// </summary>
    /// <returns></returns>
    [HttpGet("readpromoted")]
    public async Task<IActionResult> ReadAllPromoted()
    {
        try
        {
            List<Product> products = service.ReadPromoted();
            if (products == null)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(products);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ObjectResult(e.Message)
            {
                StatusCode = 500
            };
        }
    }

}
