using DoAn_Entity;
using DoAn_Repository;

namespace DoAn_Service;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepositoryImpl = new CategoryRepositoryImpl();

    public List<Category> GetListCategory(string keyword = "")
    {
        List<Category> categories = _categoryRepositoryImpl.GetListCategory();
        if (string.IsNullOrEmpty(keyword))
        {
            return categories;
        }

        List<Category> result = new List<Category>();
        foreach (var category in categories)
        {
            if (category.Id.ToString().Contains(keyword) || category.Name.Contains(keyword))
            {
                result.Add(category);
            }
        }

        return result;
    }

    public Category GetById(int id)
    {
        return _categoryRepositoryImpl.GetById(id);
    }

    public void SaveList(List<Category> categories)
    {
        _categoryRepositoryImpl.SaveList(categories);
    }

    public void AddCategory(Category category)
    {
        List<Category> categories = _categoryRepositoryImpl.GetListCategory();
        int maxId = 0;
        foreach (var pr in categories)
        {
            if (pr.Id > maxId)
            {
                maxId = pr.Id;
            }
        }

        category.Id = maxId + 1;
        _categoryRepositoryImpl.AddCategory(category);
    }

    public void UpdateCategory(int id, string name)
    {
        Category newCategory = _categoryRepositoryImpl.GetById(id);
        if (newCategory.Id != 0)
        {
            newCategory.Name = name;
            _categoryRepositoryImpl.UpdateCategory(newCategory);
        }
    }

    public void Delete(int id)
    {
        _categoryRepositoryImpl.Delete(id);
    }
}