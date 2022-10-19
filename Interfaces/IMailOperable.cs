
namespace OrderShopApi.Interfaces;

public interface IMailOperable
{
    /// <summary>
    /// Wysłanie maila.
    /// </summary>
    /// <returns>True, jeżeli akcja została wykonana poprawnie.</returns>
    bool Send(MailAddress recipent, string subject, string body);

}
