using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderInput;

public class AddOrderInput : PageModel
{
    private IOrderInputService _orderInputService = new OrderInputService();

    public List<InputDetail> inputDetails = new List<InputDetail>();
    public string print = string.Empty;

    public void OnGet()
    {
        inputDetails = _orderInputService.LoadListDetail();
    }

    public void OnPost()
    {
        try
        {
            inputDetails = _orderInputService.LoadListDetail();
            InputInvoice invoice = new InputInvoice(inputDetails);
            _orderInputService.AddInvoice(invoice);
            Response.Redirect("./ListOrderInput");
        }
        catch (Exception e)
        {
            print = e.Message;
        }
    }
}