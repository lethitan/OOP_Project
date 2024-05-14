namespace DoAn_Service;

using DoAn_Entity;

public interface ICategoryService
{
    List<Category> GetListCategory(string keyword = "");

    Category GetById(int id);

    void SaveList(List<Category> categories);

    void AddCategory(Category category);

    void UpdateCategory(int id, string name);
    void Delete(int id);
}