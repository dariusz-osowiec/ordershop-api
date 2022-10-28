namespace OrderShopApi.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Dodanie produktu do bazy.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    bool Create(Product product);

    /// <summary>
    /// Wyciągnięcie wszystkich produktów z bazy.
    /// </summary>
    /// <returns></returns>
    List<Product> ReadAll();

    /// <summary>
    /// Wyciągnięcie promowanych produktów z bazy (one pokazują się na stronie głównej).
    /// </summary>
    /// <returns></returns>
    List<Product> ReadPromoted();

    /// <summary>
    /// Wyciągnięcie konkretnego produktu z bazy.
    /// </summary>
    /// <param name="id">Id poszukiwanego produktu w bazie.</param>
    /// <returns></returns>
    Product Read(int id);

    /// <summary>
    /// Zaktualizowanie produktu w bazie.
    /// </summary>
    /// <param name="product">Produkt do zaktualizowania.</param>
    /// <returns></returns>
    bool Update(Product product);

    /// <summary>
    /// Usunięcie produktu w bazie.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete(int id);
}
