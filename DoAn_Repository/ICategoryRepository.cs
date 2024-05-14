using DoAn_Entity;

namespace DoAn_Repository;

public interface ICategoryRepository
{
    List<Category> GetListCategory();

    Category GetById(int id);

    void SaveList(List<Category> categories);

    void AddCategory(Category category);
    void Delete(int id);

    void UpdateCategory(Category category);
}