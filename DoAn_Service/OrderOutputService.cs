using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class OrderOutputService : IOrderOutputService
{
    private IOrderOutputRepository _orderOutputRepository = new OrderOutputRepositoryImpl();
    private static List<OutputDetail> _OutputDetails = new List<OutputDetail>();

    public List<OutputInvoice> GetList(string keyword = "")
    {
        List<OutputInvoice> invoices = _orderOutputRepository.GetList();
        if (string.IsNullOrEmpty(keyword))
        {
            return invoices;
        }

        List<OutputInvoice> result = new List<OutputInvoice>();
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

    public OutputInvoice GetById(int id)
    {
        return _orderOutputRepository.GetById(id);
    }

    public void AddInvoice(OutputInvoice invoice)
    {
        List<OutputInvoice> invoices = _orderOutputRepository.GetList();
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
        _orderOutputRepository.AddInvoice(invoice);
    }

    public void UpdateInvoice(OutputDetail input, int invoiceId)
    {
        OutputInvoice invoice = _orderOutputRepository.GetById(invoiceId);
        foreach (var detail in invoice.InvoiceDetails)
        {
            if (detail.id == input.id)
            {
                OutputDetail spMoi = detail;
                spMoi.Quantity = input.Quantity;
                spMoi.Price = input.Price;
                spMoi.Product = input.Product;
                _orderOutputRepository.UpdateOutputDetail(spMoi, invoiceId);
            }
        }
    }

    public void AddOutputDetail(OutputDetail outputDetail)
    {
        List<OutputInvoice> invoices = _orderOutputRepository.GetList();
        int maxId = 0;
        foreach (var pr in invoices)
        {
            foreach (var detail in pr.InvoiceDetails)
            {
                if (detail.id > maxId)
                {
                    maxId = detail.id;
                }
            }
        }

        outputDetail.id = maxId + 1 + _OutputDetails.Count;
        _OutputDetails.Add(outputDetail);
    }

    public List<OutputDetail> LoadListDetail()
    {
        return _OutputDetails;
    }

    public void Delete(int id)
    {
        _orderOutputRepository.Delete(id);
    }

    public void DeleteItem(int id, int invoiceId)
    {
        _orderOutputRepository.DeleteItem(id, invoiceId);
    }

    public OutputDetail GetDetailById(int detailId)
    {
        return _orderOutputRepository.GetDetailById(detailId);
    }
}