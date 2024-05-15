using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class ProductService : IProductService
{
    private IProductRepository _productRepository = new ProductRepositoryImpl();

    private IOrderOutputService _orderOutputService = new OrderOutputService();

    private IOrderInputService _orderInputService = new OrderInputService();

    public List<Product> GetList()
    {
        return _productRepository.GetList();
    }

    public List<Product> Search(string keyword, List<Product> products)
    {
        List<Product> results = new List<Product>();
        if (!string.IsNullOrEmpty(keyword))
        {
            foreach (var pr in products)
            {
                if (pr.Id.ToString().Contains(keyword)
                    || pr.Name.Contains(keyword)
                    || pr.Category.Name.Contains(keyword)
                    || pr.Provider.Contains(keyword)
                    || pr.Created.ToString("dd/MM/yyyy").Contains(keyword)
                    || pr.ExpDate.ToString("dd/MM/yyyy").Contains(keyword))
                {
                    results.Add(pr);
                }
            }

            return results;
        }

        return products;
    }

    public Product GetById(int id)
    {
        return _productRepository.GetById(id);
    }

    public void AddProduct(Product product)
    {
        List<Product> products = _productRepository.GetList();
        int maxId = 0;
        foreach (var pr in products)
        {
            if (pr.Id > maxId)
            {
                maxId = pr.Id;
            }
        }

        product.Id = maxId + 1;
        _productRepository.AddProduct(product);
    }

    public Product UpdateProduct(Product newProduct)
    {
        bool check = true;
        if (newProduct.Id <= 0) check = false;
        if (newProduct.Created > newProduct.ExpDate) check = false;
        if (check)
        {
            Product product = _productRepository.GetById(newProduct.Id);

            product.Name = newProduct.Name;
            product.ExpDate = newProduct.ExpDate;
            product.Created = newProduct.Created;
            product.Provider = newProduct.Provider;
            product.Category = newProduct.Category;
            _productRepository.UpdateProduct(product);
            return product;
        }

        return new Product();
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }

    public int CountInventory(int id)
    {
        return _orderInputService.CountInventoryById(id) -
               _orderOutputService.CountInventoryById(id);
    }

    public List<Product> GetListInventory()
    {
        List<Product> products = _productRepository.GetList();
        List<Product> inventory = new List<Product>();
        foreach (var product in products)
        {
            if (_orderInputService.CountInventoryById(product.Id) >
                _orderOutputService.CountInventoryById(product.Id))
            {
                inventory.Add(product);
            }
        }

        return inventory;
    }

    public List<Product> GetListExpires()
    {
        List<Product> products = _productRepository.GetList();
        List<Product> expires = new List<Product>();

        foreach (var product in products)
        {
            if (product.ExpDate < DateTime.Now)
            {
                expires.Add(product);
            }
        }
        
        return expires;
    }
}