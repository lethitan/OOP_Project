using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class OrderOutputRepositoryImpl : IOrderOutputRepository
{
    private string _filePath = "./OutputInvoice.json";

    public List<OutputInvoice> GetList()
    {
        List<OutputInvoice> invoices;
        StreamReader reader = new StreamReader("_filePath");
        string json = reader.ReadToEnd();

        invoices = JsonConvert.DeserializeObject<List<OutputInvoice>>(json);

        reader.Close();

        return invoices;
    }
    

    public OutputInvoice GetById(int id)
    {
        List<OutputInvoice> invoices = GetList();
        foreach (var sp in invoices)
        {
            if (sp.ID == id)
            {
                return sp;
            }
        }

        return new OutputInvoice();
    }

    public void SaveList(List<OutputInvoice> invoices)
    {
        StreamWriter sw = new StreamWriter(_filePath);
        string json = JsonConvert.SerializeObject(invoices);
        sw.Write(json);
        sw.Close();
    }

    public void AddInvoice(OutputInvoice invoice)
    {
        List<OutputInvoice> invoices = GetList();
        invoices.Add(invoice);
        SaveList(invoices);
    }

    public void Update(OutputInvoice invoice)
    {
        List<OutputInvoice> invoices = GetList();
        for (int i = 0; i < invoices.Count; i++)
        {
            if (invoices[i].ID == invoice.ID)
            {
                invoices[i] = invoice;
            }
        }

        SaveList(invoices);
    }

    public void Delete(int id)
    {
        List<OutputInvoice> invoices = GetList();
        List<OutputInvoice> newList = new List<OutputInvoice>();
        foreach (var c in invoices)
        {
            if (c.ID != id)
            {
                newList.Add(c);
            }
        }

        SaveList(newList);
    }

    public void DeleteItem(int id, int invoiceId)
    {
        OutputInvoice invoice = GetById(invoiceId);
        List<OutputDetail> dsCu = invoice.InvoiceDetails;
        List<OutputDetail> dsMoi = new List<OutputDetail>();
        foreach (var detail in dsCu)
        {
            if (detail.id != id)
            {
                dsMoi.Add(detail);
            }
        }

        invoice.InvoiceDetails = dsMoi;

        SaveInvoice(invoice);
    }

    public OutputDetail GetDetailById(int detailId)
    {
        List<OutputInvoice> invoices = GetList();
        foreach (var sp in invoices)
        {
            foreach (var detail in sp.InvoiceDetails)
            {
                if (detail.id == detailId)
                {
                    return detail;
                }
            }
        }

        return new OutputDetail();
    }

    private void SaveInvoice(OutputInvoice invoice)
    {
        List<OutputInvoice> invoices = GetList();
        for (int i = 0; i < invoices.Count; i++)
        {
            if (invoices[i].ID == invoice.ID)
            {
                invoices[i] = invoice;
            }
        }

        SaveList(invoices);
    }

    public OutputDetail UpdateOutputDetail(OutputDetail input, int invoiceId)
    {
        List<OutputInvoice> invoices = GetList();
        foreach (var detail in invoices)
        {
            if (detail.ID == invoiceId)
            {
                for (int i = 0; i < detail.InvoiceDetails.Count; i++)
                {
                    if (detail.InvoiceDetails[i].id == input.id)
                    {
                        detail.InvoiceDetails[i] = input;
                        SaveInvoice(detail);
                        return input;
                    }
                }
            }
        }

        return new OutputDetail();
    }
}