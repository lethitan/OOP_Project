namespace DoAn_Entity;

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }
    public Category Category { get; set; }

    private DateTime expDate;
    private DateTime _created;

    public DateTime ExpDate
    {
        get => expDate;
        set
        {
            if (value > DateTime.Today)
            {
                expDate = value;
            }
        }
    }

    public DateTime Created
    {
        get => _created;
        set
        {
            if (value.Year < DateTime.Now.Year)
            {
                _created = value;
            }
        }
    }
}