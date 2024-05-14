namespace DoAn_Entity;

public class OutputInvoice
{
    //Thanh phan du lieu
    public int ID { get; set; }
    public string CustomerName { get; set; }

    private DateTime _created;
    private OutputDetail[] _invoiceDetails;

    public DateTime Created
    {
        get => _created;
        set
        {
            if (value > DateTime.Today)
            {
                _created = value;
            }
        }
    }

    public OutputDetail[] InvoiceDetails
    {
        get => _invoiceDetails;
        set => _invoiceDetails = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double SumAmount()
    {
        double sum = 0;
        foreach (var invoice in _invoiceDetails)
        {
            sum += invoice.TotalAmount();
        }

        return sum;
    }

    public int SumQuantity()
    {
        int quantity = 0;
        foreach (var invoice in _invoiceDetails)
        {
            quantity += invoice.Quantity;
        }

        return quantity;
    }
}