using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class OrderInputService : IOrderInputService
{
    private IOrderInputRepository _orderInputRepository = new OrderInputRepositoryImpl();

    public List<InputInvoice> GetList()
    {
        throw new NotImplementedException();
    }

    public int CountInventoryById(int id)
    {
        int sum = 0;
        List<InputInvoice> invoices = _orderInputRepository.GetList();
        foreach (var invoice in invoices)
        {
            foreach (var detail in invoice.ImportDetails)
            {
                if (detail.Product.Id == id)
                {
                    sum += detail.Quantity;
                }
            }
        }

        return sum;
    }

    public List<InputInvoice> GetListInventory()
    {
        throw new NotImplementedException();
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