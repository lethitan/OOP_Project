using DoAn_Entity;

namespace DoAn_Service;

public interface IOrderInputService
{
    List<InputInvoice> GetList(string keyword = "");
    int CountInventoryById(int id);
    void AddInputDetail(InputDetail inputDetail);
    List<InputDetail> LoadListDetail();
    InputInvoice GetById(int id);
    void AddInvoice(InputInvoice invoice);
    void UpdateInvoice(InputDetail invoice, int invoiceId);
    void Delete(int id);
    void DeleteItem(int id, int invoiceId);

    InputDetail GetDetailById(int detailId);
}