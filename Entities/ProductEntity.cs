using System.ComponentModel.DataAnnotations.Schema;

namespace OrderShopApi.Entities;

[Table("product")]
public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public bool IsPromoted { get; set; }

    /////////////////////////////////////////////////////////////////////////////
    ///Konwersje encji.

    /// <summary>
    /// Konwersja do DTO.
    /// </summary>
    /// <param name="entity">Encja obiektu.</param>
    public static implicit operator Product(ProductEntity entity)
    {
        return new Product()
        {
            Id = entity.Id,
            Name = entity.Name,
            CategoryId = entity.Category.Id,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl
        };
    }

    /// <summary>
    /// Konwersja z DTO.
    /// </summary>
    /// <param name="dto">DTO obiektu.</param>
    public static explicit operator ProductEntity(Product dto)
    {
        return new ProductEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl
        };
    }
}
