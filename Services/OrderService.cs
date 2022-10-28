using Castle.Core.Internal;

namespace OrderShopApi.Services;

public class OrderService : IOrderRepository
{
    IMailRepository service;
    IProductRepository productService;
    SettingsService settings;

    public OrderService(IMailRepository _service, IProductRepository _productService, SettingsService _settingsService)
    {
        service = _service;
        productService = _productService;
        settings = _settingsService;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Implementacja interfejsu.
    ///

    /// <summary>
    /// Przetworzenie koszyka.
    /// </summary>
    /// <param name="items">Zawartość koszyka.</param>
    /// <returns>String koszyka.</returns>
    public string ProcessOrderBody(Order order)
    {
        List<Product> products = productService.ReadAll();
        Product product = new Product();
        int i = 1;
        string orderString = 
            "Osoba zamawiająca: \n\n" +
            $"{order.Customer.Name} {order.Customer.Surname}\n" +
            $"{order.Customer.Address}\n" +
            $"{order.Customer.PostCode} {order.Customer.City}\n" +
            $"e-mail: {order.Customer.Mail}\n" +
            $"telefon: {order.Customer.Phone}\n\n" +
            "Szczegóły zamówienia:\n\n";

        //Szczegóły zamówienia.
        foreach(Item item in order.Items)
        {
            product = products.Where(i => i.Id.Equals(item.Id)).First();
            orderString += $"\n{i}. {product.Name} - {item.Qty} * {product.Price} = {item.Qty * product.Price}";
            i++;
        }

        //Nota do zamówienia.
        if(!order.Note.IsNullOrEmpty())
        {
            orderString += "\n\nNota do zamówienia: \n" + order.Note;
        }

        return orderString;
    }

    /// <summary>
    /// Wysłanie maila z potwierdzeniem zamówienia do kupującego.
    /// </summary>
    /// <returns>True, jeżeli akcja się powiodła.</returns> 
    public bool SendConfirmation(Customer customer, string body)
    {
        try
        {
            body = @"
            Dzień dobry! 
            Oto potwierdzenie Twojego zamówienia: 

            " + body;
            return service.Send(new MailAddress(customer.Mail), "Potwierdzenie zamówienia", body);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }

    }

    /// <summary>
    /// Wysłanie maila z zamówieniem na mail sklepowy.
    /// </summary>
    /// <returns>True, jeżeli akcja się powiodła.</returns>
    public bool SendOrder(Customer customer, string body)
    {
        try
        {
            body = @"
            Dzień dobry!
            Zarejestrowano nowe zamówienie:

            " + body;
            return service.Send(new MailAddress(settings.SettingsFetched.TargetMail), $"Nowe zamówienie od {customer.Name} {customer.Surname}", body);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }
}
