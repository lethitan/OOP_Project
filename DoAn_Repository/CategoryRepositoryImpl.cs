using DoAn_Entity;
using Newtonsoft.Json;

namespace DoAn_Repository;

public class CategoryRepositoryImpl : ICategoryRepository
{
    private string _filePath = "./Category.json";

    public List<Category> GetListCategory()
    {
        List<Category> categories = new List<Category>();
        StreamReader reader = new StreamReader(_filePath);
        string json = reader.ReadToEnd();

        categories = JsonConvert.DeserializeObject<List<Category>>(json);

        reader.Close();

        return categories;
    }

    public Category GetById(int id)
    {
        List<Category> categories = GetListCategory();
        foreach (var category in categories)
        {
            if (category.Id == id)
            {
                return category;
            }
        }

        return new Category();
    }

    public void SaveList(List<Category> categories)
    {
        StreamWriter sw = new StreamWriter(_filePath);
        string json = JsonConvert.SerializeObject(categories);
        sw.Write(json);
        sw.Close();
    }

    public void AddCategory(Category category)
    {
        List<Category> categories = GetListCategory();
        categories.Add(category);
        SaveList(categories);
    }

    public void Delete(int id)
    {
        List<Category> categories = GetListCategory();
        List<Category> newList = new List<Category>();
        foreach (var c in categories)
        {
            if (c.Id != id)
            {
                newList.Add(c);
            }
        }

        SaveList(newList);
    }

    public void UpdateCategory(Category category)
    {
        List<Category> categories = GetListCategory();
        for (int i = 0; i < categories.Count; i++)
        {
            if (categories[i].Id == category.Id)
            {
                categories[i] = category;
                SaveList(categories);
            }
        }
    }
}