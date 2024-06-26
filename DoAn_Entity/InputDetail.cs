namespace DoAn_Entity;

public class InputDetail
{
    public int id { get; set; }
    public Product Product { get; set; }
    private int _quantity;
    private double _price;

    public InputDetail()
    {
    }

    public InputDetail(int quantity, double price, int id, Product product)
    {
        _quantity = quantity;
        _price = price;
        this.id = id;
        Product = product;
    }

    public InputDetail(int quantity, double price, Product product)
    {
        _quantity = quantity;
        _price = price;
        Product = product;
    }

    public double Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
            }
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value > 0)
            {
                _quantity = value;
            }
        }
    }

    //Thanh phan xu li
    public double TotalAmount()
    {
        return Price * Quantity;
    }
}