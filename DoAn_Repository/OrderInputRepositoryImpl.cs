using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class OrderInputRepositoryImpl : IOrderInputRepository
{
    public List<InputInvoice> GetList()
    {
        List<InputInvoice> invoices;
        StreamReader reader = new StreamReader("./InputInvoice.json");
        string json = reader.ReadToEnd();

        invoices = JsonConvert.DeserializeObject<List<InputInvoice>>(json);

        reader.Close();

        return invoices;
    }

    public InputInvoice GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(InputInvoice invoice)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(InputInvoice invoice)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}