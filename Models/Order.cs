namespace OrderShopApi.Models;

public class Order
{
    public Customer? Customer { get; set; }
    public List<Item>? Items { get; set; }
    public string? Note { get; set; }

}
