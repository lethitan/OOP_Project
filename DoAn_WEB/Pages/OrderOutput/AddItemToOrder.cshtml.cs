using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class AddItemToOrder : PageModel
{
    private IOrderOutputService _orderInputService = new OrderOutputService();
    private IProductService _productService = new ProductService();
    public string print;
    [BindProperty] public double Price { get; set; }
    [BindProperty] public int Quantity { get; set; }
    [BindProperty] public int ProductId { get; set; }

    public List<Product> Products = new List<Product>();

    public void OnGet()
    {
        Products = _productService.GetList();
    }

    public void OnPost()
    {
        Product product = _productService.GetById(ProductId);
        OutputDetail outputDetail = new OutputDetail(Quantity, Price, product);
        _orderInputService.AddOutputDetail(outputDetail);
        Response.Redirect("./AddOrderOutput");
    }
}