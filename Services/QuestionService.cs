namespace OrderShopApi.Services;

public class QuestionService : IQuestionRepository
{
    IMailRepository service;

    public QuestionService(IMailRepository _service)
    {
        service = _service;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Implementacja interfejsu.
    ///

    /// <summary>
    /// Wysłanie zapytania na mail sklepu.
    /// </summary>
    /// <param name="question">Treść zapytania</param>
    /// <returns>True, jeżeli akcja się powiodła.</returns>
    public bool SendQuestion(Question question)
    {
        try
        {
            return service.Send(new MailAddress(question.Mail), $"Pytanie od klienta {question.Mail}", question.Content);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }
}
