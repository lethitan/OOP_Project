using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderInput;

public class DeleteOrder : PageModel
{
    public int id;
    public string print = string.Empty;
    private IOrderInputService _orderInputService = new OrderInputService();
    public void OnGet()
    {
        if(!int.TryParse(Request.Query["id"],out id))
        {
            print = "Mã đơn hàng không hợp lệ!";
        }
    }

    public void OnPost()
    {
        try
        {
            id = int.Parse(Request.Query["id"]);
            _orderInputService.Delete(id);
            Response.Redirect("./ListOrderinput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
        
    }
}