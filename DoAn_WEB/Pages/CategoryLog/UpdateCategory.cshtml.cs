using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.CategoryLog;

public class UpdateCategory : PageModel
{
    private ICategoryService _categoryService = new CategoryService();
    public int id;
    [BindProperty] public string Name { get; set; }
    public string print = string.Empty;
    
    public void OnGet()
    {
        if (!int.TryParse(Request.Query["id"], out id))
        {
            print = "Mã không hợp lệ!";
        }
        Category category = _categoryService.GetById(id);
        Name = category.Name;

    }

    public void OnPost()
    {
        id = int.Parse(Request.Query["id"]);
        _categoryService.UpdateCategory(id,Name);
        Response.Redirect("./ListCategory");
    }
}