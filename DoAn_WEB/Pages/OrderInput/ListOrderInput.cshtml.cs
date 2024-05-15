using DoAn_Entity;
using DoAn_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAn_WEB.Pages.OrderInput;

public class ListOrderInput : PageModel
{
    private IOrderInputService _productService = new OrderInputService();
    [BindProperty] public string Keyword { get; set; } = string.Empty;
    public List<InputInvoice> dssp = new List<InputInvoice>();

    public void OnGet()
    {
        dssp = _productService.GetList();
    }

    public void OnPost()
    {
        dssp = _productService.GetList(Keyword);
    }
}