using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class AddOrderOutput : PageModel
{
    private IOrderOutputService _orderInputService = new OrderOutputService();

    public List<OutputDetail> OutputDetails = new List<OutputDetail>();
    public string print = string.Empty;

    public void OnGet()
    {
        OutputDetails = _orderInputService.LoadListDetail();
    }

    public void OnPost()
    {
        try
        {
            OutputDetails = _orderInputService.LoadListDetail();
            OutputInvoice invoice = new OutputInvoice(OutputDetails);
            _orderInputService.AddInvoice(invoice);
            Response.Redirect("./ListOrderOutput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}