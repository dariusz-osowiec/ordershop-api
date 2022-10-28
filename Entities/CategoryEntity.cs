using System.ComponentModel.DataAnnotations.Schema;

namespace OrderShopApi.Entities;

[Table("categories")]
public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProductEntity> Products { get; set; }
}
