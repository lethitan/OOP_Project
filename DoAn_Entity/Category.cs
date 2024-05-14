namespace DoAn_Entity;

public class Category
{
    private int _id;
    private string _name;

    public Category(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Name can not empty !");
        }

        Name = name;
    }

    public Category()
    {
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
}