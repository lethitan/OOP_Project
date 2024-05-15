using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderOutput;

public class ListOrderoutput : PageModel
{
    private IOrderOutputService _productService = new OrderOutputService();
    [BindProperty] public string Keyword { get; set; } = string.Empty;
    public List<OutputInvoice> dssp = new List<OutputInvoice>();

    public void OnGet()
    {
         dssp = _productService.GetList();
    }

    public void OnPost()
    {
        dssp = _productService.GetList(Keyword);
    }
}