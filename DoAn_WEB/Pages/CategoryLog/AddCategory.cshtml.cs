using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.CategoryLog;

public class AddCategory : PageModel
{
    private ICategoryService _categoryService = new CategoryService();
    [BindProperty] public string Name { get; set; }
    public string print { get; set; } = string.Empty;

    public void OnPost()
    {
        try
        {
            Category category = new Category(Name);
            _categoryService.AddCategory(category);
            Response.Redirect("./ListCategory");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}