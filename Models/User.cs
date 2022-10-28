namespace OrderShopApi.Models;

public class User: UserCreds
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public bool IsActivated { get; set; }
    public string ActivationToken { get; set; }

}
