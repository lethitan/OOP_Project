namespace DoAn_Entity;

public class OutputInvoice
{
    //Thanh phan du lieu
    public int ID { get; set; }
    public DateTime Created { get; set; }

    private List<OutputDetail> _invoiceDetails;

    public OutputInvoice()
    {
    }

    public OutputInvoice(List<OutputDetail> invoiceDetails)
    {
        _invoiceDetails = invoiceDetails;
    }

    public List<OutputDetail> InvoiceDetails
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