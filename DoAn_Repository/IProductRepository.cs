using DoAn_Entity;

namespace DoAn_Repository;

public interface IProductRepository
{
    List<Product> GetList();
    Product GetById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void Delete(int id);
}