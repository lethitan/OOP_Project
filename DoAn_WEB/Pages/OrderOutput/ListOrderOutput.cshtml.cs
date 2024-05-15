using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class ListOrderOutput : PageModel
{
    private IOrderOutputService _orderOutputService = new OrderOutputService();
    [BindProperty] public string Keyword { get; set; } = string.Empty;
    public List<OutputInvoice> dssp = new List<OutputInvoice>();

    public void OnGet()
    {
         dssp = _orderOutputService.GetList();
    }

    public void OnPost()
    {
        dssp = _orderOutputService.GetList(Keyword);
    }
}