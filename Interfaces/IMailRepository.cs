
namespace OrderShopApi.Interfaces;

public interface IMailRepository
{
    /// <summary>
    /// Wysłanie maila.
    /// </summary>
    /// <returns>True, jeżeli akcja została wykonana poprawnie.</returns>
    bool Send(MailAddress recipent, string subject, string body);

}
