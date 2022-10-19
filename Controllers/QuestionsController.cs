namespace OrderShopApi.Controllers;

/// <summary>
/// Kontroler obsługi zapytań od klienta.
/// </summary>
[ApiController]
[Route("questions")]
public class QuestionsController
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Zmienne.
    ///

    IQuestionOperable service;

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Konstruktor.
    ///

    public QuestionsController(IQuestionOperable service)
    {
        this.service = service;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Metody kontrollera.
    ///

    /// <summary>
    /// Przyjęcie zapytania od klienta.
    /// </summary>
    /// <returns>Odpowiedź serwera - true, jeżeli akcja została wykonana poprawnie.</returns>
    [HttpPost("ask")]
    public async Task<IActionResult> ReceiveQuestion(Question question)
    {
        try
        {
            if(question == null)
            {
                return new BadRequestResult();
            }

            service.SendQuestion(question);

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
