using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class UpdateDetail : PageModel
{
   
    public int id;
    public int invoiceId;
    public int productId;
    
    private IOrderOutputService _orderInputService = new OrderOutputService();
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
            OutputDetail detail = _orderInputService.GetDetailById(id);
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
            OutputDetail detail = new OutputDetail(Quantity, Price,id, newProduct);
            _orderInputService.UpdateInvoice(detail, invoiceId);
            Response.Redirect("./ListOrderOutput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}