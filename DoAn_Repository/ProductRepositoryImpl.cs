using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class ProductRepositoryImpl : IProductRepository
{
    private string _filePath = "Product.json";

    public List<Product> GetList()
    {
        List<Product> products = new List<Product>();
        StreamReader reader = new StreamReader(_filePath);
        string json = reader.ReadToEnd();

        products = JsonConvert.DeserializeObject<List<Product>>(json);

        reader.Close();

        return products;
    }

    public Product GetById(int id)
    {
        List<Product> products = GetList();
        foreach (var product in products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }

        return new Product();
    }

    public void SaveList(List<Product> products)
    {
        StreamWriter sw = new StreamWriter(_filePath);
        string json = JsonConvert.SerializeObject(products);
        sw.Write(json);
        sw.Close();
    }

    public void AddProduct(Product product)
    {
        List<Product> products = GetList();
        products.Add(product);
        SaveList(products);
    }

    public void UpdateProduct(Product product)
    {
        List<Product> products = GetList();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Id == product.Id)
            {
                products[i] = product;
            }
        }

        SaveList(products);
    }

    public void Delete(int id)
    {
        List<Product> products = GetList();
        List<Product> newList = new List<Product>();
        foreach (var c in products)
        {
            if (c.Id != id)
            {
                newList.Add(c);
            }
        }

        SaveList(newList);
    }
}