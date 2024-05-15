using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderInput;

public class UpdateDetail : PageModel
{
    public int id;
    public int invoiceId;
    public int productId;
    
    private IOrderInputService _orderInputService = new OrderInputService();
    private IProductService _productService = new ProductService();
    public string print = string.Empty;

    [BindProperty] public Product product { get; set; } = new Product();
    [BindProperty] public double Price { get; set; }
    [BindProperty] public int Quantity { get; set; }


    public void OnGet()
    {
        if (!int.TryParse(Request.Query["id"], out id) ||
            !int.TryParse(Request.Query["invoiceId"], out invoiceId))
        {
            print = "Mã hoá đơn không tồn tại!";
        }

        if (print == "")
        {
            InputDetail detail = _orderInputService.GetDetailById(id);
            if (detail.id != 0)
            {
                product = detail.Product;
                productId = detail.Product.Id;
                Quantity = detail.Quantity;
                Price = detail.Price;
            }
        }
    }

    public void OnPost()
    {
        try
        {
            id = int.Parse(Request.Query["id"]);
            invoiceId = int.Parse(Request.Query["invoiceId"]);
            productId = int.Parse(Request.Form["productId"]);
            Product newProduct = _productService.GetById(productId);
            InputDetail detail = new InputDetail(Quantity, Price,id, newProduct);
            _orderInputService.UpdateInvoice(detail, invoiceId);
            Response.Redirect("./ListOrderInput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}