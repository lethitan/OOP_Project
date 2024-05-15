using DoAn_Entity;

namespace DoAn_Service;

public interface IOrderOutputService
{
    List<OutputInvoice> GetList(string keyword = "");
    int CountInventoryById(int id);
    OutputInvoice GetById(int id);
    void AddInvoice(OutputInvoice invoice);
    List<OutputDetail> LoadListDetail();
    void UpdateInvoice(OutputDetail invoice, int invoiceId);
    void Delete(int id);
    void DeleteItem(int id, int invoiceId);

    OutputDetail GetDetailById(int detailId);
}