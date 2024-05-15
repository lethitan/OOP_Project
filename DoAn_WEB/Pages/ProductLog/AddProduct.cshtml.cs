using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.ProductLog;

public class AddProduct : PageModel
{
    private ICategoryService _categoryService = new CategoryService();
    private IProductService _productService = new ProductService();
    public string print;
    [BindProperty] public string Name { get; set; }
    [BindProperty] public string Provider { get; set; }
    [BindProperty] public int CategoryId { get; set; }
    [BindProperty] public DateTime ExpDate { get; set; }
    [BindProperty] public DateTime Created { get; set; }

    public List<Category> Categories = new List<Category>();

    public void OnGet()
    {
        Categories = _categoryService.GetListCategory();
    }

    public void OnPost()
    {
        try
        {
            Category category = _categoryService.GetById(CategoryId);
            Product product = new Product(ExpDate, Created, Name, Provider, category);
            _productService.AddProduct(product);
            Response.Redirect("./ListProduct");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}