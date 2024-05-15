using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class OrderOutputService : IOrderOutputService
{
    private IOrderOutputRepository _orderOutputRepository = new OrderOutputRepositoryImpl();

    public List<InputInvoice> GetList()
    {
        throw new NotImplementedException();
    }

    public int CountInventoryById(int id)
    {
        int sum = 0;
        List<OutputInvoice> invoices = _orderOutputRepository.GetList();
        foreach (var invoice in invoices)
        {
            foreach (var detail in invoice.InvoiceDetails)
            {
                if (detail.Product.Id == id)
                {
                    sum += detail.Quantity;
                }
            }
        }

        return sum;
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