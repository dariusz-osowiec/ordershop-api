using OrderShopApi.Entities;

namespace OrderShopApi.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public bool IsPromoted { get; set; }
}
