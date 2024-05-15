using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class DeleteItem : PageModel
{
    public int id;
    public int invoiceId;
    public string print = string.Empty;
    private IOrderOutputService _orderInputService = new OrderOutputService();

    public void OnGet()
    {
        if (!int.TryParse(Request.Query["id"], out id))
        {
            print = "Mã đơn hàng không hợp lệ!";
        }

        if (!int.TryParse(Request.Query["invoiceId"], out invoiceId))
        {
            print = "Mã đơn hàng không hợp lệ!";
        }
    }

    public void OnPost()
    {
        try
        {
            id = int.Parse(Request.Query["id"]);
            invoiceId = int.Parse(Request.Query["invoiceId"]);
            _orderInputService.DeleteItem(id,invoiceId);
            Response.Redirect("./ListOrderOutput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}