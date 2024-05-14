using DoAn_Repository;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.CategoryLog;

public class DeleteCategory : PageModel
{
    public int id;
    public string print = string.Empty;
    private ICategoryService _categoryService = new CategoryService();
    public void OnGet()
    {
        if(!int.TryParse(Request.Query["id"],out id))
        {
            print = "Mã loại hàng không hợp lệ!";
        }
    }

    public void OnPost()
    {
        id = int.Parse(Request.Query["id"]);
        _categoryService.Delete(id);
        Response.Redirect("./ListCategory");
    }
}