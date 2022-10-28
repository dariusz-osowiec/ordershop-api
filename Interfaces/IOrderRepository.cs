namespace OrderShopApi.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    /// Przetworzenie koszyka.
    /// </summary>
    /// <param name="items">Zawartość koszyka.</param>
    /// <returns>String koszyka.</returns>
    string ProcessOrderBody(Order order);

    /// <summary>
    /// Wysłanie maila z zamówieniem na mail sklepowy.
    /// </summary>
    /// <returns></returns>
    bool SendOrder(Customer customer, string body);

    /// <summary>
    /// Wysłanie maila z potwierdzeniem zamówienia do kupującego.
    /// </summary>
    /// <returns></returns> 
    bool SendConfirmation(Customer customer, string body);
}
