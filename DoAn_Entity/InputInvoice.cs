namespace DoAn_Entity;

public class InputInvoice
{
    //Thanh phan du lieu
    public int ID { get; set; }
    private InputDetail[] _importDetails;
    public DateTime Created { get; set; }

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