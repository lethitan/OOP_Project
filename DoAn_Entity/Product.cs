namespace DoAn_Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }
    public Category Category { get; set; }

    private DateTime _expDate;
    private DateTime _created;

    public Product(DateTime expDate, DateTime created, string name, string provider, Category category)
    {
        _expDate = expDate;
        _created = created;
        Name = name;
        Provider = provider;
        Category = category;
    }

    public Product()
    {
    }

    public Product(DateTime expDate, DateTime created, int id, string name, string provider, Category category)
    {
        _expDate = expDate;
        _created = created;
        Id = id;
        Name = name;
        Provider = provider;
        Category = category;
    }

    public DateTime ExpDate
    {
        get => _expDate;
        set
        {
            if (value > Created)
            {
                _expDate = value;
            }
        }
    }

    public DateTime Created
    {
        get => _created;
        set
        {
            if (value < ExpDate)
            {
                _created = value;
            }
        }
    }
}