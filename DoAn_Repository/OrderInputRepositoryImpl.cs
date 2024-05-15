using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class OrderInputRepositoryImpl : IOrderInputRepository
{
    private string _filePath = "./InputInvoice.json";

    public List<InputInvoice> GetList()
    {
        List<InputInvoice> invoices;
        StreamReader reader = new StreamReader(_filePath);
        string json = reader.ReadToEnd();

        invoices = JsonConvert.DeserializeObject<List<InputInvoice>>(json);

        reader.Close();

        return invoices;
    }

    public InputInvoice GetById(int id)
    {
        List<InputInvoice> invoices = GetList();
        foreach (var sp in invoices)
        {
            if (sp.ID == id)
            {
                return sp;
            }
        }

        return new InputInvoice();
    }

    public void SaveList(List<InputInvoice> invoices)
    {
        StreamWriter sw = new StreamWriter(_filePath);
        string json = JsonConvert.SerializeObject(invoices);
        sw.Write(json);
        sw.Close();
    }

    public void AddInvoice(InputInvoice invoice)
    {
        List<InputInvoice> invoices = GetList();
        invoices.Add(invoice);
        SaveList(invoices);
    }

    public void Update(InputInvoice invoice)
    {
        List<InputInvoice> invoices = GetList();
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
        List<InputInvoice> products = GetList();
        List<InputInvoice> newList = new List<InputInvoice>();
        foreach (var c in products)
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
        InputInvoice invoice = GetById(invoiceId);
        List<InputDetail> dsCu = invoice.ImportDetails;
        List<InputDetail> dsMoi = new List<InputDetail>();
        foreach (var detail in dsCu)
        {
            if (detail.id != id)
            {
                dsMoi.Add(detail);
            }
        }

        invoice.ImportDetails = dsMoi;

        SaveInvoice(invoice);
    }

    public InputDetail GetDetailById(int detailId)
    {
        List<InputInvoice> invoices = GetList();
        foreach (var sp in invoices)
        {
            foreach (var detail in sp.ImportDetails)
            {
                if (detail.id == detailId)
                {
                    return detail;
                }
            }
        }

        return new InputDetail();
    }

    private void SaveInvoice(InputInvoice invoice)
    {
        List<InputInvoice> invoices = GetList();
        for (int i = 0; i < invoices.Count; i++)
        {
            if (invoices[i].ID == invoice.ID)
            {
                invoices[i] = invoice;
            }
        }

        SaveList(invoices);
    }

    public InputDetail UpdateInputDetail(InputDetail input, int invoiceId)
    {
        List<InputInvoice> invoices = GetList();
        foreach (var detail in invoices)
        {
            if (detail.ID == invoiceId)
            {
                for (int i = 0; i < detail.ImportDetails.Count; i++)
                {
                    if (detail.ImportDetails[i].id == input.id)
                    {
                        detail.ImportDetails[i] = input;
                        SaveInvoice(detail);
                        return input;
                    }
                }
            }
        }

        return new InputDetail();
    }
}