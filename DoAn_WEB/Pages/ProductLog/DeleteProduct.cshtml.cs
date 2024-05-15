using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.ProductLog;

public class DeleteProduct : PageModel
{
    public int id;
    public string print = string.Empty;
    private IProductService _productService = new ProductService();

    public void OnGet()
    {
        if (!int.TryParse(Request.Query["ID"], out id))
        {
            print = "Mã loại hàng không hợp lệ!";
        }
    }

    public void OnPost()
    {
        try
        {
            id = int.Parse(Request.Query["Id"]);
            _productService.Delete(id);
            Response.Redirect("./ListProduct");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}