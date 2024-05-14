using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.CategoryLog;

public class ListCategory : PageModel
{
    private ICategoryService _categoryService = new CategoryService();
    public List<Category> categories;
    [BindProperty] public string Keyword { get; set; }

    public void OnGet()
    {
        categories = _categoryService.GetListCategory();
    }

    public void OnPost()
    {
        categories = _categoryService.GetListCategory(Keyword);
    }
}