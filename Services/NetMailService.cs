using System.ComponentModel;
using System.Text;

namespace OrderShopApi.Services;


public class NetMailService : IMailRepository
{
    readonly SmtpClient client;
    readonly MailAddress sender;

    public NetMailService(SettingsService settings)
    {
        sender = new(settings.SettingsFetched.Mail, settings.SettingsFetched.Sender, Encoding.UTF8);
        client = new()
        {
            Host = settings.SettingsFetched.Host,
            Port = settings.SettingsFetched.Port,
            Credentials = new System.Net.NetworkCredential(settings.SettingsFetched.Mail, settings.SettingsFetched.Password)
        };
        client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Implementacja interfejsu.
    ///

    /// <summary>
    /// Wysłanie maila.
    /// </summary>
    /// <returns>True, jeżeli akcja została wykonana poprawnie.</returns>
    public bool Send(MailAddress recipent, string subject, string body)
    {
        try
        {
            MailMessage message = new(sender, recipent);
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = body;
            message.Subject = subject;
            //client.Send(message);
            return true;
        } 
        catch (Exception e)
        {
            Debug.Write(e.StackTrace);
            throw;
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Metody pomocnicze.
    ///

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        string token = (string)e.UserState;

        if (e.Cancelled)
        {
            Console.WriteLine($"[{token}] Send canceled.");
        } 
        if (e.Error != null)
        {
            Console.WriteLine($"[{token}] {e.Error}");
        }
        else
        {
            Console.WriteLine("Message sent.");
        }
    }

}
