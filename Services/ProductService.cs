using OrderShopApi.Entities;

namespace OrderShopApi.Services;

/// <summary>
/// Implementacja interfejsu obsługi bazy danych (SQLite).
/// </summary>
public class ProductService : IProductRepository
{
    /// <summary>
    /// Kontekst używanej bazy danych.
    /// </summary>
    readonly SQLiteContext context;

    public ProductService(SQLiteContext _context)
    {
        context = _context;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Implementacja interfejsu.
    ///

    /// <summary>
    /// Dodanie produktu do bazy.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool Create(Product product)
    {
        try
        {
            context.AddAsync(product);
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Wyciągnięcie wszystkich produktów z bazy.
    /// </summary>
    /// <returns></returns>
    public List<Product> ReadAll()
    {
        try
        {
            var products = from p in context.Products
                           join c in context.Categories on p.CategoryId equals c.Id
                           select new Product()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               CategoryId = p.CategoryId,
                               Price = p.Price,
                               ImageUrl = p.ImageUrl,
                               Description = p.Description,
                               ShortDescription = p.ShortDescription,
                               IsPromoted = p.IsPromoted
                           };
            return products.ToList();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Wyciągnięcie promowanych produktów z bazy (one pokazują się na stronie głównej).
    /// </summary>
    /// <returns></returns>
    public List<Product> ReadPromoted()
    {
        try
        {
            var products = from p in context.Products
                           join c in context.Categories on p.CategoryId equals c.Id
                           where p.IsPromoted
                           select new Product()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               CategoryId = p.CategoryId,
                               Price = p.Price,
                               ImageUrl = p.ImageUrl,
                               Description = p.Description,
                               ShortDescription = p.ShortDescription,
                           };
            return products.ToList();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Wyciągnięcie konkretnego produktu z bazy.
    /// </summary>
    /// <param name="id">Id poszukiwanego produktu w bazie.</param>
    /// <returns></returns>
    public Product Read(int id)
    {
        try
        {
            Product? product = (Product)context.Find<ProductEntity>(id);
            return product;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Zaktualizowanie produktu w bazie.
    /// </summary>
    /// <param name="product">Produkt do zaktualizowania.</param>
    /// <returns></returns>
    public bool Update(Product product)
    {
        try
        {
            Product productToUpdate = (Product)context.Find<ProductEntity>(product.Id);
            if (productToUpdate == null)
            {
                return false;
            }
            ProductEntity productEntity = (ProductEntity)product;
            context.Update(productEntity);
            context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Usunięcie produktu w bazie.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        try
        {
            ProductEntity productEntity = context.Find<ProductEntity>(id);
            if (productEntity == null)
            {
                return false;
            }
            context.Remove(productEntity);
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }
}
