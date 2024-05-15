using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class UpdateOrder : PageModel
{
   
    private IOrderOutputService _orderInputService = new OrderOutputService();
    [BindProperty] public string print { get; set; } = String.Empty;
    public OutputInvoice Invoice = new OutputInvoice();
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