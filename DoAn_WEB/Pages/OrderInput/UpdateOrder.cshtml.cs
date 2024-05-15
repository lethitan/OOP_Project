using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderInput;

public class UpdateOrder : PageModel
{
    private IOrderInputService _orderInputService = new OrderInputService();
    [BindProperty] public string print { get; set; } = String.Empty;
    public InputInvoice Invoice = new InputInvoice();
    private int id;

    public void OnGet()
    {
        if (!int.TryParse(Request.Query["id"], out id))
        {
            print = "Mã hoá đơn không tồn tại !";
        }
        else
        {
            Invoice = _orderInputService.GetById(id);
        }
    }
}