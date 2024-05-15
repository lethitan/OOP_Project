using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.ProductLog;

public class UpdateProduct : PageModel
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
        int id = int.Parse(Request.Query["ID"]);
        Product product = _productService.GetById(id);
        Name = product.Name;
        Provider = product.Provider;
        ExpDate = product.ExpDate;
        Created = product.Created;
        CategoryId = product.Category.Id;
        Categories = _categoryService.GetListCategory();
    }

    public void OnPost()
    {
        try
        {
            int id = int.Parse(Request.Query["ID"]);
            Category category = _categoryService.GetById(CategoryId);
            Product product = new Product(ExpDate, Created, id, Name, Provider, category);
            Product newPr = _productService.UpdateProduct(product);
            if (newPr.Id != 0)
            {
                Response.Redirect("./ListProduct");
            }
            else
            {
                print = "không thể chỉnh sửa !";
            }
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}