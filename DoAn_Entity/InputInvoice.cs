namespace DoAn_Entity;

public class InputInvoice
{
    //Thanh phan du lieu
    public int ID { get; set; }
    private List<InputDetail> _importDetails;
    public DateTime Created { get; set; }

    public List<InputDetail> ImportDetails
    {
        get => _importDetails;
        set => _importDetails = value ?? throw new ArgumentNullException(nameof(value));
    }

    public InputInvoice()
    {
    }

    public InputInvoice(List<InputDetail> importDetails)
    {
        _importDetails = importDetails;
    }

    public double SumAmount()
    {
        double sum = 0;
        foreach (var invoice in _importDetails)
        {
            sum += invoice.TotalAmount();
        }

        return sum;
    }

    public int SumQuantity()
    {
        int quantity = 0;
        foreach (var invoice in _importDetails)
        {
            quantity += invoice.Quantity;
        }

        return quantity;
    }
}