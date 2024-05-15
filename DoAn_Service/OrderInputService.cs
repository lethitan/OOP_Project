using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class OrderInputService : IOrderInputService
{
    private IOrderInputRepository _orderInputRepository = new OrderInputRepositoryImpl();
    private static List<InputDetail> _inputDetails = new List<InputDetail>();

    public List<InputInvoice> GetList(string keyword = "")
    {
        List<InputInvoice> invoices = _orderInputRepository.GetList();
        if (string.IsNullOrEmpty(keyword))
        {
            return invoices;
        }

        List<InputInvoice> result = new List<InputInvoice>();
        foreach (var invoice in invoices)
        {
            if (invoice.ID.ToString().Contains(keyword) || invoice.Created.ToString("dd/MM/yyyy").Contains(keyword))
            {
                result.Add(invoice);
            }
        }

        return result;
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

    public InputInvoice GetById(int id)
    {
        return _orderInputRepository.GetById(id);
    }

    public void AddInvoice(InputInvoice invoice)
    {
        List<InputInvoice> invoices = _orderInputRepository.GetList();
        int maxId = 0;
        foreach (var pr in invoices)
        {
            if (pr.ID > maxId)
            {
                maxId = pr.ID;
            }
        }

        invoice.ID = maxId + 1;
        invoice.Created = DateTime.Now;
        _orderInputRepository.AddInvoice(invoice);
    }

    public void UpdateInvoice(InputDetail input,int invoiceId)
    {
        InputInvoice invoice = _orderInputRepository.GetById(invoiceId);
        foreach (var detail in invoice.ImportDetails)
        {
            if (detail.id == input.id)
            {
                InputDetail spMoi = detail;
                spMoi.Quantity = input.Quantity;
                spMoi.Price = input.Price;
                spMoi.Product = input.Product;
                _orderInputRepository.UpdateInputDetail(spMoi, invoiceId);
            }
        }
    }

    public void AddInputDetail(InputDetail inputDetail)
    {
        List<InputInvoice> invoices = _orderInputRepository.GetList();
        int maxId = 0;
        foreach (var pr in invoices)
        {
            foreach (var detail in pr.ImportDetails)
            {
                if (detail.id > maxId)
                {
                    maxId = detail.id;
                }
            }
        }

        inputDetail.id = maxId + 1 + _inputDetails.Count;
        _inputDetails.Add(inputDetail);
    }

    public List<InputDetail> LoadListDetail()
    {
        return _inputDetails;
    }

    public void Delete(int id)
    {
        _orderInputRepository.Delete(id);
    }

    public void DeleteItem(int id, int invoiceId)
    {
        _orderInputRepository.DeleteItem(id, invoiceId);
    }

    public InputDetail GetDetailById(int detailId)
    {
        return _orderInputRepository.GetDetailById(detailId);
    }

   
}