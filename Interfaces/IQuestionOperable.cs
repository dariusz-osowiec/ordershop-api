namespace OrderShopApi.Interfaces;

public interface IQuestionOperable
{
    /// <summary>
    /// Wysłanie zapytania na mail sklepu.
    /// </summary>
    /// <param name="question">Treść zapytania</param>
    /// <returns>True, jeżeli akcja się powiodła.</returns>
    bool SendQuestion(Question question);
}
