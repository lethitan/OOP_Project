using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class OrderOutputRepositoryImpl : IOrderOutputRepository
{
    public List<OutputInvoice> GetList()
    {
        List<OutputInvoice> invoices;
        StreamReader reader = new StreamReader("./OutputInvoice.json");
        string json = reader.ReadToEnd();

        invoices = JsonConvert.DeserializeObject<List<OutputInvoice>>(json);

        reader.Close();

        return invoices;
    }

    public OutputInvoice GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(OutputInvoice invoice)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(OutputInvoice invoice)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}