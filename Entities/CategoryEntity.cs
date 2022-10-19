using System.ComponentModel.DataAnnotations.Schema;

namespace OrderShopApi.Entities;

[Table("category")]
public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProductEntity> Products { get; set; }
}
