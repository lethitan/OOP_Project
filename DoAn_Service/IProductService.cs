using DoAn_Entity;

namespace DoAn_Service;

public interface IProductService
{
    List<Product> GetList();
    List<Product> GetListInventory();
    List<Product> GetListExpires();
    int CountInventory(int id);
    List<Product> Search(string keyword, List<Product> products);
    Product GetById(int id);
    void AddProduct(Product product);
    Product UpdateProduct(Product product);
    void Delete(int id);
}