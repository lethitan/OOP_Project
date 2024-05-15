using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.ProductLog;

public class ListProduct : PageModel
{
    private IProductService _productService = new ProductService();
    [BindProperty] public string Keyword { get; set; }
    public List<Product> dssp = new List<Product>();

    public void OnGet()
    {
        dssp = _productService.GetList();
    }

    public void OnPost()
    {
        dssp = _productService.Search(Keyword, _productService.GetList());
    }
}